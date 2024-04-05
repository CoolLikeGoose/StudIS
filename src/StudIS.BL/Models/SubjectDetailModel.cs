using System.Collections.ObjectModel;
using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record SubjectDetailModel : ModelBase
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Abbreviation { get; set; }
    public ObservableCollection<ActivityEntity> Activities { get; init; } = new ();
    public ObservableCollection<StudentEntity> Students { get; init; } = new ();
    
    public static SubjectDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Abbreviation = string.Empty
    };
}