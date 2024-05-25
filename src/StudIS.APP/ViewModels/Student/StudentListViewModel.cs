using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Student;

public partial class StudentListViewModel (IStudentFacade studentFacade): IViewModel
{
    public IEnumerable<StudentListModel> Students { get; set; } = null!;

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task LoadDataAsync()
    {
        Students = await studentFacade.GetAsync();
    }
}