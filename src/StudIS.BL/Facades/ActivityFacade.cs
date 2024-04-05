using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Mappers;
using StudIS.BL.Models;
using StudIS.DAL.Entities;
using StudIS.DAL.Mappers;
using StudIS.DAL.Repositories;
using StudIS.DAL.UnitOfWork;

namespace StudIS.BL.Facades;

public class ActivityFacade(IUnitOfWorkFactory unitOfWorkFactory, ActivityModelMapper activityModelMapper) 
    : FacadeBase<ActivityEntity, ActivityListModel, ActivityDetailModel, ActivityEntityMapper>
        (unitOfWorkFactory, activityModelMapper), IActivityFacade
{
    //TODO maybe add save for ListModel 
    public async Task SaveAsync(ActivityDetailModel activityDetailModel, Guid subjectId)
    {
        ActivityEntity entity = activityModelMapper.MapToEntity(activityDetailModel, subjectId);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository = unitOfWork.GetRepository<ActivityEntity, ActivityEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }
}