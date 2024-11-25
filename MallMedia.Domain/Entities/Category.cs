namespace MallMedia.Domain.Entities;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public bool Status  { get; set; }
    public ICollection<Content>? Contents { get; set; }
}
