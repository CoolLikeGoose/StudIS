using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Student;

public partial class StudentListViewModel (IStudentFacade studentFacade)
{
    public List<StudentListModel> Students { get; set; } = new()
    {
        new StudentListModel()
        {
            Id = Guid.NewGuid(),
            Name = "Stud1"
        },
        new StudentListModel()
        {
            Id = Guid.NewGuid(),
            Name = "Stud2"
        },
        new StudentListModel()
        {
            Id = Guid.NewGuid(),
            Name = "Stud3"
        }
    };

    private void GoToDetail()
    {
        // Shell.Current.GoToAsync("");
    }
}