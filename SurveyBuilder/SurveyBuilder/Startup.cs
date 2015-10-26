using Microsoft.Owin;
using Owin;
using SurveyBuilder;

[assembly: OwinStartup(typeof(Startup))]

namespace SurveyBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
