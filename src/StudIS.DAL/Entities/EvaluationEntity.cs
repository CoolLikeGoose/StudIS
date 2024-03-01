using System;

namespace StudIS.DAL.Entities;

public record EvaluationEntity(
    Guid Id,
    string? Description,
    Guid ActivityId,
    Guid StudentId) : IEntity
{
    public ActivityEntity? Activity { get; init; }
    public StudentEntity? Student { get; init; }
}