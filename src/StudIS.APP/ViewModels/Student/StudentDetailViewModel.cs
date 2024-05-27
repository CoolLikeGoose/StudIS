using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Student;

public partial class StudentDetailViewModel(IStudentFacade studentFacade) : IViewModel, IQueryAttributable, INotifyPropertyChanged
{
    private Guid Id { get; set; }
    
    public StudentDetailModel? Student { get; set; }
    
    public async Task LoadDataAsync()
    {
        Student = await studentFacade.GetAsync(Id);
        OnPropertyChanged("Student");
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Id = (Guid)query["Id"];
        await LoadDataAsync();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}