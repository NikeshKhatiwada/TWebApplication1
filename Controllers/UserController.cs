using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using TWebApplicationMVC1.Data;
using TWebApplicationMVC1.Models;
using static System.Net.WebRequestMethods;

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
                Email = u.Email,
                BirthDate = u.BirthDate
            };
            this.Context.Users.Add(users);
            this.Context.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult Update(Users u)
        {
            Users users = this.Context.Users.Find(u.Id);
            users.FirstName = u.FirstName;
            users.LastName = u.LastName;
            users.UserName = u.UserName;
            users.Email = u.Email;
            users.BirthDate = u.BirthDate;
            this.Context.Users.Update(users);
            this.Context.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult UpdateImage(int Id, IFormFile Image)
        {
            string uploadPath = Path.Combine(".\\wwwroot" , "Images");
            // Directory.CreateDirectory(uploadPath);
            string filePath = Path.Combine(uploadPath, Image.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                Image.CopyTo(fileStream);
            }
            /*
            MemoryStream stream = new MemoryStream();
            Image.CopyTo(stream);
            */
            Users users = this.Context.Users.Find(Id);
            string deletePath = Path.Combine(".\\wwwroot", "Images");
            string fileDeletePath = Path.Combine(uploadPath, users.Image);
            FileInfo deleteFile = new FileInfo(fileDeletePath);
            if (deleteFile.Exists)
            {
                deleteFile.Delete();
            }
            // users.Image = stream.ToArray();
            users.Image = Image.FileName;
            this.Context.Users.Update(users);
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
