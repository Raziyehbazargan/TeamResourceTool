using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamResourceTool.Startup))]
namespace TeamResourceTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
