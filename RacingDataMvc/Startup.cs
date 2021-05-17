using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RacingDataMvc.Startup))]
namespace RacingDataMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
