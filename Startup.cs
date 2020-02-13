using FilActualite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Diagnostics;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(FilActualite.Startup))]
namespace FilActualite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsersandCategories();
        }

        private void createRolesandUsersandCategories()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
           
            if (context.Categories.Where(c => c.Nom == "Sport").Any() == false)
            {
                var Categorie = new Categorie();
                Categorie.Nom = "Sport";
                Categorie.Id = Guid.NewGuid();
                context.Categories.Add(Categorie);
                context.SaveChanges();
            }
            if (context.Categories.Where(c => c.Nom == "Economie").Any() == false)
            {
                var Categorie = new Categorie();
                Categorie.Nom = "Economie";
                Categorie.Id = Guid.NewGuid();
                context.Categories.Add(Categorie);
                context.SaveChanges();
            }
            if (context.Categories.Where(c => c.Nom == "Politique").Any() == false)
            {
                var Categorie = new Categorie();
                Categorie.Nom = "Politique";
                Categorie.Id = Guid.NewGuid();
                context.Categories.Add(Categorie);
                context.SaveChanges();
            }
            if (context.Categories.Where(c => c.Nom == "Santé").Any() == false)
            {
                var Categorie = new Categorie();
                Categorie.Nom = "Santé";
                Categorie.Id = Guid.NewGuid();
                context.Categories.Add(Categorie);
                context.SaveChanges();
            }


            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";
                var cat = context.Categories.Where(c => c.Nom == "Politique").First();
                user.CategorieId = cat.Id;
               
                string userPWD = "Admin72@";

                var chkUser = UserManager.Create(user, userPWD);
                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            if (!roleManager.RoleExists("Default"))
            {
                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Default";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "Default";
                user.Email = "default@gmail.com";

                string userPWD = "Default72@";
                var cat = context.Categories.Where(c => c.Nom == "Politique").First();
                user.CategorieId = cat.Id;

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Default");

                }
            }
        }
    }
}
