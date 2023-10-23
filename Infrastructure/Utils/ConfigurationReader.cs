using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utils
{
    public static class ConfigurationReader
    {
        public static T ReadSection<T>(string sectionName)
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            return configuration.GetSection(sectionName).Get<T>() ?? throw new Exception("Section doesn't exist");
        }
    }
}
