using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using int422TestTwo.Models;
using int422TestTwo.ViewModels;

namespace int422TestTwo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Data store initializer
            System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            //ViewModel to Model
            Mapper.CreateMap<AddBook, Book>();



            //Model to ViewModel
            Mapper.CreateMap<Book, BookList>();
            Mapper.CreateMap<Book, BookBase>();
        }
    }
}
