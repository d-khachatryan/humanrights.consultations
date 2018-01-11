using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eLConsultation.Data.Startup))]
namespace eLConsultation.Data 
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
