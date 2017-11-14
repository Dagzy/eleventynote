using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EleventyNote.Web.Startup))]
namespace EleventyNote.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
