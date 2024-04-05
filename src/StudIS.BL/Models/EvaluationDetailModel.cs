using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record EvaluationDetailModel : ModelBase
{
    //TODO in our programm there is no Detailed Evaluation needed ,however this could be useful
    public required Guid Id { get; set; }
    public required string? Description { get; set; }
    public required Guid ActivityId { get; set; }
    public required Guid StudentId { get; set; }
    
    public ActivityEntity? Activity { get; init; }
    public StudentEntity? Student { get; init; }
    
    public static EvaluationDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Description = string.Empty,
        ActivityId = Guid.NewGuid(),
        StudentId = Guid.NewGuid()
    };
}