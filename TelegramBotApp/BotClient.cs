using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotApp;

public class BotClient(string token, BeaversService beaversService)
{
    private readonly TelegramBotClient bot = new(token);
    private readonly CancellationTokenSource cts = new();

    public void StartReceiving()
    {
        bot.StartReceiving(
            HandleUpdate,
            HandleError,
            cancellationToken: cts.Token
        );
    }

    public void StopReceiving()
    {
        cts.Cancel();
    }

    private async Task HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                await HandleMessage(update.Message!);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    private async Task HandleError(ITelegramBotClient _, Exception exception, CancellationToken cancellationToken)
    {
        await Console.Error.WriteLineAsync(exception.Message);
    }

    private async Task HandleMessage(Message message)
    {
        var user = message.From;

        var text = message.Text ?? string.Empty;
        var beavers = await beaversService.GetBeaversAsync();

        if (user is null) return;
        Console.WriteLine($"{user.FirstName} wrote {text}");

        if (text.StartsWith('/'))
        {
            await HandleCommand(user.Id, text);
        }
        else
        {
            // select random beaver from beavers
            var random = new Random();
            var beaverModels = beavers.ToList();
            var randomBeaver = beaverModels.ElementAt(random.Next(beaverModels.Count));
            
            var randomBeaverText = $"{user.Username} is {randomBeaver.Fluffiness} {randomBeaver.Name}";
            await bot.SendTextMessageAsync(user.Id, randomBeaverText);
        }
    }

    private async Task HandleCommand(long userId, string command)
    {
        switch (command)
        {
            case "/stop":
                await cts.CancelAsync();
                break;
            case "/help":
                await bot.SendTextMessageAsync(userId, "This is a help message.");
                break;
        }

        await Task.CompletedTask;
    }
}