using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using System.Collections.ObjectModel;

namespace StudIS.APP.ViewModels.Subjects
{
    public partial class SubjectsListViewModel(ISubjectFacade subjectFacade) : IViewModel
    {
        public ObservableCollection<SubjectListModel> Subjects { get; } = new();

        public async Task LoadDataAsync()
        {
            IEnumerable<SubjectListModel> subjects = await subjectFacade.GetAsync();
            Subjects.Clear();
            foreach (SubjectListModel subject in subjects)
            {
                Subjects.Add(subject);
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
            await Shell.Current.GoToAsync("detail", new Dictionary<string, object>() { { "Id", id } });
        }

        [RelayCommand]
        public async Task SearchAsync()
        {
            IEnumerable<SubjectListModel> subjects = await subjectFacade.GetByName("Physics"); // Example search query
            Subjects.Clear();
            foreach (SubjectListModel subject in subjects)
            {
                Subjects.Add(subject);
            }
        }
    }
}