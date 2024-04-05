using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Mappers;

public class StudentModelMapper
    : ModelMapperBase<StudentEntity, StudentListModel, StudentDetailModel>
{
    public override StudentListModel MapToListModel(StudentEntity? entity)
    {
        throw new NotImplementedException();
    }

    public override StudentDetailModel MapToDetailModel(StudentEntity entity)
    {
        throw new NotImplementedException();
    }

    public override StudentEntity MapToEntity(StudentDetailModel model)
    {
        throw new NotImplementedException();
    }
}