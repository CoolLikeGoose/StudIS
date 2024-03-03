﻿using StudIS.DAL.Entities;
using StudIS.Common.Enums;
using Microsoft.EntityFrameworkCore;
namespace StudIS.Common.Tests.Seeds;

public static class EvaluationSeeds
{
    public static readonly EvaluationEntity EmptyEvaluation = new(
        default,
        default,
        default,
        default
    );

    public static readonly EvaluationEntity BasicEvaluation = new(
        Guid.Parse("e5b05c91-b092-4064-afa5-da1aeb0e4028"),
        "example description",
        ActivitySeeds.BasicActivity.Id,
        StudentSeeds.BasicStudent.Id);
    
    // public static readonly EvaluationEntity MultipleSubjectStudentEvaluation = new(
    //     Guid.Parse("e5dc71e1-c526-478c-97d0-d029129d5c8d"),
    //     "example description",
    //     ActivitySeeds.EvaluationActivity.Id,
    //     StudentSeeds.MultiipleSubjectsStudent.Id
    // )
    // {
    //     Activity = ActivitySeeds.EvaluationActivity,
    //     Student = StudentSeeds.MultiipleSubjectsStudent
    // };
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<EvaluationEntity>().HasData(
        //     BasicEvaluation with { Activity = null!, Student = null!}
        // );
    }
}