using ContactsControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Data;

namespace ContactsControl.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public UserModel Add(UserModel user)
        {
            // Gravar no banco de dados
            user.RegisterDate = DateTime.Now;
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();

            return user;
        }

        public bool Delete(int id)
        {
            UserModel userDB = ListById(id);

            if (userDB == null) throw new SystemException("An error has occurred during delete!");

            _databaseContext.Users.Remove(userDB);
            _databaseContext.SaveChanges();

            return true;
        }

        public UserModel ListById(int id)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> SearchAll()
        {
            return _databaseContext.Users.ToList();
        }

        public UserModel Update(UserModel user)
        {
            UserModel userDB = ListById(user.Id);

            if (userDB == null) throw new SystemException("An error has occurred during update!");

            userDB.Name = user.Name;
            userDB.Email = user.Email;
            userDB.Login = user.Login;
            userDB.Profile = userDB.Profile;
            userDB.UpdateDate = DateTime.Now;

            _databaseContext.Users.Update(userDB);
            _databaseContext.SaveChanges();

            return userDB;
        }
    }
}
