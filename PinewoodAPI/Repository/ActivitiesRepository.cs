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

        public ICollection<Activity> GetActivities(int id)
        {
            return _dataContext.Activities.Where(e => e.CustomerId == id).ToList();
        }

        public ICollection<ActivityViewModel> GetActivitiesList(int id)
        {
            var activitiesWithDetails = (from activity in _dataContext.Activities
                                         join eventType in _dataContext.EventTypes
                                         on activity.EventTypeId equals eventType.EventTypeId
                                         join user in _dataContext.Users
                                         on activity.UpdatedBy equals user.UserId
                                         where activity.CustomerId == id && activity.StatusId == 1
                                         select new
                                         {
                                             activity.ActivityId,
                                             activity.ActivityDate,
                                             EventDescription = eventType.EventDescription,
                                             activity.Notes,
                                             UpdatedBy = user.FirstName + " " + user.LastName
                                         }).ToList();

            var viewModelList = activitiesWithDetails.Select(c => new ActivityViewModel
            {
                ActivityId = c.ActivityId,
                ActivityDate = c.ActivityDate,
                EventDescription = c.EventDescription,
                UpdatedBy = c.UpdatedBy
            }).ToList();

            return viewModelList;
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
