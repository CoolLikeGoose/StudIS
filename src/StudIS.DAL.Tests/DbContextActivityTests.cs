using Microsoft.EntityFrameworkCore;
using StudIS.Common.Tests.Seeds;
using StudIS.DAL.Entities;
using Xunit.Abstractions;

namespace StudIS.DAL.Tests;

public class DbContextActivityTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddOne_Activity()
    {   
        // SubjectEntity subject = SubjectSeeds.BasicSubject;
        // ActivityEntity activity = ActivitySeeds.BasicActivity;
        //
        // StudIsDbContextSUT.Activities.Add(activity);
        // StudIsDbContextSUT.Subjects.Add(subject);
        // await StudIsDbContextSUT.SaveChangesAsync();
        //
        // await using StudIsDbContext dbContext = await DbContextFactory.CreateDbContextAsync();
        // ActivityEntity actualActivity= await dbContext.Activities.SingleAsync(i => i.Id == activity.Id);
        // Assert.Equal(activity.StartTime, actualActivity.StartTime);
        // Assert.Equal(activity.EndTime,actualActivity.EndTime);
        // Assert.Equal(activity.Room,actualActivity.Room);
        // Assert.Equal(activity.ActivityType,actualActivity.ActivityType);
    }
}