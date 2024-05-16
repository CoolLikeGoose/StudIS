using StudIS.APP.ViewModels.Student;
using StudIS.APP.Views;
using StudIS.APP.Views.Activities;
using StudIS.APP.Views.Student;
using StudIS.APP.Views.Subjects;

namespace StudIS.APP;

public static class AppInstaller
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        //Add here views
        services.AddTransient<ActivitiesListView>();
        services.AddTransient<StudentListView>();
        services.AddTransient<SubjectsListView>();
        
        //add here view models
        services.AddTransient<StudentListViewModel>();
        
        return services;
    }
}