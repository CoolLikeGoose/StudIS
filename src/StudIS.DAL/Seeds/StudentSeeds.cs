using System;
using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;
public static class StudentSeeds
{
    public static readonly StudentEntity BasicStudent = new StudentEntity()
    {
        Id = Guid.Parse("18b4e5b0-098f-4daa-889e-d0616d97cddf"),
        Name = "Daniil",
        ImageUrl = "https://examplepicture.example"
    };
    
    public static readonly StudentEntity StandardInDbStudent = new StudentEntity()
    {
        Id = Guid.Parse("70a0d2bf-14ad-4e92-9f08-8acde154b911"),
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
        Id = Guid.Parse("70a0d2bf-14ad-4e92-9f08-8acde154b911"),
        Name = "alokiN",
        ImageUrl = "https://domf5oio6qrcr.cloudfront.net/medialibrary/7813/a83db567-4c93-4ad0-af6f-72b57af7675d.jpg"
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            StandardInDbStudent,
            StandardInDbStudent2,
            StandardInDbStudent3
        );
    }
}