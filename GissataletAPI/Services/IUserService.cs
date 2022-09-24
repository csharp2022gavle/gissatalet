using User_Information_API.Models;
namespace User_Information_API.Services
{
    public interface IUserService
    {
        List<User> Get();
        User Get(string id);
        User Create(User user);
        void Update(string id, User user);
        void Remove(string id);
    }
}
