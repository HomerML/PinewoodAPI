using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IContactsRepository
    {
        ICollection<Contact> GetContacts(int id);

        ICollection<ContactViewModel> GetContactsList(int id);

        Contact GetContact(int id);        

        bool ContactExists(int id);

        bool CustomerContactExists(int id);

        bool CreateContact(Contact contact);

        bool UpdateContact(Contact contact);

        bool Save();
    }
}
