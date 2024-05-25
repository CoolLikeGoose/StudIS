using System;
using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity BasicSubject = new SubjectEntity()
    {
        Id = Guid.Parse("e5dc71e1-c526-478c-97d0-d029129d5c8d"),
        Name = "mathematics analysis",
        Abbreviation = "ima1"
    };

    public static SubjectEntity SubjectUpdateTest = new SubjectEntity()
    {
        Id = Guid.Parse("15ed62ae-6ec5-4643-9dd8-4f6e5e0b0a0e"),
        Name = "mathematic analysis 2",
        Abbreviation = "ima2"
    };
    
    public static SubjectEntity StandardInDbSubject = new SubjectEntity()
    {
        Id = Guid.Parse("668299f7-8a85-48eb-90ba-4a033757bc72"),
        Name = "database system",
        Abbreviation = "ids"
    };
    
    public static SubjectEntity SubjectEmpty = new SubjectEntity()
    {
        Id = Guid.Parse("0e4b9e16-02e8-4e71-b4c0-2253669ab8e2"),
        Name = string.Empty,
        Abbreviation = string.Empty
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectEntity>().HasData(
            SubjectUpdateTest with { Activities = null!, Students = null! },
            StandardInDbSubject with { Activities = null!, Students = null! },
            SubjectEmpty with { Activities = null!, Students = null! }
        );
    }
}