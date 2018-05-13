using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommPract.Startup))]
namespace ECommPract
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
