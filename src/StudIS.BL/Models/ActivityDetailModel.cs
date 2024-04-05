using StudIS.Common.Enums;
using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record ActivityDetailModel : ModelBase
{
    public required Guid Id { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required Place Room { get; set; }
    public required ActivityType ActivityType { get; set; }
    public required string? Description { get; set; }
    public required Guid SubjectId { get; set; }
    
    public SubjectEntity? Subject { get; init; }
    public ICollection<EvaluationEntity> Evaluations { get; init; } = new List<EvaluationEntity>();
    
    public static ActivityDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StartTime = DateTime.Now,
        EndTime = DateTime.Now,
        Room = Place.Other,
        ActivityType = ActivityType.Exercise,
        Description = string.Empty,
        SubjectId = Guid.NewGuid()
    };
}