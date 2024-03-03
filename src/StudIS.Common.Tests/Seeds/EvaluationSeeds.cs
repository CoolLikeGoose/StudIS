using StudIS.DAL.Entities;
using StudIS.Common.Enums;
namespace StudIS.Common.Tests.Seeds;

public class EvaluationSeeds
{
    public static readonly EvaluationEntity EmptyEvaluation = new(
        default,
        default,
        default,
        default
    )
    {

    };
    
    public static readonly EvaluationEntity MultipleSubjectStudentEvaluation = new(
        Guid.Parse("e5dc71e1-c526-478c-97d0-d029129d5c8d"),
        "example description",
        ActivitySeeds.EvaluationActivity.Id,
        StudentSeeds.StudentMultiipleSubjects.Id
    )
    {
        Activity = ActivitySeeds.EvaluationActivity,
        Student = StudentSeeds.StudentMultiipleSubjects
    };
}