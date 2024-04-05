using Microsoft.EntityFrameworkCore;
using StudIS.Common.Tests.Seeds; 
using StudIS.DAL.Entities;
using Xunit.Abstractions;

namespace StudIS.DAL.Tests;

public class DbContextSubjectTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddOne_Subject()
    {
        SubjectEntity subject = SubjectSeeds.BasicSubject;
        
        StudIsDbContextSUT.Subjects.Add(subject);
        await StudIsDbContextSUT.SaveChangesAsync();
        
        await using StudIsDbContext dbContext = await DbContextFactory.CreateDbContextAsync();
        SubjectEntity actualSubject= await dbContext.Subjects.SingleAsync(i => i.Id == subject.Id);
        Assert.Equal(subject.Name,actualSubject.Name);
        Assert.Equal(subject.Abbreviation,actualSubject.Abbreviation);
    }

    [Fact]
    public async Task Update_subject()
    {
        SubjectEntity subject = SubjectSeeds.SubjectUpdateTest;
    
        SubjectEntity subjectUpdated = subject with
        {
            Abbreviation = subject.Abbreviation + "Update"
        };

        StudIsDbContextSUT.Subjects.Update(subjectUpdated);
        await StudIsDbContextSUT.SaveChangesAsync();
        
        await using StudIsDbContext dbContext = await DbContextFactory.CreateDbContextAsync();
        SubjectEntity actualSubject = await dbContext.Subjects.SingleAsync(i => i.Id == subject.Id);
        Assert.Equal(subject.Name,actualSubject.Name);
        Assert.Equal(subjectUpdated.Abbreviation,actualSubject.Abbreviation);
    }
}