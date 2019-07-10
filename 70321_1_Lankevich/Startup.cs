using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_70321_1_Lankevich.Startup))]
namespace _70321_1_Lankevich
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
