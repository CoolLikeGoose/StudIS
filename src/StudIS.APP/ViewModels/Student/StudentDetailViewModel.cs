using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Student;

public partial class StudentDetailViewModel(IStudentFacade studentFacade) : ObservableObject, IViewModel, IQueryAttributable, INotifyPropertyChanged
{
    private Guid Id { get; set; }

    private StudentDetailModel _student;

    public StudentDetailModel Student
    {
        get => _student;
        set => SetProperty(ref _student, value);
    }
    
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

    [RelayCommand]
    private async Task DeleteAsync()
    {
        await studentFacade.DeleteAsync(Id);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task EditAsync()
    {
        await Shell.Current.GoToAsync("edit", new Dictionary<string, object> { { "Id", Id } });
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}