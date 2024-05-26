using StudIS.BL.Facades.Interfaces;

namespace StudIS.APP.ViewModels.Student;

public class StudentEditViewModel(IStudentFacade studentFacade) : IViewModel
{
    public Task LoadDataAsync()
    {
        return Task.CompletedTask;
    }
}