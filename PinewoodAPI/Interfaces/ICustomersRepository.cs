using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface ICustomersRepository
    {
        ICollection<Customer> GetCustomers();

        Customer GetCustomer(int id);

        bool CustomerExists(int id);

        bool CreateCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool Save();
    }
}
