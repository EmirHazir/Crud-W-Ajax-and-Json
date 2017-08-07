using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcOperationWithAjaxAndJson.Startup))]
namespace MvcOperationWithAjaxAndJson
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
