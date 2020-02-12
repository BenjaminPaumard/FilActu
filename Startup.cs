using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilActualite.Startup))]
namespace FilActualite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
