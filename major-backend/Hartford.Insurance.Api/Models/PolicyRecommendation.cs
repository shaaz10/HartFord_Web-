using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class PolicyRecommendation : BaseEntity
    {
        [BsonElement("requestId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RequestId { get; set; } = string.Empty;

        [BsonElement("policyName")]
        public string PolicyName { get; set; } = string.Empty;

        [BsonElement("premium")]
        public decimal Premium { get; set; }

        [BsonElement("coverage")]
        public string Coverage { get; set; } = string.Empty;
    }
}
