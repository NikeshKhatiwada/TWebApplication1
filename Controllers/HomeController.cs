using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TWebApplicationMVC1.Data;
using TWebApplicationMVC1.Models;

namespace APcts.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private ApplicationDbContext? Context { get; }

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext? applicationDbContext)
    {
        Context = applicationDbContext;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // ViewBag.users = this.Context.Users.ToList();
        /*
        ViewData["UserName"] = users.UserName;
        ViewData["Email"] = users.Email;
        */
        return View(this.Context.Users.ToList());
    }

    /*
    [HttpPost]
    public IActionResult Index(string UserName, string Email)
    {
        Users users = new Users();
        users.UserName = UserName;
        users.Email = Email;
        return View(users);
    }
    */

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            throw new Exception("Item not found");
        }
        var user = this.Context.Users.Find(id);
        return View(user);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
