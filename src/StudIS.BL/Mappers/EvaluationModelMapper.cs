using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class EvaluationModelMapper()
    : ModelMapperBase<EvaluationEntity, EvaluationListModel, EvaluationDetailModel>
{
    public override EvaluationListModel MapToListModel(EvaluationEntity? entity)
    {
        if (entity == null)
        {
            return EvaluationListModel.Empty;
        }

        return new EvaluationListModel()
        {
            Activity = entity.Activity,
            ActivityId = entity.ActivityId,
            Description = entity.Description,
            Id = entity.Id,
            StudentId = entity.StudentId,
            Student = entity.Student
        };
    }

    public override EvaluationDetailModel MapToDetailModel(EvaluationEntity? entity)
    {
        if (entity == null)
        {
            return EvaluationDetailModel.Empty;
        }

        return new EvaluationDetailModel()
        {
            Id = entity.Id,
            Activity = entity.Activity,
            ActivityId = entity.ActivityId,
            Description = entity.Description,
            Student = entity.Student,
            StudentId = entity.StudentId
        };
    }

    public override EvaluationEntity MapToEntity(EvaluationDetailModel model)
    {
        return new EvaluationEntity()
        {
            Id = model.Id,
            ActivityId = model.ActivityId,
            Activity = model.Activity,
            Description = model.Description,
            StudentId = model.StudentId,
            Student = model.Student
        };
    }
}