using StudIS.BL.Facades.Interfaces;

namespace StudIS.APP.ViewModels.Subjects;

public class SubjectsEditViewModel(ISubjectFacade subjectFacade) : IViewModel
{
    public Task LoadDataAsync()
    {
        return Task.CompletedTask;
    }
}