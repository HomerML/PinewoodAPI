using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface ITitlesRepository
    {
        ICollection<Title> GetTitles();
    }
}
