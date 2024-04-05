using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class ActivityModelMapper()
    : ModelMapperBase<ActivityEntity, ActivityListModel, ActivityDetailModel>
{
    public override ActivityListModel MapToListModel(ActivityEntity? entity)
    {
        if (entity == null)
        {
            return ActivityListModel.Empty;
        }

        return new ActivityListModel()
        {
            Id = entity.Id,
            Description = entity.Description,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            Room = entity.Room,
            SubjectId = entity.SubjectId
        };

    }

    public override ActivityDetailModel MapToDetailModel(ActivityEntity? entity)
    {
        if (entity == null)
        {
            return ActivityDetailModel.Empty;
        }

        return new ActivityDetailModel()
        {
            Id = entity.Id,
            Description = entity.Description,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            Room = entity.Room,
            SubjectId = entity.SubjectId,
            ActivityType = entity.ActivityType,
            Subject = entity.Subject,
            //Evaluations = EvaluationModelMapper.Map//TODO
        };
    }
    
    public override ActivityEntity MapToEntity(ActivityDetailModel model)
    {
        return new ActivityEntity()
        {
            ActivityType = model.ActivityType,
            Description = model.Description,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            //Evaluations = EvaluationModelMapper.Map//TODO
            Id = model.Id,
            Room = model.Room,
            SubjectId = model.SubjectId,
            Subject = model.Subject
        };
    }
    
    public  ActivityEntity MapToEntity(ActivityListModel model, Guid subjectId)
    {
        throw new NotImplementedException();
    }
    
    public  ActivityEntity MapToEntity(ActivityDetailModel model, Guid subjectId)
    {
        throw new NotImplementedException();
    }
}