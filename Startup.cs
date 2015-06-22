using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(int422TestTwo.Startup))]
namespace int422TestTwo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
