using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SQLapp.Startup))]
namespace SQLapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
