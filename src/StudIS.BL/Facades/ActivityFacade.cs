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
    
}