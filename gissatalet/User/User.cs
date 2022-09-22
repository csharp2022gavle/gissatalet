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
        private bool _passwordVerified;

        public ObjectId Id 
        {
            get { return _id; } 
            set { _id = value; }
        }

        [BsonElement("User")]

        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool PasswordVerified
        {
            get { return _passwordVerified; }
            set { _passwordVerified = value; }
        }

        public int Score { get; set; }
        public int Tries { get; set; }

        public User(string name, int score, int tries)
        {
            this.Id = ObjectId.GenerateNewId();
            Name = name;
            Score = score;
            Tries = tries;
        }
    }
}