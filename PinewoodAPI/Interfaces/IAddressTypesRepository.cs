using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IAddressTypesRepository
    {
        ICollection<AddressType> GetAddressTypes();
    }
}
