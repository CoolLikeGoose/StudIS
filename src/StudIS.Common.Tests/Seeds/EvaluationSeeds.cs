using StudIS.DAL.Entities;
using StudIS.Common.Enums;
using Microsoft.EntityFrameworkCore;
namespace StudIS.Common.Tests.Seeds;

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
    
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvaluationEntity>().HasData(
            StandardInDbEvaluation
        );
    }
}