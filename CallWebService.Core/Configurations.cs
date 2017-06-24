using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace CallWebService.Core
{
    public static class Configurations
    {
        private static readonly IConfigurationRoot Configuration = new BootStrap().Setup();

        public static readonly string CalculatorServiceEndPoint = Configuration["WebService:CalculatorEndPoint"];

        private class BootStrap
        {
            public IConfigurationRoot Setup()
            {
                IHostingEnvironment environment = new HostingEnvironment();

                // Enable to app to read json setting files
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

                if (environment.IsDevelopment())
                {
                    // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                    builder.AddApplicationInsightsSettings(developerMode: true);
                }

                return builder.Build();
            }
        }
    }
}
