using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRoleSession.Startup))]
namespace WebRoleSession
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
