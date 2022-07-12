using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Models;

namespace ContactsControl.Repository
{
    public interface IUserRepository
    {
        UserModel ListById(int id);
        List<UserModel> SearchAll();
        UserModel Add(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(int id);
    }
}
