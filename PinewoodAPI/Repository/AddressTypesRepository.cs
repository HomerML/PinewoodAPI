using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class AddressTypesRepository : IAddressTypesRepository
    {
        private readonly DataContext _dataContext;

        public AddressTypesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<AddressType> GetAddressTypes()
        {
            return _dataContext.AddressTypes.OrderBy(p => p.AddressTypeId).ToList();
        }
    }
}
