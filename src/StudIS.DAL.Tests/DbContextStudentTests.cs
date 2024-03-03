using Microsoft.EntityFrameworkCore;
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
        Assert.Equal(student.Name,actualStudent.Name);
        Assert.Equal(student.ImageUrl,actualStudent.ImageUrl);
    }
}