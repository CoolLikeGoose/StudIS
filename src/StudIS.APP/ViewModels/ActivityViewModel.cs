using StudIS.BL.Facades;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels
{
    public class ActivityViewModel
    {
        private readonly ActivityFacade _activityFacade;

        public ActivityViewModel(ActivityFacade activityFacade)
        {
            _activityFacade = activityFacade;
        }

        public async Task<IEnumerable<ActivityListModel>> GetAllActivities()
        {
            return await _activityFacade.GetAsync();
        }

        public async Task<ActivityDetailModel> GetActivityById(Guid id)
        {
            return await _activityFacade.GetAsync(id);
        }

        public async Task AddOrUpdateActivity(ActivityDetailModel activity)
        {
            await _activityFacade.SaveAsync(activity);
        }

        public async Task DeleteActivity(Guid id)
        {
            await _activityFacade.DeleteAsync(id);
        }
    }

}

