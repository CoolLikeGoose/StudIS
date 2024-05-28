using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StudIS.APP.ViewModels.Activity
{
    public partial class ActivityListViewModel : ObservableObject, IViewModel
    {
        private readonly IActivityFacade _activityFacade;

        public ActivityListViewModel(IActivityFacade activityFacade)
        {
            _activityFacade = activityFacade;
            Activities = new ObservableCollection<ActivityListModel>();
        }

        public ObservableCollection<ActivityListModel> Activities { get; }

        [ObservableProperty]
        private string searchTerm;

        public async Task LoadDataAsync()
        {
            IEnumerable<ActivityListModel> activities = await _activityFacade.GetAsync();
            Activities.Clear();
            foreach (ActivityListModel activity in activities)
            {
                Activities.Add(activity);
            }
        }

        [RelayCommand]
        private async Task GoToCreateAsync()
        {
            await Shell.Current.GoToAsync("edit");
        }

        [RelayCommand]
        public async Task GoToDetailAsync(Guid id)
        {
            await Shell.Current.GoToAsync("detail", new Dictionary<string, object> { { "Id", id } });
        }

        [RelayCommand]
        public async Task SearchAsync()
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                await LoadDataAsync();
                return;
            }

            IEnumerable<ActivityListModel> activities = await _activityFacade.GetByName(searchTerm);
            Activities.Clear();
            foreach (ActivityListModel activity in activities)
            {
                Activities.Add(activity);
            }
        }
    }
}