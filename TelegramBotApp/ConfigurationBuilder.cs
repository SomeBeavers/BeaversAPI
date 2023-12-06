using Microsoft.Extensions.Configuration;

namespace TelegramBotApp;

public class ConfigurationBuilder
{
    public IConfigurationRoot BuildConfiguration()
    {
        var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        return builder.Build();
    }
}
