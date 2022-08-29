using System.Diagnostics;
using System.Drawing;
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
        // Dictionary<int, string> Img = new Dictionary<int, string>();
        // ViewBag.users = this.Context.Users.ToList();
        /*
        ViewData["UserName"] = users.UserName;
        ViewData["Email"] = users.Email;
        */
        /*
        foreach (Users users in this.Context.Users)
        {
            String img = "";
            if(users.Image != null)
            {
                img = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(users.Image));
            }
            Img.Add(users.Id, img);
        }
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
