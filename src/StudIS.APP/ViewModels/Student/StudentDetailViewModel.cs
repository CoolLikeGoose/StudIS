using StudIS.BL.Facades.Interfaces;

namespace StudIS.APP.ViewModels.Student;

public class StudentDetailViewModel(IStudentFacade studentFacade) : IViewModel
{
    public Task LoadDataAsync()
    {
        return Task.CompletedTask;
    }
}