using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hartford.Insurance.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Claim : BaseEntity
    {
        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("policyId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PolicyId { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = "Pending";

        [BsonElement("dateFiled")]
        public DateTime DateFiled { get; set; } = DateTime.UtcNow;
    }
}
