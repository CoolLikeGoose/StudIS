using System;
using System.Collections.Generic;

namespace StudIS.DAL.Entities;

public record StudentEntity(
    Guid Id,
    string Name,
    string? ImageUrl) : IEntity
{
    public ICollection<SubjectEntity> Subjects { get; init; } = new List<SubjectEntity>();
}
