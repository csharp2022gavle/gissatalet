using BCrypt.Net;
namespace User_Information_API.Models
{
    internal class Hashing
    {
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}