using System.Collections.ObjectModel;
using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record SubjectDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required string Abbreviation { get; set; }
    public ICollection<ActivityListModel> Activities { get; init; } = new List<ActivityListModel>();
    public ICollection<StudentListModel> Students { get; init; } = new List<StudentListModel>();
    
    public static SubjectDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Abbreviation = string.Empty
    };
}