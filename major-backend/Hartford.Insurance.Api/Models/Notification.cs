using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Notification : BaseEntity
    {
        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = string.Empty;

        [BsonElement("message")]
        public string Message { get; set; } = string.Empty;

        [BsonElement("isRead")]
        public bool IsRead { get; set; } = false;

        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
