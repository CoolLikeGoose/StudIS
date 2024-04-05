using StudIS.BL.Facades;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Models;
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
}