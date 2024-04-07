using System.Collections.ObjectModel;
using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record StudentDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required string? ImageUrl { get; set; }
    
    public ObservableCollection<SubjectEntity> Subjects { get; init; } = new ();

    public static StudentDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        ImageUrl = string.Empty
    };

}