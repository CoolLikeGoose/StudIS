using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Activity
{
    public partial class ActivityDetailViewModel : IViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        private readonly IActivityFacade _activityFacade;
        private Guid Id { get; set; }
    
        public ActivityDetailModel? Activity { get; set; }

        public ActivityDetailViewModel(IActivityFacade activityFacade)
        {
            _activityFacade = activityFacade;
        }

        public async Task LoadDataAsync()
        {
            Activity = await _activityFacade.GetAsync(Id);
            OnPropertyChanged(nameof(Activity));
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = (Guid)query["Id"];
            await LoadDataAsync();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}