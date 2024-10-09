namespace aspapi.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation Property
    public ICollection<PostCategory> PostCategories { get; set; }
}
