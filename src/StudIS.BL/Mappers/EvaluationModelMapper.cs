using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class EvaluationModelMapper
    : ModelMapperBase<EvaluationEntity, EvaluationListModel, EvaluationDetailModel>
{
    public override EvaluationListModel MapToListModel(EvaluationEntity? entity)
    {
        throw new NotImplementedException();
    }

    public override EvaluationDetailModel MapToDetailModel(EvaluationEntity entity)
    {
        throw new NotImplementedException();
    }

    public override EvaluationEntity MapToEntity(EvaluationDetailModel model)
    {
        throw new NotImplementedException();
    }
}