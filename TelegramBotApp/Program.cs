using TelegramBotApp;
using Microsoft.Extensions.DependencyInjection;

// Create a new service collection
var serviceCollection = new ServiceCollection();
// Configure your services
serviceCollection.AddHttpClient<BeaversService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5234"); // replace with the URL of your API
});
// Build the service provider
var serviceProvider = serviceCollection.BuildServiceProvider();
// Resolve the services
var beaversService = serviceProvider.GetRequiredService<BeaversService>();

var configBuilder = new ConfigurationBuilder();
var configuration = configBuilder.BuildConfiguration();
var token = configuration.GetSection("BotSettings:Token").Value;





var botClient = new BotClient(token, beaversService);


botClient.StartReceiving();

Console.WriteLine("Start listening for updates. Press enter to stop");
Console.ReadLine();

botClient.StopReceiving();
