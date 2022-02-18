// See https://aka.ms/new-console-template for more information

using AspNetTelegramBotExample;using Telegram.Bot;
using Telegram.Bot.Examples.Polling;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

var bot = new TelegramBotClient(Configuration.BotToken);

User me = await bot.GetMeAsync();
Console.Title = me.Username ?? "My awesome Bot";

using var cts = new CancellationTokenSource();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
bot.StartReceiving(Handlers.HandleUpdateAsync,
    Handlers.HandleErrorAsync,
    receiverOptions,
    cts.Token);

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();
