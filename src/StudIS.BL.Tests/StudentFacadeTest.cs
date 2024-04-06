using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
using StudIS.Common.Tests;
using StudIS.DAL.Entities;

namespace StudIS.BL.Tests;

public class StudentFacadeTest : FacadeTestBase
{
    private readonly IStudentFacade _studentFacadeSUT;

    public StudentFacadeTest()
    {
        _studentFacadeSUT = new StudentFacade(UnitOfWorkFactory, StudentModelMapper);
    }
    
    [Fact]
    public async Task CreateEntity()
    {
        StudentDetailModel s = new StudentDetailModel()
        {
            Id = Guid.NewGuid(),
            Name = "Bogdan",
            ImageUrl = "https://shorturl.at/ALMZ4"
        };

        await _studentFacadeSUT.SaveAsync(s);
    }
    
    [Fact]
    public async Task DeleteEntity()
    {
        StudentDetailModel s = new StudentDetailModel()
        {
            Id = Guid.NewGuid(),
            Name = "Bogdan",
            ImageUrl = "https://shorturl.at/ALMZ4"
        };

        await _studentFacadeSUT.SaveAsync(s);
        await _studentFacadeSUT.DeleteAsync(s.Id);

    }
    
    [Fact]
    public async Task UpdateEntity()
    {
        StudentDetailModel s = new StudentDetailModel()
        {
            Id = Guid.NewGuid(),
            Name = "Bogdan",
            ImageUrl = "https://shorturl.at/ALMZ4"
        };
        StudentDetailModel StratingStudent = await _studentFacadeSUT.SaveAsync(s);
        StudentDetailModel sUpdated = s with
        {
            Name = "Daniil",
        };
        StudentDetailModel UpdatedStudent = await _studentFacadeSUT.SaveAsync(sUpdated);
        StudentDetailModel actualStudent = await _studentFacadeSUT.GetAsync(sUpdated.Id);
        Assert.Equal(s.ImageUrl,actualStudent.ImageUrl);
        Assert.NotEqual(s.Name,actualStudent.Name);

    }
}