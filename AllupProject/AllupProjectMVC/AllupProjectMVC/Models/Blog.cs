namespace AllupProjectMVC.Models;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageUrl { get; set; }
    public string ShortDescription { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; }
}
