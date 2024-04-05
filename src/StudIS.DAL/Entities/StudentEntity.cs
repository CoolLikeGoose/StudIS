using System;
using System.Collections.Generic;

namespace StudIS.DAL.Entities;

public record StudentEntity : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string? ImageUrl { get; set; }
    
    public ICollection<SubjectEntity> Subjects { get; init; } = new List<SubjectEntity>();
}
