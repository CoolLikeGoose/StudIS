using System;
using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;

public static class EvaluationSeeds
{
    public static readonly EvaluationEntity BasicEvaluation = new EvaluationEntity()
    {
        Id = Guid.Parse("e5b05c91-b092-4064-afa5-da1aeb0e4028"),
        Description = "example description",
        ActivityId = ActivitySeeds.BasicActivity.Id,
        StudentId = StudentSeeds.BasicStudent.Id
    };
    
    public static readonly EvaluationEntity StandardInDbEvaluation = new EvaluationEntity()
    {
        Id = Guid.Parse("fda29883-79e8-44cb-bc1c-570efe779cfa"),
        Description = "example description",
        ActivityId = ActivitySeeds.StandardInDbActivity.Id,
        StudentId = StudentSeeds.StandardInDbStudent.Id
    };
    
    public static readonly EvaluationEntity DeleteTestInDbEval = new EvaluationEntity()
    {
        Id = Guid.Parse("014aa0d1-2145-44cb-9244-139a7fdc6fba"),
        Description = "example description",
        ActivityId = ActivitySeeds.StandardInDbActivity.Id,
        StudentId = StudentSeeds.StandardInDbStudent.Id
    };
    
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvaluationEntity>().HasData(
            StandardInDbEvaluation,
            DeleteTestInDbEval
        );
    }
}