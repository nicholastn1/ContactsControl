using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Models;

namespace ContactsControl.Helper
{
    public interface IUserSession
    {
        void StartUserSession(UserModel user);
        void OverUserSession();
        UserModel SearchUserSession();
    }
}
