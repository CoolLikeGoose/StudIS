using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record EvaluationListModel : ModelBase
{
    public required Guid Id { get; set; }
    public required string? Description { get; set; }
    public required Guid ActivityId { get; set; }
    public required Guid StudentId { get; set; }
    
    public ActivityEntity? Activity { get; init; }
    public StudentEntity? Student { get; init; }
    
    public static EvaluationListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Description = string.Empty,
        ActivityId = Guid.NewGuid(),
        StudentId = Guid.NewGuid()
    };
}