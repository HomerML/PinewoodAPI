using PinewoodAPI.Models;

namespace PinewoodAPI.Interfaces
{
    public interface IActivitiesRepository
    {
        ICollection<Activity> GetActivities();

        Activity GetActivity(int id);

        bool ActivityExists(int id);

        bool CreateActivity(Activity activity);

        bool UpdateActivity(Activity activity);

        bool DeleteActivity(Activity activity);

        bool Save();
    }
}
