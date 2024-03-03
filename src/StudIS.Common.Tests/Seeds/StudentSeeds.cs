using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.Common.Tests.Seeds;
public static class StudentSeeds
{
    public static readonly StudentEntity EmptyStudent = new(
        default,
        default!,
        default
    )
    {
        
    };
    public static readonly StudentEntity StudentNoSubject = new(
        Guid.Parse("18b4e5b0-098f-4daa-889e-d0616d97cddf"),
        "Daniil",
        "https://examplepicture.example")
    {
        
    };
    
    public static readonly StudentEntity StudentOneSubject = new(
        Guid.Parse("7c58da0c-fecc-4a26-b541-b07e9310c6b2"),
        "Nikita",
        "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQ8QqJaYvO9Lj7t81qs89f4RZgEdoX2Ae3hfFcuWt2N-amqfrHy99Zt75yZ96ti0-cXz2P2pNQ-vWJ1WinQXQfhQWafihWM_x62j1r-TA")
    {
        Subjects = new List<SubjectEntity>(){SubjectSeeds.NoActivitySubject}
    };
    
    public static readonly StudentEntity StudentMultiipleSubjects = new(
        Guid.Parse("8cb4c7e9-96c6-4460-a86d-c89d636c151c"),
        "Nikola",
        "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRJ6IDtr0L7Zu6ESyMN11axgYybXs2GkM2ISA7jdL4iOqDbNIn0")
    {
        Subjects = new List<SubjectEntity>(){SubjectSeeds.NoActivitySubject,SubjectSeeds.OneActivitySubject,SubjectSeeds.MultipleActivitySubject}
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            StudentNoSubject,
            StudentOneSubject,
            StudentMultiipleSubjects
        );
    }
}