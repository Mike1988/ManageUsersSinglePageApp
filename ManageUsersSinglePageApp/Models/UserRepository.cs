

using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageUsersCoreApp.Models
{
    public interface IUserRepository
    {
        List<User> FindAll();

        User FindById(int id);

        User Add(User user);
    }

    public class UserRepository : IUserRepository //: DbContext
    {
        private List<User> _users = new List<User>();
        private int Id = 1;


        public UserRepository()
        {
            _users.Add(new User { Name = "fdsfsd", Age = 10, Address = "fsdfsd", Id = 1 });
        }

        public User Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("item");
            }

            user.Id = Id++;
            _users.Add(user);
            return user;
        }

        public List<User> FindAll()
        {
            return _users.ToList();
        }

        public User FindById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}