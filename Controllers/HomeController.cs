using FilActualite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilActualite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MesNews()
        {
            var user = db.Users.Where(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
            var categorie = db.Categories.Find(user.CategorieId);
            ViewBag.cat = categorie.Nom;
            Console.WriteLine(categorie.Nom);
            return View();
        }
    }
}