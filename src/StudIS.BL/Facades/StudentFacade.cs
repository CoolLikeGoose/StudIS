using Microsoft.EntityFrameworkCore;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Mappers;
using StudIS.BL.Models;
using StudIS.DAL.Entities;
using StudIS.DAL.Mappers;
using StudIS.DAL.UnitOfWork;

namespace StudIS.BL.Facades;

public class StudentFacade(IUnitOfWorkFactory unitOfWorkFactory, StudentModelMapper evaluationModelMapper) 
    : FacadeBase<StudentEntity, StudentListModel, StudentDetailModel, StudentEntityMapper>
        (unitOfWorkFactory, evaluationModelMapper), IStudentFacade
{
    public async Task<IEnumerable<StudentListModel>> GetByName(string studentName)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        List<StudentEntity> entities = await unitOfWork
            .GetRepository<StudentEntity, StudentEntityMapper>()
            .Get()
            .Where(e => (e.FirstName + " " + e.LastName).ToLower().Contains(studentName) ||
                                    (e.LastName + " " + e.FirstName).ToLower().Contains(studentName))
            .ToListAsync()
            .ConfigureAwait(false);

        return ModelMapper.MapToListModel(entities);
    }

    public override async Task<StudentDetailModel?> GetAsync(Guid id)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
    
        IQueryable<StudentEntity> query = unitOfWork.GetRepository<StudentEntity, StudentEntityMapper>().Get();
        query.Include($"{nameof(StudentEntity.Subjects)}.{nameof(StudentsToSubjectsEntity.Subject)}");

        StudentEntity? entity = await query
            .SingleOrDefaultAsync(e => e.Id == id)
            .ConfigureAwait(false);
    
        return entity is null ? null : ModelMapper.MapToDetailModel(entity);
    }
}