using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IContactTypesRepository
    {
        ICollection<ContactType> GetContactTypes();
    }
}
