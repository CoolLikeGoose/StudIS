using System;
using System.Collections;
using System.Collections.Generic;
using StudIS.Common.Enums;

namespace StudIS.DAL.Entities;

public record ActivityEntity(
    Guid Id,
    DateTime StartTime,
    DateTime EndTime,
    Place Room,
    ActivityType ActivityType,
    string? Description,
    Guid SubjectId) : IEntity
{
    public SubjectEntity? Subject { get; init; }
    public ICollection<EvaluationEntity> Evaluations { get; set; } = new List<EvaluationEntity>();
}