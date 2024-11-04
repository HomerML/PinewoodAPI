using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IContactsRepository
    {
        ICollection<Contact> GetContacts();

        Contact GetContact(int id);

        bool ContactExists(int id);

        bool CreateContact(Contact contact);

        bool UpdateContact(Contact contact);

        bool Save();
    }
}
