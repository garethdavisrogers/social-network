using SocialNetworkV1.Models;
using SocialNetworkV1.Data;

namespace SocialNetworkV1.Services
{
    public interface IUserService 
    {
        User? GetUser(Guid id);
        User CreateUser(string name, string email);
        User? UpdateUser(Guid id, string? name, string? email);
        bool DeleteUser(Guid id);
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
            return user;
        }

        public User CreateUser(string name, string email) 
        {
            var createdUser = new User(name, email);
            _userDb.users.Add(createdUser);
            var created = _userDb.SaveChanges();
            Console.WriteLine(created);
            return createdUser;
        }

        public User? UpdateUser(Guid id, string? name, string? email) 
        { 
            var userToUpdate = _userDb.users.Find(id);
            if (userToUpdate == null)
                return null;

            if (!string.IsNullOrWhiteSpace(name))
                userToUpdate.Name = name;

            if (!string.IsNullOrWhiteSpace(email))
                userToUpdate.Email = email;

            _userDb.SaveChanges();

            return userToUpdate;
        }

        public bool DeleteUser(Guid id) 
        {
            var userToDelete = _userDb.users.Find(id);
            if (userToDelete != null) 
            {
                _userDb.users.Remove(userToDelete);
                _userDb.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
