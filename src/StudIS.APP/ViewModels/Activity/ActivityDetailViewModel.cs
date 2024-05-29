using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Activity
{
    public partial class ActivityDetailViewModel : IViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        private readonly IActivityFacade _activityFacade;
        private readonly IEvaluationFacade _evaluationFacade;
        private Guid Id { get; set; }
    
        public ActivityDetailModel? Activity { get; set; }
        public ObservableCollection<EvaluationListModel> Evaluations{ get; } = new();
        
        public ActivityDetailViewModel(IActivityFacade activityFacade, IEvaluationFacade evaluationFacade)
        {
            _activityFacade = activityFacade;
            _evaluationFacade = evaluationFacade;
        }


        public async Task LoadDataAsync()
        {
            Activity = await _activityFacade.GetAsync(Id);
            OnPropertyChanged(nameof(Activity));
            IEnumerable<EvaluationListModel> evaluations = await _evaluationFacade.GetAsync();
            Evaluations.Clear();
            foreach (EvaluationListModel evaluation in evaluations)
            {
                Evaluations.Add(evaluation);
            }
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = (Guid)query["Id"];
            await LoadDataAsync();
        }
        [RelayCommand]
        private async Task DeleteAsync()
        {
            await _activityFacade.DeleteAsync(Id);
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private async Task EditAsync()
        {
            await Shell.Current.GoToAsync("edit", new Dictionary<string, object> { { "Id", Id } });
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [RelayCommand]
        private async Task GoToCreateAsync()
        {
            await Shell.Current.GoToAsync("edit");
        }

        [RelayCommand]
        private async Task GoToDeleteAsync()
        {
            await Shell.Current.GoToAsync("delete");
        }
    }
}