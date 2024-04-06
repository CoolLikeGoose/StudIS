namespace StudIS.BL.Models;

public record StudentListModel : ModelBase
{
    public required string Name { get; set; }
    public static StudentListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty
    };
}