using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class InsuranceRequest : BaseEntity
    {
        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("agentId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AgentId { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty; // e.g. Life, Health, Auto

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = "Pending";
    }
}
