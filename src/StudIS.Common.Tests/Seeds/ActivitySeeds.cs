using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;
using StudIS.Common.Enums;
namespace StudIS.Common.Tests.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity EmptyActivity = new(
        default,
        default,
        default,
        default,
        default,
        default,
        default
    )
    {
        
    };
    public static readonly ActivityEntity NoEvaluationActivity = new(
        Guid.Parse("444c4c52-0a68-4f4a-88f9-02f190b92232"),
        new DateTime(2023,10,10,10,10,10),
        new DateTime(2023,11,11,11,11,11),
        Place.D105,
        ActivityType.Exam,
        "example description",
        SubjectSeeds.OneActivitySubject.Id
    )
    {
        Subject = SubjectSeeds.OneActivitySubject
    };
    
    public static readonly ActivityEntity EvaluationActivity = new(
        Guid.Parse("ec3d3915-7667-4cd9-b39e-0f98210707d0"),
        new DateTime(2023,11,11,11,11,11),
        new DateTime(2023,12,12,12,12,12),
        Place.D105,
        ActivityType.Exam,
        "example description",
        SubjectSeeds.MultipleActivitySubject.Id
    )
    {
        Subject = SubjectSeeds.MultipleActivitySubject,
        Evaluations = new List<EvaluationEntity>(){EvaluationSeeds.MultipleSubjectStudentEvaluation}
    };
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityEntity>().HasData(
            NoEvaluationActivity,
            EvaluationActivity
        );
    }
}