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
    public class UserService: IUserService
    {
        public User GetUser(string username) 
        {
            return new User();
        }

        public User CreateUser(string username) 
        {
            return new User();
        }

        public void UpdateUser(User user) 
        { 
        }

        public void DeleteUser(User user) 
        { 
        }

    }
}
