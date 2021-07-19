using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimeReviews.Startup))]
namespace AnimeReviews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
