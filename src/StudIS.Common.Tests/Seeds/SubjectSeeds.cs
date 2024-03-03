namespace StudIS.Common.Tests.Seeds;
using StudIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
public static class SubjectSeeds
{
    public static readonly SubjectEntity EmptySubject = new(
        default,
        default!,
        default!
    )
    {
        
    };
    public static readonly SubjectEntity NoActivitySubject = new(
        Guid.Parse("e5dc71e1-c526-478c-97d0-d029129d5c8d"),
        "mathematic analysis",
        "ima1"
    )
    {
        Students = new List<StudentEntity>(){StudentSeeds.StudentMultiipleSubjects,StudentSeeds.StudentOneSubject}
    };

    public static readonly SubjectEntity OneActivitySubject = new(
        Guid.Parse("c78d79bc-74a1-4b7d-90c3-45b833f3e6f1"),
        "mathematic analysis 2",
        "ima2"
    )
    {
        Students = new List<StudentEntity>(){StudentSeeds.StudentMultiipleSubjects},
        Activities = new List<ActivityEntity>(){ActivitySeeds.NoEvaluationActivity}
    };
    public static readonly SubjectEntity MultipleActivitySubject = new(
        Guid.Parse("89848ab3-669a-469e-b7cd-60d689c26723"),
        "database system",
        "ids"
    )
    {
        Students = new List<StudentEntity>(){StudentSeeds.StudentMultiipleSubjects},
        Activities = new List<ActivityEntity>(){ActivitySeeds.NoEvaluationActivity,ActivitySeeds.EvaluationActivity}
    };
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectEntity>().HasData(
            NoActivitySubject,
            OneActivitySubject,
            MultipleActivitySubject
        );
    }
}