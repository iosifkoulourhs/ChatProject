namespace ChatAppTest1.Migrations
{
    using ChatAppTest1.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChatAppTest1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ChatAppTest1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            if (!roleManager.RoleExists("Administrator"))
            {
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            }
            //an 8elo kai allo xristi apla copy paste kai allazo ta string

            if (!roleManager.RoleExists("Male"))
            {
                roleManager.Create(new IdentityRole { Name = "Male" });
            }

            if (!roleManager.RoleExists("Female"))
            {
                roleManager.Create(new IdentityRole { Name = "Female" });
            }

            if (!roleManager.RoleExists("Other"))
            {
                roleManager.Create(new IdentityRole { Name = "Other" });
            }

            if (!userManager.Users.Any(i => i.UserName == "admin@chatapp.gr"))
            {
                var result = userManager.Create(new ApplicationUser
                {
                    UserName = "admin@chatapp.gr",
                    Email = "admin@chatapp.gr"

                }, "!Admin123");

                if (result.Succeeded)
                {
                    var u = userManager.FindByName("admin@chatapp.gr");
                    userManager.AddToRole(u.Id, "Administrator");
                }

            }



        }
    }
}
