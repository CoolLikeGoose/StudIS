using System;
using System.Collections.Generic;

namespace StudIS.DAL.Entities;

public record SubjectEntity(
    Guid Id,
    string Name,
    string Abbreviation) : IEntity
{
    public ICollection<ActivityEntity> Activities { get; init; } = new List<ActivityEntity>();
    public ICollection<StudentEntity> Students { get; init; } = new List<StudentEntity>();
}