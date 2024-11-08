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

        public ICollection<Address> GetAddresses(int id)
        {
            return _dataContext.Addresses.Where(e => e.CustomerId == id).ToList();
        }

        public ICollection<AddressViewModel> GetAddressesList(int id)
        {
            var addressesWithDetails = (from address in _dataContext.Addresses
                                        join addressType in _dataContext.AddressTypes
                                        on address.AddressTypeId equals addressType.AddressTypeId
                                        where address.StatusId == 1 && address.CustomerId == id
                                        select new
                                        {
                                            address.AddressId,
                                            AddressDescription = addressType.AddressDescription,
                                            address.AddressLine1,
                                            address.Town,
                                            address.County,
                                            address.PostCode,
                                            address.MarketingAllowed
                                        }).ToList();

            var viewModelList = addressesWithDetails.Select(c => new AddressViewModel
            {
                AddressId = c.AddressId,
                AddressDescription = c.AddressDescription,
                AddressLine1 = c.AddressLine1,
                Town = c.Town,
                County = c.County,
                PostCode = c.PostCode,
                MarketingAllowed = c.MarketingAllowed
            }).ToList();

            return viewModelList;
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
