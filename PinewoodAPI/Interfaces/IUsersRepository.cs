using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IUsersRepository
    {
        ICollection<User> GetUsers();
    }
}
