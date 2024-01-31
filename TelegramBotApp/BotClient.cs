using System.Text.Json;
using API.Models;
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
        else if (text.Length == 0)
        {
            // get beaver
            var random = new Random();
            var randomBeaver = beavers.ElementAt(random.Next(beavers.Count()));
            // select another beaver if current beaver is null
            if (randomBeaver == null)
            {
                randomBeaver = beavers.ElementAt(random.Next(beavers.Count()));
            }

        }
        else
        {
            // select random beaver from beavers

            var filteredBeavers = beavers.Where(b => b.Name.Contains(text));
            var beaverNames = filteredBeavers.Select(b => b.Name);
            var response = string.Join(", ", beaverNames);
            await bot.SendTextMessageAsync(user.Id, $"Matching beavers: {response}");
            
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