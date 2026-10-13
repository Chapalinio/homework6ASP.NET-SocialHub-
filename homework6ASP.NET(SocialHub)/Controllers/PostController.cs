using lesson6_ASP.NET.Context;
using lesson6_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PostController : Controller
{
    private readonly AppDbContext _context;

    public PostController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string? author)
    {
        var posts = _context.Posts.OrderByDescending(p => p.CreatedAt).ToList();
        
        if (!string.IsNullOrEmpty(author))
        {
            posts = posts.Where(p => p.Author == author).OrderByDescending(p => p.CreatedAt).ToList();
        }

        return View(posts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
        post.CreatedAt = DateTime.Now;

        _context.Add(post);
        _context.SaveChanges();
        return Redirect("/Post/Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Id == id);
        
        return View(post);
    }

    [HttpPost]
    public IActionResult Edit(Post post)
    {
        _context.Posts.Remove(_context.Posts.FirstOrDefault(p => p.Id == post.Id));
        
        post.CreatedAt = DateTime.Now;
        _context.Posts.Add(post);
        _context.SaveChanges();
        
        return Redirect("/Post/Index");
    }


    public IActionResult Details(int? id)
    {
        var post = _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);

        return View(post);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        return View(_context.Posts.FirstOrDefault(p => p.Id == id));
    }

    [HttpPost]
    public IActionResult Delete(Post post)
    {
        _context.Posts.Remove(post);
        _context.SaveChanges();
        return Redirect("/Post/Index");
    }
}
