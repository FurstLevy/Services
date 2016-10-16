using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Services.Rest.Server.Startup))]

namespace Services.Rest.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
