using System.Collections.ObjectModel;
using StudIS.DAL.Entities;

namespace StudIS.BL.Models;

public record StudentDetailModel : ModelBase
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string? ImageUrl { get; set; }
    
    public ICollection<SubjectListModel> Subjects { get; init; } = new List<SubjectListModel>();

    public static StudentDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        FirstName = string.Empty,
        LastName = string.Empty,
        ImageUrl = string.Empty
    };

}