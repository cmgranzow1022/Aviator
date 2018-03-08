namespace Aviator.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Aviator.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Aviator.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Pilot"))
                roleManager.Create(new IdentityRole("Pilot"));

            if (!roleManager.RoleExists("MTech"))
                roleManager.Create(new IdentityRole("MTech"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.FindByEmail("a@a.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.com",
                    UserName = "a@a.com",
                };
                var result = userManager.Create(user, "P@ssw0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }
            if (userManager.FindByEmail("p@p.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "p@p.com",
                    UserName = "p@p.com",
                };
                var result = userManager.Create(user, "P@ssw0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "MTech");
            }
            if (userManager.FindByEmail("mt@mt.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "mt@mt.com",
                    UserName = "mt@mt.com",
                };
                var result = userManager.Create(user, "P@ssw0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "MTech");
            }
        }

    

    }
}
