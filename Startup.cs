using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatAppTest1.Startup))]
namespace ChatAppTest1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();

        }
    }
}
