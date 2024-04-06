using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StudIS.Common.Enums;
using StudIS.Common.Tests.Seeds; 
using StudIS.DAL.Entities;
using Xunit.Abstractions;

namespace StudIS.DAL.Tests;

public class DbContextActivityTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddOne_Activity()
    {   
        SubjectEntity subject = SubjectSeeds.BasicSubject;
        ActivityEntity activity = ActivitySeeds.BasicActivity;
        
        StudIsDbContextSUT.Activities.Add(activity);
        StudIsDbContextSUT.Subjects.Add(subject);
        await StudIsDbContextSUT.SaveChangesAsync();
        
        await using StudIsDbContext dbContext = await DbContextFactory.CreateDbContextAsync();
        ActivityEntity actualActivity= await dbContext.Activities.SingleAsync(i => i.Id == activity.Id);
        Assert.Equal(activity.StartTime, actualActivity.StartTime);
        Assert.Equal(activity.EndTime,actualActivity.EndTime);
        Assert.Equal(activity.Room,actualActivity.Room);
        Assert.Equal(activity.ActivityType,actualActivity.ActivityType);
    }
    [Fact]
    public async Task Read_Activity_By_Id()
    {
        // Arrange
        var activity = ActivitySeeds.BasicActivity;
        StudIsDbContextSUT.Activities.Add(activity);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Act
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var actualActivity = await dbContext.Activities.FindAsync(activity.Id);

        // Assert
        Assert.NotNull(actualActivity);
        Assert.Equal(activity.Id, actualActivity.Id);
    }

     // [Fact]
     // public async Task Update_Activity()
     // {
     //     // Arrange
     //     var activity = ActivitySeeds.BasicActivity;
     //     StudIsDbContextSUT.Activities.Add(activity);
     //     await StudIsDbContextSUT.SaveChangesAsync();
     //     var newEndTime = activity.EndTime.AddHours(1);
     //
     //     // Act
     //     activity.EndTime = newEndTime;
     //     StudIsDbContextSUT.Activities.Update(activity);
     //     await StudIsDbContextSUT.SaveChangesAsync();
     //
     //     // Assert
     //     await using var dbContext = await DbContextFactory.CreateDbContextAsync();
     //     var updatedActivity = await dbContext.Activities.FindAsync(activity.Id);
     //     Assert.Equal(newEndTime, updatedActivity.EndTime);
     // }
   
     [Fact]
      public async Task Delete_Activity()
      {
          // Arrange
          var activity = ActivitySeeds.BasicActivity;
          StudIsDbContextSUT.Activities.Add(activity);
          await StudIsDbContextSUT.SaveChangesAsync();
    
          // Act
          StudIsDbContextSUT.Activities.Remove(activity);
          await StudIsDbContextSUT.SaveChangesAsync();
    
          // Assert
          await using var dbContext = await DbContextFactory.CreateDbContextAsync();
          var deletedActivity = await dbContext.Activities.FindAsync(activity.Id);
          Assert.Null(deletedActivity);
      }
   
     [Fact]
     public async Task Validate_Activity_Time_Interval()
     {
         // Arrange
         var invalidActivity = new ActivityEntity
         {
             Id = Guid.NewGuid(),
             StartTime = DateTime.Now,
             EndTime = DateTime.Now.AddHours(-1), // Некорректный временной интервал
             Room = Place.D105,
             ActivityType = ActivityType.Exam,
             Description = "A test activity with invalid time interval.",
             SubjectId = Guid.NewGuid()
         };
    
         // Act & Assert
         await Assert.ThrowsAsync<DbUpdateException>(() => 
         {
             StudIsDbContextSUT.Activities.Add(invalidActivity);
             return StudIsDbContextSUT.SaveChangesAsync();
         });
         
         //Assert.IsType<DbUpdateException>(ex);
     }


}