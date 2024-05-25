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
        private Task GoToCreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}