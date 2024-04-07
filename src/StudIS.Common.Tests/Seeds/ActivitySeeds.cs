using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;
using StudIS.Common.Enums;
using Xunit.Sdk;

namespace StudIS.Common.Tests.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity BasicActivity = new ActivityEntity()
    {
        Id = Guid.Parse("444c4c52-0a68-4f4a-88f9-02f190b92232"),
        StartTime = new DateTime(2023, 10, 10, 10, 10, 10),
        EndTime = new DateTime(2023, 11, 11, 11, 11, 11),
        Room = Place.D105,
        ActivityType = ActivityType.Exam,
        Description = "example description",
        SubjectId = SubjectSeeds.BasicSubject.Id
    };
    
    public static readonly ActivityEntity StandardInDbActivity = new ActivityEntity()
    {
        Id = Guid.Parse("d40b7f6a-a653-43e2-b02c-61b34bba7561"),
        StartTime = new DateTime(2023, 10, 10, 10, 10, 10),
        EndTime = new DateTime(2023, 11, 11, 11, 11, 11),
        Room = Place.D105,
        ActivityType = ActivityType.Exam,
        Description = "EXAM description",
        SubjectId = SubjectSeeds.StandardInDbSubject.Id
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityEntity>().HasData(
            StandardInDbActivity
        );
    }
}