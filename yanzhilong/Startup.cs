using Microsoft.Owin;
using Owin;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
[assembly: OwinStartupAttribute(typeof(yanzhilong.Startup))]
namespace yanzhilong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
