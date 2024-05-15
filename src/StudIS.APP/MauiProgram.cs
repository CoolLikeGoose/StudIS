using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using StudIS.BL;
using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.DAL;
using StudIS.DAL.Migrator;
using StudIS.DAL.Options;

namespace StudIS.APP;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services
            .AddDalServices(new DALOptions()
            {
                DatabaseDirectory = FileSystem.AppDataDirectory,
                DatabaseName = "StudIS.db",
                RecreateDatabaseOnStartup = false,
                SeedDemoData = false
            })
            .AddAppServices()
            .AddBlServices();
        
        var app = builder.Build();
        
        app.Services.GetRequiredService<IDbMigrator>().Migrate();
        
        return app;
    }
}