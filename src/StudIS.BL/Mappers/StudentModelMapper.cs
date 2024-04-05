using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class StudentModelMapper()
    : ModelMapperBase<StudentEntity, StudentListModel, StudentDetailModel>
{
    public override StudentListModel MapToListModel(StudentEntity? entity)
    {
        if (entity == null)
        {
            return StudentListModel.Empty;
        }

        return new StudentListModel()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public override StudentDetailModel MapToDetailModel(StudentEntity? entity)
    {
        if (entity == null)
        {
            return StudentDetailModel.Empty;
        }

        return new StudentDetailModel()
        {
            Id = entity.Id,
            ImageUrl = entity.ImageUrl,
            Name = entity.Name,
            //Subject = SubjectModelMapper.Map//TODO
        };
    }

    public override StudentEntity MapToEntity(StudentDetailModel model)
    {
        return new StudentEntity()
        {
            Id = model.Id,
            ImageUrl = model.ImageUrl,
            Name = model.Name,
            //Subject = SubjectModelMapper.Map//TODO
        };
    }
}