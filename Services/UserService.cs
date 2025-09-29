using SocialNetworkV1.Models;

namespace SocialNetworkV1.Services
{
    public interface IUserService 
    {
        User? GetUser(string username);
        User CreateUser(string username);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
    public class UserService
    {
    }
}
