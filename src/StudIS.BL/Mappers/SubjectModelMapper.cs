using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class SubjectModelMapper() 
    : ModelMapperBase<SubjectEntity, SubjectListModel, SubjectDetailModel>
{
    public override SubjectListModel MapToListModel(SubjectEntity? entity)
    {
        throw new NotImplementedException();
    }

    public override SubjectDetailModel MapToDetailModel(SubjectEntity entity)
    {
        throw new NotImplementedException();
    }

    public override SubjectEntity MapToEntity(SubjectDetailModel model)
    {
        throw new NotImplementedException();
    }
}