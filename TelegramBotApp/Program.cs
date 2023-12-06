using TelegramBotApp;

var configBuilder = new ConfigurationBuilder();
var configuration = configBuilder.BuildConfiguration();
var token = configuration.GetSection("BotSettings:Token").Value;
var botClient = new BotClient(token);
botClient.StartReceiving();
Console.WriteLine("Start listening for updates. Press enter to stop");
Console.ReadLine();
botClient.StopReceiving();
