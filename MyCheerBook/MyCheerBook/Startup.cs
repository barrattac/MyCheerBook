using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCheerBook.Startup))]
namespace MyCheerBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
