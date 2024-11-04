using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class EventTypesRepository : IEventTypesRepository
    {
        private readonly DataContext _dataContext;

        public EventTypesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<EventType> GetEventTypes()
        {
            return _dataContext.EventTypes.OrderBy(p => p.EventTypeId).ToList();
        }
    }
}
