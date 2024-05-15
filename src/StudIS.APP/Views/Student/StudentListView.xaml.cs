using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.APP.ViewModels.Student;

namespace StudIS.APP.Views.Student;

public partial class StudentListView : ContentPage
{
    protected StudentListViewModel ViewModel { get; }
    
    public StudentListView(StudentListViewModel listViewModel)
    {
        ViewModel = listViewModel;
        BindingContext = listViewModel;

        InitializeComponent();
    }

    private void OnAddStudentClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnSearchClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnSortClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected override async void OnAppearing()
    {
        await ViewModel.LoadDataAsync();
    }
}