using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels.Subjects;

public partial class SubjectsDetailViewModel(ISubjectFacade subjectFacade) : IViewModel, IQueryAttributable, INotifyPropertyChanged
{
    private Guid Id { get; set; }

    public SubjectDetailModel? Subject { get; set; }

    public async Task LoadDataAsync()
    {
        Subject = await subjectFacade.GetAsync(Id);
        OnPropertyChanged("Subject");
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