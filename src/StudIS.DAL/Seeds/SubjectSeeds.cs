using System;
using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity StandardInDbSubject1 = new SubjectEntity()
    {
        Id = Guid.NewGuid(),
        Name = "mathematics analysis",
        Abbreviation = "ima1"
    };

    public static SubjectEntity StandardInDbSubject2 = new SubjectEntity()
    {
        Id = Guid.NewGuid(),
        Name = "mathematic analysis 2",
        Abbreviation = "ima2"
    };
    
    public static SubjectEntity StandardInDbSubject3 = new SubjectEntity()
    {
        Id = Guid.NewGuid(),
        Name = "database system",
        Abbreviation = "ids"
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectEntity>().HasData(
            StandardInDbSubject1 with { Activities = null!, Students = null! },
            StandardInDbSubject2 with { Activities = null!, Students = null! },
            StandardInDbSubject3 with { Activities = null!, Students = null! }
        );
    }
}