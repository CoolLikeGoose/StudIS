using Microsoft.EntityFrameworkCore;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Mappers;
using StudIS.BL.Models;
using StudIS.DAL.Entities;
using StudIS.DAL.Mappers;
using StudIS.DAL.UnitOfWork;

namespace StudIS.BL.Facades;

public class SubjectFacade(IUnitOfWorkFactory unitOfWorkFactory, SubjectModelMapper subjectModelMapper) 
    : FacadeBase<SubjectEntity, SubjectListModel, SubjectDetailModel, SubjectEntityMapper>
        (unitOfWorkFactory, subjectModelMapper), ISubjectFacade
{
    public async Task<IEnumerable<SubjectListModel>> GetByName(string subjectName)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        List<SubjectEntity> entities = await unitOfWork
            .GetRepository<SubjectEntity, SubjectEntityMapper>()
            .Get()
            .Where(e => e.Name.Contains(subjectName))
            .ToListAsync()
            .ConfigureAwait(false);

        return ModelMapper.MapToListModel(entities);
    }
}