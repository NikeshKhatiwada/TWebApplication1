using Microsoft.AspNetCore.Mvc;
using TWebApplicationMVC1.Data;
using TWebApplicationMVC1.Models;

namespace TWebApplicationMVC1.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext Context { get; }

        public UserController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpPost]
        public IActionResult Insert(Users u)
        {
            Users users = new Users()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email
            };
            this.Context.Users.Add(users);
            this.Context.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult Update(Users u)
        {
            this.Context.Users.Update(u);
            this.Context.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult Delete(Users u)
        {
            this.Context.Remove(u);
            this.Context.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}
