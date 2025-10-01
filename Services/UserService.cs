using SocialNetworkV1.Models;
using SocialNetworkV1.Data;

namespace SocialNetworkV1.Services
{
    public interface IUserService 
    {
        User? GetUser(Guid id);
        User CreateUser(string name, string email);
        void UpdateUser(Guid id, string? name, string? email);
        void DeleteUser(Guid id);
    }
    public class UserService: IUserService
    {
        private UserDb _userDb;

        public UserService(UserDb userDb)
        {
            _userDb = userDb;
        }

        public User GetUser(Guid id) 
        {
            var user = _userDb.users.Find(id);
            if (user == null) 
            {
                return new User("None", "Found");
            }
            return new User("user1", "user@example.com");
        }

        public User CreateUser(string name, string email) 
        {
            var createdUser = new User(name, email);
            _userDb.users.Add(createdUser);
            return createdUser;
        }

        public void UpdateUser(Guid id, string? name, string? email) 
        { 
            var userToUpdate = _userDb.users.Find(id);
            if (userToUpdate != null) 
            {
                userToUpdate.Name = name;
                userToUpdate.Email = email;
            }
            _userDb.SaveChanges();
        }

        public void DeleteUser(Guid id) 
        {
            var userToDelete = _userDb.users.Find(id);
            if (userToDelete != null) 
            {
                _userDb.users.Remove(userToDelete);
            }
        }

    }
}
