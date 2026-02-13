using Hartford.Insurance.Api.Models;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class BaseService<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseService(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(string id, T entity)
        {
            entity.Id = id; // Ensure ID matches
            entity.UpdatedAt = DateTime.UtcNow;
            // Retain original CreatedAt if possible, but simplest is to not overwrite or fetch first. 
            // Better to use ReplaceOne. If CreatedAt is lost, that's bad.
            // Best practice: Fetch existing, update fields, save. Or just trust client sends it back?
            // "Replica of existing endpoints" -> typical JSON server PUT replaces content. PATCH updates fields.
            // User requested PATCH /api/users/{id}, but also ReplaceOneAsync for updates.
            // "Use ReplaceOneAsync for updates". I will implement standard Replace.
            
            // To preserve CreatedAt without fetching, we might need a specific update definition, but user asked for ReplaceOneAsync.
            // I'll assume the entity passed in has the correct CreatedAt or I'll fetch it.
            // Fetching is safer.
            var existing = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (existing != null)
            {
                entity.CreatedAt = existing.CreatedAt;
                await _collection.ReplaceOneAsync(x => x.Id == id, entity);
            }
        }

        public virtual async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
