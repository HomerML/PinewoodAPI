using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IStatusesRepository
    {
        ICollection<Status> GetStatuses();
    }
}
