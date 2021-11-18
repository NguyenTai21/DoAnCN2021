using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnCN2021.Startup))]
namespace DoAnCN2021
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
