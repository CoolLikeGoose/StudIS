using System;
using Microsoft.EntityFrameworkCore;
using StudIS.Common.Enums;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity StandardInDbActivity1 = new ActivityEntity()
    {
        Id = Guid.NewGuid(),
        StartTime = new DateTime(2023, 10, 10, 10, 10, 10),
        EndTime = new DateTime(2023, 11, 11, 11, 11, 11),
        Room = Place.D105,
        ActivityType = ActivityType.Exam,
        Description = "example description",
        SubjectId = SubjectSeeds.StandardInDbSubject1.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject1
    };
    
    public static readonly ActivityEntity StandardInDbActivity2 = new ActivityEntity()
    {
        Id = Guid.NewGuid(),
        StartTime = new DateTime(2023, 10, 10, 10, 10, 10),
        EndTime = new DateTime(2023, 11, 11, 11, 11, 11),
        Room = Place.D105,
        ActivityType = ActivityType.Exam,
        Description = "EXAM description",
        SubjectId = SubjectSeeds.StandardInDbSubject2.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject1
    };
    
    public static readonly ActivityEntity StandardInDbActivity3 = new ActivityEntity()
    {
        Id = Guid.NewGuid(),
        StartTime = new DateTime(2023, 10, 10, 10, 10, 10),
        EndTime = new DateTime(2023, 11, 11, 11, 11, 11),
        Room = Place.Laboratory,
        ActivityType = ActivityType.Exercise,
        Description = "Lab description",
        SubjectId = SubjectSeeds.StandardInDbSubject1.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject1
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityEntity>().HasData(
            StandardInDbActivity1 with { Subject = null, Evaluations = null!},
            StandardInDbActivity2 with { Subject = null, Evaluations = null!},
            StandardInDbActivity3 with { Subject = null, Evaluations = null!}
        );
    }
}