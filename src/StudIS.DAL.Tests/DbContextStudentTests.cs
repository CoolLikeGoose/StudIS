using Microsoft.EntityFrameworkCore;
using StudIS.Common.Tests.Seeds;
using StudIS.DAL.Entities;
using Xunit.Abstractions;

namespace StudIS.DAL.Tests;

public class DbContextStudentTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task TestingOfTests()
    {
        StudentEntity studentId = StudentSeeds.BasicStudent;
        
        StudIsDbContextSUT.Students.Add(studentId);
        await StudIsDbContextSUT.SaveChangesAsync();

        await using StudIsDbContext dbxContext = await DbContextFactory.CreateDbContextAsync();
        StudentEntity actualdbxContext= await dbxContext.Students.SingleAsync(i => i.Id == studentId.Id);
        Assert.Equal(studentId.Id,actualdbxContext.Id);
    }
}