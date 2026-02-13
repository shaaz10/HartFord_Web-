using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Policy : BaseEntity
    {
        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("agentId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AgentId { get; set; } = string.Empty;

        [BsonElement("policyName")]
        public string PolicyName { get; set; } = string.Empty;

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("premium")]
        public decimal Premium { get; set; }
    }
}
