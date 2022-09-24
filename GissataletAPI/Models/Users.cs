using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace User_Information_API.Models
{
    public class User
    {
        [BsonId]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string? Name { get; set; }
        [BsonElement("Password")]
        public string? Password { get; set; }
        [BsonElement("PasswordVerified")]
        public string? PasswordVerified { get; set; }
        [BsonElement("Score")]
        public string? Score { get; set; }
        [BsonElement("Tries")]
        public string? Tries { get; set; }
    }
}
