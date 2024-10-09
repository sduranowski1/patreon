namespace aspapi.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Foreign Key
    // Foreign Key (optional Author)
    public int? AuthorId { get; set; }

    // Optional Navigation Properties
    public User? Author { get; set; }

    // Optional PostCategories and PostTags, initialize collections to avoid null reference issues
    public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();

    public string? ImageFileName { get; set; }
}
