using System;
using StudIS.Common.Enums;

namespace StudIS.DAL.Entities;

public record ActivityEntity(
    Guid Id,
    DateTime StartTime,
    DateTime EndTime,
    Place Room,
    ActivityType ActivityType,
    string? Description,
    Guid SubjectId,
    Guid EvaluationId) : IEntity
{
    public SubjectEntity? Subject { get; init; }
    public EvaluationEntity? Evaluation { get; init; } //poeben' kakayato
}