using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;
using System;

namespace Discord_bot
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;

        public CommandHandler(DiscordSocketClient client, CommandService commands, IServiceProvider services)
        {
            _client = client;
            _commands = commands;
            _services = services;
        }
        public async Task InstallCommandsAsync()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(asm, _services);
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null || msg.Author.IsBot)
            {
                return;
            }
            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix("l!", ref argPos))
            {  
                Console.WriteLine(context.User + " " + msg);
                var resultMod = await _commands.ExecuteAsync(context, argPos, _services);
                if (!resultMod.IsSuccess)
                {
                    Console.WriteLine(" (" + resultMod.ErrorReason + ")");
                    if (resultMod.Error != CommandError.UnknownCommand)
                    {
                        await context.Channel.SendMessageAsync(resultMod.ErrorReason);
                    }
                }
            }
            //Пробовал сделать распознавание вне команд, но нужно модифицировать обработчик
            //if (msg.Content.Contains("Лаура") || msg.Content.Contains("лаура"))
            //{
            //    var speech = new Speech.SpeechRecognition(_client);

            //    Console.WriteLine(context.User + " " + msg);
            //    await context.Channel.SendMessageAsync("Я понимаю тебя");
            //    await _service.ExecuteAsync(context, argPos, null);
            //}
        }
    }
}