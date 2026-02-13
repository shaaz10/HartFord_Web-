using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Payment : BaseEntity
    {
        [BsonElement("policyId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PolicyId { get; set; } = string.Empty;

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("method")]
        public string Method { get; set; } = "Card";

        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
