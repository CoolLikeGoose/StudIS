using Microsoft.EntityFrameworkCore;
using StudIS.Common.Tests;
using StudIS.Common.Tests.Seeds; 
using StudIS.DAL.Entities;
using Xunit.Abstractions;

namespace StudIS.DAL.Tests;

public class DbContextStudentTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddOne_Student()
    {
        StudentEntity student = StudentSeeds.BasicStudent;
        
        StudIsDbContextSUT.Students.Add(student);
        await StudIsDbContextSUT.SaveChangesAsync();
        
        await using StudIsDbContext dbContext = await DbContextFactory.CreateDbContextAsync();
        StudentEntity actualStudent= await dbContext.Students.SingleAsync(i => i.Id == student.Id);
        Assert.Equal(student.FirstName,actualStudent.FirstName);
        Assert.Equal(student.ImageUrl,actualStudent.ImageUrl);
    }
    [Fact]
    public async Task Read_Student_By_Id()
    {
        // Arrange
        var student = StudentSeeds.BasicStudent;
        await StudIsDbContextSUT.Students.AddAsync(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Act
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var actualStudent = await dbContext.Students.FindAsync(student.Id);

        // Assert
        Assert.NotNull(actualStudent);
        Assert.Equal(student.Id, actualStudent.Id);
    }

    [Fact]
    public async Task Update_Student()
    {
        // Arrange
        var student = StudentSeeds.BasicStudent;
        await StudIsDbContextSUT.Students.AddAsync(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Act
        student.FirstName = "Updated Name";
        StudIsDbContextSUT.Students.Update(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Assert
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var updatedStudent = await dbContext.Students.FindAsync(student.Id);
        Assert.Equal("Updated Name", updatedStudent.FirstName);
    }

    [Fact]
    public async Task Delete_Student()
    {
        // Arrange
        var student = StudentSeeds.BasicStudent;
        await StudIsDbContextSUT.Students.AddAsync(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Act
        StudIsDbContextSUT.Students.Remove(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Assert
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var deletedStudent = await dbContext.Students.FindAsync(student.Id);
        Assert.Null(deletedStudent);
    }
    
    [Fact]
    public async Task Add_Student_With_Image()
    {
        // Arrange
        var student = new StudentEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            ImageUrl = "http://example.com/john-doe.jpg"
        };

        // Act
        StudIsDbContextSUT.Students.Add(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Assert
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var actualStudent = await dbContext.Students.FindAsync(student.Id);
        Assert.Equal("http://example.com/john-doe.jpg", actualStudent.ImageUrl);
    }

    [Fact]
    public async Task Update_Student_Image()
    {
        // Arrange
        var student = new StudentEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            ImageUrl = "http://example.com/john-doe.jpg"
        };
        StudIsDbContextSUT.Students.Add(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Act
        student.ImageUrl = "http://example.com/john-doe-updated.jpg";
        StudIsDbContextSUT.Students.Update(student);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Assert
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var updatedStudent = await dbContext.Students.FindAsync(student.Id);
        Assert.Equal("http://example.com/john-doe-updated.jpg", updatedStudent.ImageUrl);
    }

    [Fact]
    public async Task Delete_Student_And_Image_Url_Removed()
    {
        StudIsDbContextSUT.Students.Remove(StudentSeeds.StandardInDbStudent);
        await StudIsDbContextSUT.SaveChangesAsync();

        // Assert
        await using var dbContext = await DbContextFactory.CreateDbContextAsync();
        var deletedStudent = await dbContext.Students.FindAsync(StudentSeeds.StandardInDbStudent.Id);
        Assert.Null(deletedStudent);
    }
}