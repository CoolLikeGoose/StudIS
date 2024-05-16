using System.Collections.ObjectModel;
using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record StudentDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required Uri? ImageUrl { get; set; }
    
    public ICollection<SubjectListModel> Subjects { get; init; } = new List<SubjectListModel>();

    public static StudentDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        ImageUrl = new Uri("example.example")
    };

}