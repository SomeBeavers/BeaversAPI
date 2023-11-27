using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var bot = new TelegramBotClient("Your Bot Token Here");
using var cts = new CancellationTokenSource();

bot.StartReceiving(HandleUpdate, HandleError, cts);


async Task HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    switch (update.Type)
    {
        case UpdateType.Message:
            var message = update.Message;
            if (message.Text != null && message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(
                                       chatId: message.Chat,
                                                          text: "You said:\n" + message.Text
                                                      );
            }
            break;
    }
}