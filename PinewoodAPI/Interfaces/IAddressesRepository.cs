using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IAddressesRepository
    {
        ICollection<Address> GetAddresses();

        Address GetAddress(int id);

        bool AddressExists(int id);

        bool CreateAddress(Address address);

        bool UpdateAddress(Address address);

        bool Save();
    }
}
