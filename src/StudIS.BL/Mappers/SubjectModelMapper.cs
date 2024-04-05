using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class SubjectModelMapper() 
    : ModelMapperBase<SubjectEntity, SubjectListModel, SubjectDetailModel>
{
    public override SubjectListModel MapToListModel(SubjectEntity? entity)
    {
        if (entity == null)
        {
            return SubjectListModel.Empty;
        }

        return new SubjectListModel()
        {
            Id = entity.Id,
            Abbreviation = entity.Abbreviation,
            Name = entity.Name
        };
    }

    public override SubjectDetailModel MapToDetailModel(SubjectEntity? entity)
    {
        if (entity == null)
        {
            return SubjectDetailModel.Empty;
        }

        return new SubjectDetailModel()
        {
            Id = entity.Id,
            Abbreviation = entity.Abbreviation,
            Name = entity.Name,
            //Student = StudentModelMapper.Map//TODO
            //Activity = ActivityModelMapper.Map//TODO
        };
    }

    public override SubjectEntity MapToEntity(SubjectDetailModel model)
    {
        return new SubjectEntity()
        {
            Id = model.Id,
            Abbreviation = model.Abbreviation,
            Name = model.Name,
            //Student = StudentModelMapper.Map//TODO
            //Activity = ActivityModelMapper.Map//TODO
        };
    }
}