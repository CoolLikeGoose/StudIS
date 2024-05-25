using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using System.Collections.ObjectModel;

namespace StudIS.APP.ViewModels.Student
{
    public partial class StudentListViewModel : IViewModel
    {
        private readonly IStudentFacade _studentFacade;

        public StudentListViewModel(IStudentFacade studentFacade)
        {
            _studentFacade = studentFacade;
            Students = new ObservableCollection<StudentListModel>();
        }

        public ObservableCollection<StudentListModel> Students { get; }

        public async Task LoadDataAsync()
        {
            IEnumerable<StudentListModel> students = await _studentFacade.GetAsync();
            Students.Clear();
            foreach (StudentListModel student in students)
            {
                Students.Add(student);
            }
        }

        [RelayCommand]
        private async Task GoToCreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}