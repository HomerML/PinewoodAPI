using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class ContactTypesRepository : IContactTypesRepository
    {
        private readonly DataContext _dataContext;

        public ContactTypesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<ContactType> GetContactTypes()
        {
            return _dataContext.ContactTypes.OrderBy(p => p.ContactTypeId).ToList();
        }
    }
}
