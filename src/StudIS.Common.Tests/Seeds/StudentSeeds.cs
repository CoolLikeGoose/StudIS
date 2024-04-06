using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.Common.Tests.Seeds;
public static class StudentSeeds
{
    //TODO: update this later
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
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            StandardInDbStudent
        );
    }
}