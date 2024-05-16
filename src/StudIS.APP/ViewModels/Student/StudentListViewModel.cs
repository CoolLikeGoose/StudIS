using System.Diagnostics;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Student;

public partial class StudentListViewModel (IStudentFacade studentFacade): IViewModel
{
    public IEnumerable<StudentListModel> Students { get; set; } = null!;

    private void GoToDetail()
    {
        // Shell.Current.GoToAsync("");
    }

    public async Task LoadDataAsync()
    {
        Students = await studentFacade.GetAsync();
    }
}