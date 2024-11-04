using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _dataContext;

        public UsersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<User> GetUsers()
        {
            return _dataContext.Users.OrderBy(p => p.UserId).ToList();
        }


    }
}
