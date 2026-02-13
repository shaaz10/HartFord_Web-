using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class User : BaseEntity
    {
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("role")]
        public string Role { get; set; } = string.Empty; // customer, agent, admin
    }
}
