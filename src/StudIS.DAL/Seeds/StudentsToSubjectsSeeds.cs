using System;
using Microsoft.EntityFrameworkCore;
using StudIS.DAL.Entities;

namespace StudIS.DAL.Seeds;

public static class StudentsToSubjectsSeeds
{
    public static readonly StudentsToSubjectsEntity Stud1ToSubj1 = new StudentsToSubjectsEntity()
    {
        Id = Guid.NewGuid(),
        
        SubjectId = SubjectSeeds.StandardInDbSubject1.Id,
        StudentId = StudentSeeds.StandardInDbStudent1.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject1,
        Student = StudentSeeds.StandardInDbStudent1
    };
    
    public static readonly StudentsToSubjectsEntity Stud2ToSubj1 = new StudentsToSubjectsEntity()
    {
        Id = Guid.NewGuid(),
        
        SubjectId = SubjectSeeds.StandardInDbSubject1.Id,
        StudentId = StudentSeeds.StandardInDbStudent2.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject1,
        Student = StudentSeeds.StandardInDbStudent2
    };
    
    public static readonly StudentsToSubjectsEntity Stud3ToSubj1 = new StudentsToSubjectsEntity()
    {
        Id = Guid.NewGuid(),
        
        SubjectId = SubjectSeeds.StandardInDbSubject1.Id,
        StudentId = StudentSeeds.StandardInDbStudent3.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject1,
        Student = StudentSeeds.StandardInDbStudent3
    };
    
    public static readonly StudentsToSubjectsEntity Stud3ToSubj2 = new StudentsToSubjectsEntity()
    {
        Id = Guid.NewGuid(),
        
        SubjectId = SubjectSeeds.StandardInDbSubject2.Id,
        StudentId = StudentSeeds.StandardInDbStudent3.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject2,
        Student = StudentSeeds.StandardInDbStudent3
    };
    
    public static readonly StudentsToSubjectsEntity Stud2ToSubj2 = new StudentsToSubjectsEntity()
    {
        Id = Guid.NewGuid(),
        
        SubjectId = SubjectSeeds.StandardInDbSubject2.Id,
        StudentId = StudentSeeds.StandardInDbStudent2.Id,
        
        Subject = SubjectSeeds.StandardInDbSubject2,
        Student = StudentSeeds.StandardInDbStudent2
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityEntity>().HasData(
            Stud1ToSubj1 with { Subject = null!, Student = null!},
            Stud2ToSubj1 with { Subject = null!, Student = null!},
            Stud3ToSubj1 with { Subject = null!, Student = null!},
            Stud3ToSubj2 with { Subject = null!, Student = null!},
            Stud2ToSubj2 with { Subject = null!, Student = null!}
        );
    }
}