using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using System.Collections.ObjectModel;

namespace StudIS.APP.ViewModels.Student
{
    public partial class StudentListViewModel(IStudentFacade studentFacade) : IViewModel
    {
        public ObservableCollection<StudentListModel> Students { get; } = new();

        public async Task LoadDataAsync()
        {
            IEnumerable<StudentListModel> students = await studentFacade.GetAsync();
            Students.Clear();
            foreach (StudentListModel student in students)
            {
                Students.Add(student);
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
            await Shell.Current.GoToAsync("detail", new Dictionary<string, object>(){{"Id", id}});
        }

        [RelayCommand]
        public async Task SearchAsync(Guid id)
        {
            IEnumerable<StudentListModel> students = await studentFacade.GetByName("Nikola");
            Students.Clear();
            foreach (StudentListModel student in students)
            {
                Students.Add(student);
            }
        }
    }
}