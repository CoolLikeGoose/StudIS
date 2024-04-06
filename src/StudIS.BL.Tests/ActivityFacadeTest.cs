using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using StudIS.Common.Enums;
using StudIS.Common.Tests;
using StudIS.DAL.Entities;

namespace StudIS.BL.Tests;


public class ActivityFacadeTest : FacadeTestBase
{
    private readonly IActivityFacade _activityFacadeSUT;

    public ActivityFacadeTest()
    { 
        _activityFacadeSUT = new ActivityFacade(UnitOfWorkFactory, ActivityModelMapper);
    }
    
    [Fact]
    public async Task CreateEntity()
    {
        ActivityDetailModel s = new ActivityDetailModel()
        {
            Id = Guid.NewGuid(),
            StartTime = DateTime.Today,
            EndTime = DateTime.Today,
            Room = Place.D105,
            ActivityType = ActivityType.Exam,
            Description = "Example Description",
            SubjectId = Guid.NewGuid()
        };

        await _activityFacadeSUT.SaveAsync(s);
    }
}
