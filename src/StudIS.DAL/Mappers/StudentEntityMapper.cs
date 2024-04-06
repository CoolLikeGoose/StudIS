using StudIS.DAL.Entities;

namespace StudIS.DAL.Mappers;

public class StudentEntityMapper : IEntityMapper<StudentEntity>
{
    public void MapToExistingEntity(StudentEntity existingEntity, StudentEntity newEntity)
    {
        existingEntity.Name = newEntity.Name;
        existingEntity.ImageUrl = existingEntity.ImageUrl;
    }
}