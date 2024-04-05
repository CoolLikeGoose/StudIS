using Microsoft.EntityFrameworkCore;
using StudIS.Common.Tests.Seeds; 
using StudIS.DAL.Entities;
using Xunit.Abstractions;

namespace StudIS.DAL.Tests;

public class DbContextEvaluationTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddOne_Evaluation()
    {
        SubjectEntity subject = SubjectSeeds.BasicSubject;
        ActivityEntity activity = ActivitySeeds.BasicActivity;
        EvaluationEntity evaluation = EvaluationSeeds.BasicEvaluation;
        StudentEntity student = StudentSeeds.BasicStudent;
        
        StudIsDbContextSUT.Subjects.Add(subject);
        StudIsDbContextSUT.Students.Add(student);
        StudIsDbContextSUT.Activities.Add(activity);
        StudIsDbContextSUT.Evaluations.Add(evaluation);
        await StudIsDbContextSUT.SaveChangesAsync();
        
        await using StudIsDbContext dbContext = await DbContextFactory.CreateDbContextAsync();
        EvaluationEntity actualEvaluation= await dbContext.Evaluations.SingleAsync(i => i.Id == evaluation.Id);
        Assert.Equal(evaluation.Id,actualEvaluation.Id);
        Assert.Equal(evaluation.Description,actualEvaluation.Description);
        Assert.Equal(evaluation.ActivityId,actualEvaluation.ActivityId);
        Assert.Equal(evaluation.StudentId,actualEvaluation.StudentId);
    }
    //TODO
    // [Fact]
    // public async Task Read_Evaluation_With_Related_Entities()
    // {
    //     
    //     var evaluation = EvaluationSeeds.BasicEvaluation;
    //
    //     // Act
    //     await using var dbContext = await DbContextFactory.CreateDbContextAsync();
    //     var actualEvaluation = await dbContext.Evaluations
    //         .Include(e => e.Activity)
    //         .Include(e => e.Student)
    //         .SingleOrDefaultAsync(i => i.Id == evaluation.Id); 
    //
    //     // Assert
    //     Assert.NotNull(actualEvaluation);
    //     Assert.Equal(evaluation.Description, actualEvaluation.Description);
    //     Assert.NotNull(actualEvaluation.Activity);
    //     Assert.NotNull(actualEvaluation.Student);
    // }
    [Fact]
    public async Task Update_Evaluation()
    {
        // Arrange
        var evaluation = EvaluationSeeds.BasicEvaluation;
        StudIsDbContextSUT.Evaluations.Add(evaluation);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Act
        var updatedDescription = "Updated Evaluation Description";
        evaluation.Description = updatedDescription;
        StudIsDbContextSUT.Evaluations.Update(evaluation);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Assert
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var updatedEvaluation = await dbContext.Evaluations.FindAsync(evaluation.Id);
        Assert.NotNull(updatedEvaluation);
        Assert.Equal(updatedDescription, updatedEvaluation.Description);
    }
    //TODO
    // [Fact]
    // public async Task Delete_Evaluation()
    // {
    //     // Arrange
    //     var evaluation = EvaluationSeeds.BasicEvaluation;
    //     StudIsDbContextSUT.Evaluations.Add(evaluation);
    //     await StudIsDbContextSUT.SaveChangesAsync();
    //
    //     // Act
    //     StudIsDbContextSUT.Evaluations.Remove(evaluation);
    //     await StudIsDbContextSUT.SaveChangesAsync();
    //
    //     // Assert
    //     await using var dbContext = await DbContextFactory.CreateDbContextAsync();
    //     var deletedEvaluation = await dbContext.Evaluations.FindAsync(evaluation.Id);
    //     Assert.Null(deletedEvaluation);
    // }
}