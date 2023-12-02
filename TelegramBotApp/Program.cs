using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
IConfigurationRoot configuration = builder.Build();
var token = configuration.GetSection("BotSettings:Token").Value;
var bot = new TelegramBotClient(token);
var cts = new CancellationTokenSource();

bot.StartReceiving(
    updateHandler: HandleUpdate,
    HandleError,
    cancellationToken: cts.Token
);
// Tell the user the bot is online
Console.WriteLine("Start listening for updates. Press enter to stop");
Console.ReadLine();

// Send cancellation request to stop the bot
cts.Cancel();



async Task HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    switch (update.Type)
    {
        // A message was received
        case UpdateType.Message:
            await HandleMessage(update.Message!);
            break;
    }
}

async Task HandleError(ITelegramBotClient _, Exception exception, CancellationToken cancellationToken)
{
    await Console.Error.WriteLineAsync(exception.Message);
}

async Task HandleMessage(Message message)
{
    var user = message.From;
    var text = message.Text ?? string.Empty;

    if (user  is null)
    {
        return;
    }
    Console.WriteLine($"{user.FirstName} wrote {text}");

    // When we get a command, we react accordingly
    if (text.StartsWith("/"))
    {
        await HandleCommand(user.Id, text);
    }
    //else if (screaming && text.Length > 0)
    //{
    //    // To preserve the markdown, we attach entities (bold, italic..)
    //    await bot.SendTextMessageAsync(user.Id, text.ToUpper(), entities: message.Entities);
    //}
    else
    {   // This is equivalent to forwarding, without the sender's name
        await bot.CopyMessageAsync(user.Id, user.Id, message.MessageId);
    }
}

async Task HandleCommand(long userId, string command)
{
    switch (command)
    {
        case "/stop":
            cts.Cancel();
            break;
        case "/help":
            await bot.SendTextMessageAsync(userId, "This is a help message.");
            break;
    }

    await Task.CompletedTask;
}