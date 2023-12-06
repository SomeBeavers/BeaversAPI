using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotApp;

public class BotClient
{
    private readonly TelegramBotClient bot;
    private readonly CancellationTokenSource cts;
    public BotClient(string token)
    {
        bot = new TelegramBotClient(token);
        cts = new CancellationTokenSource();
    }
    public void StartReceiving()
    {
        bot.StartReceiving(
            updateHandler: HandleUpdate,
            HandleError,
            cancellationToken: cts.Token
        );
    }
    public void StopReceiving()
    {
        cts.Cancel();
    }
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

        if (user is null)
        {
            return;
        }
        Console.WriteLine($"{user.FirstName} wrote {text}");

        // When we get a command, we react accordingly
        if (text.StartsWith("/"))
        {
            await HandleCommand(user.Id, text);
        }
        else
        {
            var customText = $"You {user.Username} said {message.Text}";
            await bot.SendTextMessageAsync(user.Id, customText);
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
}
