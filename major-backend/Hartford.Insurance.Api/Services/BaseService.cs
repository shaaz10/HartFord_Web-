using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class BaseService<T> where T : BaseEntity
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<T> _set;

        public BaseService(AppDbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync()
            => await _set.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(int id)
            => await _set.FindAsync(id);

        public virtual async Task<T> CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _set.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T?> UpdateAsync(int id, T entity)
        {
            var existing = await _set.FindAsync(id);
            if (existing == null) return null;

            entity.Id = id;
            entity.CreatedAt = existing.CreatedAt;
            entity.UpdatedAt = DateTime.UtcNow;
            _db.Entry(existing).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
            return existing;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _set.FindAsync(id);
            if (entity == null) return false;
            _set.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
