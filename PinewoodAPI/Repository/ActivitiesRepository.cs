using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly DataContext _dataContext;

        public ActivitiesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool ActivityExists(int id)
        {
            return _dataContext.Activities.Any(c => c.ActivityId == id);
        }

        public ICollection<Activity> GetActivities()
        {
            return _dataContext.Activities.OrderBy(p => p.ActivityId).ToList();
        }

        public Activity GetActivity(int id)
        {
            return _dataContext.Activities.Where(e => e.ActivityId == id).FirstOrDefault();
        }

        public bool CreateActivity(Activity activity)
        {
            _dataContext.Activities.Add(activity);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateActivity(Activity activity)
        {
            _dataContext.Update(activity);
            return Save();
        }

        public bool DeleteActivity(Activity activity)
        {
            _dataContext.Remove(activity);
            return Save();
        }
    }
}
