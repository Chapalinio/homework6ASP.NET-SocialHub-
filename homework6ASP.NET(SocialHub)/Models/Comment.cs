using homework6ASP.NET_SocialHub_.Models;

namespace lesson6_ASP.NET.Models;

public class Comment
{
    public int Id { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }
}
