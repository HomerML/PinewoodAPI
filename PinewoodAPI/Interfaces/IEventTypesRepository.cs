using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IEventTypesRepository
    {
        ICollection<EventType> GetEventTypes();
    }
}