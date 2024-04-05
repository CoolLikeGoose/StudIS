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
    //Method for updating existing activity by subject ID
    // public async Task SaveAsync(ActivityListModel activityListModel, Guid subjectId)
    // {
    //     ActivityEntity entity = activityModelMapper.MapToEntity(activityListModel, subjectId);
    //
    //     await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
    //     IRepository<ActivityEntity> repository = unitOfWork.GetRepository<ActivityEntity, ActivityEntityMapper>();
    //
    //     if (await repository.ExistsAsync(entity))
    //     {
    //         await repository.UpdateAsync(entity);
    //         await unitOfWork.CommitAsync();
    //     }
    // }
    
    //Method for adding new activity by subject ID
    // public async Task SaveAsync(ActivityDetailModel activityDetailModel, Guid subjectId)
    // {
    //     ActivityEntity entity = activityModelMapper.MapToEntity(activityDetailModel, subjectId);
    //
    //     await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
    //     IRepository<ActivityEntity> repository = unitOfWork.GetRepository<ActivityEntity, ActivityEntityMapper>();
    //
    //     repository.Insert(entity);
    //     await unitOfWork.CommitAsync();
    // }
}