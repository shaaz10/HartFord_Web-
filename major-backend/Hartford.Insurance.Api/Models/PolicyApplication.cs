using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class PolicyApplication : BaseEntity
    {
        [BsonElement("agentId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AgentId { get; set; } = string.Empty;

        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("policyName")]
        public string PolicyName { get; set; } = string.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = "Pending";
    }
}
