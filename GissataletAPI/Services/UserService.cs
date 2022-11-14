using MongoDB.Bson;
using MongoDB.Driver;
using User_Information_API.Models;
namespace User_Information_API.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _Users;

        public UserService(IUserDbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Gissatalet");
            _Users = database.GetCollection<User>("Users");
        }

        public User Create(User User)
        {
            _Users.InsertOne(User);
            return User;
        }

        public List<User> Get()
        {
            return _Users.Find(User => true).Project(x => new User{ Id = x.Id, Name = x.Name, Score = x.Score, Tries = x.Tries } ).ToList();
        }

        public User Get(string id)
        {
            return _Users.Find(User => User.Id == id).Project(x => new User { Id = x.Id, Name = x.Name, Score = x.Score, Tries = x.Tries }).FirstOrDefault();
        }

        //public void Remove(string id)
        //{
        //    _Users.DeleteOne(User => User.Id == id);
        //}

        public void Update(string id, User User)
        {
            _Users.ReplaceOne(User => User.Id == id, User);
        }
    }
}
