using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace OldWebApp.DotVVM
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }


        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("About", "About", "Views/About.dothtml");
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            config.Resources.Register("jquery", new ScriptResource()
            {
                Location = new UrlResourceLocation("~/Scripts/jquery-3.3.1.min.js"),
            });
            config.Resources.Register("bootstrap", new ScriptResource()
            {
                Location = new UrlResourceLocation("~/Scripts/bootstrap.min.js"),
                Dependencies = new[] { "jquery" }
            });
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
		}
    }
}
