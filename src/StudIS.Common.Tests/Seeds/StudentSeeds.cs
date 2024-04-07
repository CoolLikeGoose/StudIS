using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.Common.Tests.Seeds;
public static class StudentSeeds
{
    public static readonly StudentEntity BasicStudent = new StudentEntity()
    {
        Id = Guid.Parse("18b4e5b0-098f-4daa-889e-d0616d97cddf"),
        Name = "Daniil",
        ImageUrl = new Uri("https://examplepicture.example")
    };
    
    public static readonly StudentEntity StandardInDbStudent = new StudentEntity()
    {
        Id = Guid.Parse("70a0d2bf-14ad-4e92-9f08-8acde154b911"),
        Name = "Nikola",
        ImageUrl = new Uri("https://examplepicture.example")
    };
    public static StudentEntity StudentEmpty = new StudentEntity()
    {
        Id = Guid.Parse("c4b3795a-f6ba-49c8-b011-be212ec6a1e8"),
        Name = String.Empty,
        ImageUrl = new Uri("https://examplepicture.example")
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            StandardInDbStudent,
            StudentEmpty
        );
    }
}