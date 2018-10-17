using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unity_State.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 using System.IO;

namespace Unity_State.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteContext db;

        public HomeController(SiteContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Catalog()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Register()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult News()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Users()
        {
            ViewData["Message"] = "Users";

            return View(db.Users.OrderBy(b => b.login).ToList());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult User(ClientModel cm)
        {
            
            return View("User",cm);
        }

        public IActionResult CheckEmail(string email)
        {
            if (email == "admin@mail.ru")
                return Json(false);
            else
                return Json(true);
        }

        [HttpPost]
        public IActionResult Create(ClientModel person)
        {
            if (ModelState.IsValid)
            {
                // Успех
            }
            else
            {
                // Неудача
            }

            return View();
        }



        [HttpPost]
        public IActionResult Registration (ClientModel cm)
        {
            Console.WriteLine(cm.login);
            Console.WriteLine(cm.password);
            Console.WriteLine(cm.gender.ToString());
            cm.regDate = DateTime.Now;

            db.Users.Add(cm);
            db.SaveChanges();

            return View("User", cm);
                
        }

    }
}
