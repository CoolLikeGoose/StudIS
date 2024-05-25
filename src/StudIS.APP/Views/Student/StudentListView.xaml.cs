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
    
    protected override async void OnAppearing()
    {
        await ViewModel.LoadDataAsync();
    }
}