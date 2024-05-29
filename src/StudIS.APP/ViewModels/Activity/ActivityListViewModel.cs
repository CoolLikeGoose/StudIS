using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System;
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
            SortOptions = new ObservableCollection<string>
            {
                "Start Date (Earliest First)",
                "Start Date (Latest First)",
                "End Date (Earliest First)",
                "End Date (Latest First)",
                "Activity Type (A-Z)",
                "Activity Type (Z-A)",
                "Subject (A-Z)",
                "Subject (Z-A)"
            };
            SortOption = SortOptions.First();
        }

        public ObservableCollection<ActivityListModel> Activities { get; }

        [ObservableProperty]
        private string searchTerm;

        [ObservableProperty]
        private string sortOption;

        [ObservableProperty]
        private DateTime startDate;

        [ObservableProperty]
        private DateTime endDate;

        [ObservableProperty]
        private string selectedActivityType;

        [ObservableProperty]
        private string subject;

        public ObservableCollection<string> SortOptions { get; }

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
            IEnumerable<ActivityListModel> activities;

            if (string.IsNullOrWhiteSpace(SearchTerm) && StartDate == default && EndDate == default && string.IsNullOrWhiteSpace(SelectedActivityType) && string.IsNullOrWhiteSpace(Subject))
            {
                activities = await _activityFacade.GetAsync();
            }
            else
            {
                activities = await _activityFacade.FilterAsync(SearchTerm, StartDate, EndDate, SelectedActivityType, Subject);
            }

            Activities.Clear();
            foreach (ActivityListModel activity in activities)
            {
                Activities.Add(activity);
            }
        }

        [RelayCommand]
        public void SortActivities()
        {
            var sortedActivities = Activities.ToList();
            switch (SortOption)
            {
                case "Start Date (Earliest First)":
                    sortedActivities = Activities.OrderBy(a => a.StartTime).ToList();
                    break;
                case "Start Date (Latest First)":
                    sortedActivities = Activities.OrderByDescending(a => a.StartTime).ToList();
                    break;
                case "End Date (Earliest First)":
                    sortedActivities = Activities.OrderBy(a => a.EndTime).ToList();
                    break;
                case "End Date (Latest First)":
                    sortedActivities = Activities.OrderByDescending(a => a.EndTime).ToList();
                    break;
                case "Activity Type (A-Z)":
                    sortedActivities = Activities.OrderBy(a => a.ActivityType).ToList();
                    break;
                case "Activity Type (Z-A)":
                    sortedActivities = Activities.OrderByDescending(a => a.ActivityType).ToList();
                    break;
                case "Subject (A-Z)":
                    sortedActivities = Activities.OrderBy(a => a.SubjectId).ToList();
                    break;
                case "Subject (Z-A)":
                    sortedActivities = Activities.OrderByDescending(a => a.SubjectId).ToList();
                    break;
            }
            Activities.Clear();
            foreach (var activity in sortedActivities)
            {
                Activities.Add(activity);
            }
        }
    }
}
