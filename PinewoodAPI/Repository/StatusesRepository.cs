using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly DataContext _dataContext;

        public StatusesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<Status> GetStatuses()
        {
            return _dataContext.Statuses.OrderBy(p => p.StatusId).ToList();
        }
    }
}
