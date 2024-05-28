using Microsoft.EntityFrameworkCore;
using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Mappers;
using StudIS.BL.Models;
using StudIS.DAL.Entities;
using StudIS.DAL.Mappers;
using StudIS.DAL.UnitOfWork;

namespace StudIS.BL.Facades
{
    public class ActivityFacade(IUnitOfWorkFactory unitOfWorkFactory, ActivityModelMapper activityModelMapper) 
        : FacadeBase<ActivityEntity, ActivityListModel, ActivityDetailModel, ActivityEntityMapper>
            (unitOfWorkFactory, activityModelMapper), IActivityFacade
    {
        public async Task<IEnumerable<ActivityListModel>> GetByName(string activityName)
        {
            await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
            List<ActivityEntity> entities = await unitOfWork
                .GetRepository<ActivityEntity, ActivityEntityMapper>()
                .Get()
                .Where(e => e.Description.Contains(activityName))
                .ToListAsync()
                .ConfigureAwait(false);

            return ModelMapper.MapToListModel(entities);
        }
    }
}