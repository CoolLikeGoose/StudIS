using System;
using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;

public static class EvaluationSeeds
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
        StudentSeeds.MultiipleSubjectsStudent.Id
    )
    {
        Activity = ActivitySeeds.EvaluationActivity,
        Student = StudentSeeds.MultiipleSubjectsStudent
    };
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvaluationEntity>().HasData(
            MultipleSubjectStudentEvaluation
        );
    }
}