using SocialNetworkV1.Models;

namespace SocialNetworkV1.Services
{
    public interface IUserService 
    {
        User? GetUser();
        User AddUser(string? name, string? email);
        void UpdateUser(Guid id, User user);
        void DeleteUser(Guid id);
    }
    public class UserService: IUserService
    {
        public User GetUser() 
        {
            return new User();
        }

        public User AddUser(string? name, string? email) 
        {
            return new User(name, email);
        }

        public void UpdateUser(Guid id, User user) 
        { 
        }

        public void DeleteUser(Guid id) 
        { 
        }

    }
}
