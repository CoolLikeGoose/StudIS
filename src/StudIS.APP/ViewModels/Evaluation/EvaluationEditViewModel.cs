using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using StudIS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.APP.ViewModels.Evaluation
{
    public partial class EvaluationEditViewModel : ObservableObject, IViewModel, IQueryAttributable
    {
        private readonly IEvaluationFacade _evaluationFacade;
        private Guid _evaluationId;
        private Guid _studentId;
        private Guid _activityId;
        public EvaluationEditViewModel(IEvaluationFacade evaluationFacade)
        {
            _evaluationFacade = evaluationFacade;
        }

        private EvaluationDetailModel _evaluation;
        public EvaluationDetailModel Evaluation
        {
            get => _evaluation;
            set => SetProperty(ref _evaluation, value);
        }

        public async Task LoadDataAsync()
        {
            if (_evaluationId != Guid.Empty)
            {
                Evaluation = await _evaluationFacade.GetAsync(_evaluationId);
            }
            else
            {
                Evaluation = new EvaluationDetailModel
                {
                    Description = "Default Description",
                    Grade = 0,
                    ActivityId = _activityId,
                    StudentId = _studentId
                };
            }
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("Id"))
            {
                _evaluationId = (Guid)query["Id"];
            }
            if (query.ContainsKey("ActivityId"))
            {
                _activityId = (Guid)query["ActivityId"];
            }
            if (query.ContainsKey("StudentId"))
            {
                _studentId = (Guid)query["StudentId"];
            }
            await LoadDataAsync();
        }

        [RelayCommand]
        private async Task SaveAsync()
        {
            await _evaluationFacade.SaveAsync(Evaluation);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
