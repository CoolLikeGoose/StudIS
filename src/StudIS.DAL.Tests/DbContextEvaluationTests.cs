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
}