using ContactsControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Data;

namespace ContactsControl.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public ContactModel Add(ContactModel contact)
        {
            // Gravar no banco de dados
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();

            return contact;
        }

        public bool Delete(int id)
        {
            ContactModel contactDB = ListById(id);

            if (contactDB == null) throw new SystemException("An error has occurred during delete!");

            _databaseContext.Contacts.Remove(contactDB);
            _databaseContext.SaveChanges();

            return true;
        }

        public ContactModel ListById(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> SearchAll()
        {
            return _databaseContext.Contacts.ToList();
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDB = ListById(contact.Id);

            if (contactDB == null) throw new SystemException("An error has occurred during update!");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Phone = contact.Phone;

            _databaseContext.Contacts.Update(contactDB);
            _databaseContext.SaveChanges();

            return contactDB;
        }
    }
}
