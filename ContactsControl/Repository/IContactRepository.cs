using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Models;

namespace ContactsControl.Repository
{
    public interface IContactRepository
    {
        ContactModel ListById(int id);
        List<ContactModel> SearchAll();
        ContactModel Add(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);
    }
}
