namespace StudIS.BL.Models;

public record StudentListModel : ModelBase
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public static StudentListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty
    };
}