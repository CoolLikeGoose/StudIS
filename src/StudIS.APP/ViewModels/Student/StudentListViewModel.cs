using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
            // await Shell.Current.GoToAsync("/create");
        }

        [RelayCommand]
        public async Task GoToDetailAsync()
        {
            await Shell.Current.GoToAsync("detail");
        }
    }
}