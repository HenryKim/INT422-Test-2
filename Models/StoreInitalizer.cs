using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace int422TestTwo.Models
{
    public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!RoleManager.RoleExists("Administrator"))
            {
                var roleresult = RoleManager.Create(new IdentityRole("Administrator"));
            }

            //Create User = Admin with password=P@ssw0rd
            var user = new ApplicationUser();
            //user.UserName = "admin@test.com";
            user.Email = "admin@test.com";
            var adminresult = UserManager.Create(user, "P@ssw0rd");

            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, "Administrator");
            }



            Book book1 = new Book()
            {
                Title = "LOTR - return of king",
                Author = "J.R.R Tolkien",
                Pages = 325,
                ISBN = "L3025"
            };
            context.Book.Add(book1);
            Book book2 = new Book()
            {
                Title = "LOTR - two towers",
                Author = "J.R.R Tolkien",
                Pages = 345,
                ISBN = "L3024"
            };
            context.Book.Add(book2);
            Book book3 = new Book()
            {
                Title = "HarryPotter",
                Author = "J.K Rolling",
                Pages = 236,
                ISBN = "H3024"
            };
            context.Book.Add(book3);
            context.SaveChanges();
        }
    }
}