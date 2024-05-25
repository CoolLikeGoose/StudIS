using System;
using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;
public static class StudentSeeds
{
    public static readonly StudentEntity BasicStudent = new StudentEntity()
    {
        Id = Guid.NewGuid(),
        Name = "Daniil",
        ImageUrl = "https://examplepicture.example"
    };
    
    public static readonly StudentEntity StandardInDbStudent = new StudentEntity()
    {
        Id = Guid.NewGuid(),
        Name = "Nikola",
        ImageUrl = "https://examplepicture.example"
    };
    
    public static readonly StudentEntity StandardInDbStudent2 = new StudentEntity()
    {
        Id = Guid.NewGuid(),
        Name = "NeNikola",
        ImageUrl = "https://api.hub.jhu.edu/factory/sites/default/files/styles/soft_crop_1300/public/depression-hub.jpg"
    };
    
    public static readonly StudentEntity StandardInDbStudent3 = new StudentEntity()
    {
        Id = Guid.NewGuid(),
        Name = "alokiN",
        ImageUrl = "https://domf5oio6qrcr.cloudfront.net/medialibrary/7813/a83db567-4c93-4ad0-af6f-72b57af7675d.jpg"
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            StandardInDbStudent with { Subjects = null! },
            StandardInDbStudent2 with { Subjects = null! },
            StandardInDbStudent3  with { Subjects = null! }
        );
    }
}