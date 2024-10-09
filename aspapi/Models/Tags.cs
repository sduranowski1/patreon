namespace aspapi.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation Property
    public ICollection<PostTag> PostTags { get; set; }
}
