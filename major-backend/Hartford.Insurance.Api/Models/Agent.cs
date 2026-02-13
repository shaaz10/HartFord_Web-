using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Agent : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("region")]
        public string Region { get; set; } = string.Empty;
    }
}
