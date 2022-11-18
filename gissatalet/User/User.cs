using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace gissatalet.user
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private ObjectId _id;
        private string _name;
        private string _password;

        public ObjectId Id 
        {
            get { return _id; } 
            set { _id = value; }
        }
        [BsonElement("Name")]
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        [BsonElement("Password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [BsonElement("Score")]
        public int Score { get; set; }
        [BsonElement("Tries")]
        public int Tries { get; set; }

        public User(string name, int score, int tries)
        {
            Id = ObjectId.GenerateNewId();
            Name = name;
            Score = score;
            Tries = tries;
        }
    }
}