using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using StudIS.Common.Tests;
using StudIS.DAL.Entities;

namespace StudIS.BL.Tests;

public class SubjectFacadeTest : FacadeTestBase
{
    private readonly ISubjectFacade _subjectFacadeSUT;
    
    public SubjectFacadeTest()
    {
        _subjectFacadeSUT = new SubjectFacade(UnitOfWorkFactory, SubjectModelMapper);
    }
    
    [Fact]
    public async Task CreateEntity()
    {
        SubjectDetailModel s = new SubjectDetailModel()
        {
            Id = Guid.NewGuid(),
            Name = "Math",
            Abbreviation = "IMA"
        };

        await _subjectFacadeSUT.SaveAsync(s);
    }
    
    [Fact]
    public async Task DeleteEntity()
    {
        SubjectDetailModel s = new SubjectDetailModel()
        {
            Id = Guid.NewGuid(),
            Name = "Math",
            Abbreviation = "IMA"
        };

        await _subjectFacadeSUT.SaveAsync(s);
        await _subjectFacadeSUT.DeleteAsync(s.Id);
    }
    
    [Fact]
    public async Task UpdateGetEntity()
    {
        SubjectDetailModel s = new SubjectDetailModel()
        {
            Id = Guid.NewGuid(),
            Name = "Math",
            Abbreviation = "IMA"
        };
        await _subjectFacadeSUT.SaveAsync(s);
        SubjectDetailModel sUpdated = s with
        {
            Name = "Logika",
        };
        await _subjectFacadeSUT.SaveAsync(sUpdated);
        SubjectDetailModel actualSubject = await _subjectFacadeSUT.GetAsync(sUpdated.Id);
        Assert.Equal(s.Abbreviation, actualSubject.Abbreviation);
        Assert.NotEqual(s.Name,actualSubject.Name);
    }
    
    [Fact]
    public async Task DeleteNonExistingEntity()
    {
        SubjectDetailModel s = new()
        {
            Id = Guid.NewGuid(),
            Name = string.Empty,
            Abbreviation = string.Empty
        };

        await _subjectFacadeSUT.SaveAsync(s);
        await _subjectFacadeSUT.DeleteAsync(s.Id);
        SubjectDetailModel actualSubject = await _subjectFacadeSUT.GetAsync(s.Id);
        Assert.Null(actualSubject);
    }
    
    [Fact]
    public async Task GetByNonExistingIdEntity()
    {
        Guid Id = Guid.Empty;
        
        SubjectDetailModel actualSubject = await _subjectFacadeSUT.GetAsync(Id);
        Assert.Null(actualSubject);
    }
}