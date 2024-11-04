using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DataContext _dataContext;

        public CustomersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CustomerExists(int id)
        {
            return _dataContext.Customers.Any(c => c.CustomerId == id);
        }

        public ICollection<Customer> GetCustomers()
        {
            return _dataContext.Customers.OrderBy(p => p.CustomerId).ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _dataContext.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
        }

        public bool CreateCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _dataContext.Update(customer);
            return Save();
        }
    }
}
