using homework6ASP.NET_SocialHub_.Models;
using lesson6_ASP.NET.Context;
using Microsoft.AspNetCore.Mvc;

namespace homework6ASP.NET_SocialHub_.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        var userToCkeck = _context.Users.FirstOrDefault(u => u.Username == user.Username); 

        if(userToCkeck != null)
        {
            TempData["Error"] = "Користувач з таким ім'ям вже існує, придумайте інше ім'я.";
            return Redirect("/Account/AccountError");
        }

        _context.Users.Add(user);
        _context.SaveChanges();

        return Redirect("/Account/Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        var userToCkeck = _context.Users.FirstOrDefault(u => u.Username == user.Username);
        
        if (userToCkeck == null)
        {
            TempData["Error"] = "Користувача з таким ім'ям не знайдено, спробуйте ще раз.";
            return Redirect("/Account/AccountError");
        }

        if(userToCkeck.Password != user.Password)
        {
            TempData["Error"] = "Пароль не співпадає, спробуйте ще.";
            return Redirect("/Account/AccountError");
        }

        Response.Cookies.Append("Username", user.Username);

        return Redirect("/Post/Index");
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("Username");
        return Redirect("/Account/Login");
    }
    
    public IActionResult AccountError()
    {
        return View();
    }

}
