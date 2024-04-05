using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class ActivityModelMapper
    : ModelMapperBase<ActivityEntity, ActivityListModel, ActivityDetailModel>
{
    public override ActivityListModel MapToListModel(ActivityEntity? entity)
    {
        throw new NotImplementedException();
    }

    public override ActivityDetailModel MapToDetailModel(ActivityEntity entity)
    {
        throw new NotImplementedException();
    }

    public override ActivityEntity MapToEntity(ActivityDetailModel model)
    {
        throw new NotImplementedException();
    }
}