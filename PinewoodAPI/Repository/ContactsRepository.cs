using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly DataContext _dataContext;

        public ContactsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool ContactExists(int id)
        {
            return _dataContext.Contacts.Any(c => c.ContactId == id);
        }

        public ICollection<Contact> GetContacts()
        {
            return _dataContext.Contacts.OrderBy(p => p.ContactId).ToList();
        }

        public Contact GetContact(int id)
        {
            return _dataContext.Contacts.Where(e => e.ContactId == id).FirstOrDefault();
        }

        public bool CreateContact(Contact contact)
        {
            _dataContext.Contacts.Add(contact);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateContact(Contact contact)
        {
            _dataContext.Update(contact);
            return Save();
        }
    }
}
