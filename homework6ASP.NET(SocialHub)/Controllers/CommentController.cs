using lesson6_ASP.NET.Context;
using lesson6_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

public class CommentController : Controller
{
    private readonly AppDbContext _context;

    public CommentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create(int postId)
    {
        var comment = new Comment { PostId = postId };
        return View(comment);
    }

    [HttpPost]
    public IActionResult Create(Comment comment)
    {
        comment.CreatedAt = DateTime.Now;

        _context.Add(comment);
        _context.SaveChanges();
        return Redirect("/Post/Details/" + comment.PostId);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        return View(comment);
    }

    [HttpPost]
    public IActionResult Delete(Comment comment)
    {
        _context.Comments.Remove(comment);
        _context.SaveChanges();

        return Redirect("/Post/Details/" + comment.PostId);
    }
}
