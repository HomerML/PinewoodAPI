using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class AddressesRepository : IAddressesRepository
    {
        private readonly DataContext _dataContext;

        public AddressesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool AddressExists(int id)
        {
            return _dataContext.Addresses.Any(c => c.AddressId == id);
        }

        public ICollection<Address> GetAddresses()
        {
            return _dataContext.Addresses.OrderBy(p => p.AddressId).ToList();
        }

        public Address GetAddress(int id)
        {
            return _dataContext.Addresses.Where(e => e.AddressId == id).FirstOrDefault();
        }

        public bool CreateAddress(Address address)
        {
            _dataContext.Addresses.Add(address);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAddress(Address address)
        {
            _dataContext.Update(address);
            return Save();
        }
    }
}
