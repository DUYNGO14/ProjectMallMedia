namespace MallMedia.Domain.Entities;

public class Content
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<Media> Media { get; set; }

    public string Status { get; set; } = "UNUSED";

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }
    public User? CreatedByUser { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool isDefault { get; set; } = false;
}
