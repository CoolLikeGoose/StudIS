using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;
using StudIS.Common.Enums;
namespace StudIS.Common.Tests.Seeds;

public static class ActivitySeeds
{
    //TODO: update this later
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
    //
    // public static readonly ActivityEntity NoEvaluationActivity1 = new(
    //     Guid.Parse("278b9b40-e08b-4f0e-a317-e7952cd178ec"),
    //     new DateTime(2023,11,11,11,11,11),
    //     new DateTime(2023,12,12,12,12,12),
    //     Place.D105,
    //     ActivityType.Exam,
    //     "example description",
    //     SubjectSeeds.MultipleActivitySubject.Id
    // )
    // {
    //     Subject = SubjectSeeds.MultipleActivitySubject
    // };
    //
    // public static readonly ActivityEntity NoEvaluationActivity2 = new(
    //     Guid.Parse("5f1297bb-6b90-4bec-badc-457be502ddb9"),
    //     new DateTime(2023,11,11,11,11,11),
    //     new DateTime(2023,12,12,12,12,12),
    //     Place.D105,
    //     ActivityType.Exam,
    //     "example description",
    //     SubjectSeeds.MultipleActivityMultipleStudentSubject.Id
    // )
    // {
    //     Subject = SubjectSeeds.MultipleActivityMultipleStudentSubject
    // };
    //
    // public static readonly ActivityEntity NoEvaluationActivity3 = new(
    //     Guid.Parse("f3a59126-e713-40d1-ac02-911fb440e0a6"),
    //     new DateTime(2023,11,11,11,11,11),
    //     new DateTime(2023,12,12,12,12,12),
    //     Place.D105,
    //     ActivityType.Exam,
    //     "example description",
    //     SubjectSeeds.MultipleActivityMultipleStudentSubject.Id
    // )
    // {
    //     Subject = SubjectSeeds.MultipleActivityMultipleStudentSubject
    // };
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityEntity>().HasData(
            StandardInDbActivity
        );
    }
}