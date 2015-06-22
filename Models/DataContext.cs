using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace int422TestTwo.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        //Db Context
        public DataContext() : base("name=DataContext") { }
        public DbSet<Book> Book { get; set; }
    }
}