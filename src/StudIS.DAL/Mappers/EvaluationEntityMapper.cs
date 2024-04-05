using StudIS.DAL.Entities;

namespace StudIS.DAL.Mappers;

public class EvaluationEntityMapper : IEntityMapper<EvaluationEntity>
{
    public void MapToExistingEntity(EvaluationEntity existingEntity, EvaluationEntity newEntity)
    {
        existingEntity.Description = newEntity.Description;
        existingEntity.ActivityId = newEntity.ActivityId;
        existingEntity.StudentId = newEntity.StudentId;
    }
}