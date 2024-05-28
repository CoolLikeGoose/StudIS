using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Subjects;

public partial class SubjectsDetailViewModel : ObservableObject, IViewModel, IQueryAttributable, INotifyPropertyChanged
{
    private readonly ISubjectFacade _subjectFacade;
    private Guid Id { get; set; }

    public SubjectsDetailViewModel(ISubjectFacade subjectFacade)
    {
        _subjectFacade = subjectFacade;
    }

    private SubjectDetailModel _subject;
    public SubjectDetailModel Subject
    {
        get => _subject;
        set => SetProperty(ref _subject, value);
    }

    public async Task LoadDataAsync()
    {
        Subject = await _subjectFacade.GetAsync(Id);
        OnPropertyChanged("Subject");
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Id = (Guid)query["Id"];
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        await _subjectFacade.DeleteAsync(Id);
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