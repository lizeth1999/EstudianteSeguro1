using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admStudentSecurity.Startup))]
namespace admStudentSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
