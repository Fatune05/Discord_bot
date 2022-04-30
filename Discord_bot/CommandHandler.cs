using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;
using System;

namespace Discord_bot
{
    public class CommandHandler
    {
        public DiscordSocketClient _client;
        private CommandService _service;

        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            Assembly asm = Assembly.GetEntryAssembly();
            _service.AddModulesAsync(asm, null);
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix("l!", ref argPos))
            {
                Console.WriteLine(context.User + " " + msg);
                var resultMod = await _service.ExecuteAsync(context, argPos, null);
                if (!resultMod.IsSuccess)
                {
                    Console.WriteLine(" (" + resultMod.ErrorReason + ")");
                    if (resultMod.Error != CommandError.UnknownCommand)
                    {
                        await context.Channel.SendMessageAsync(resultMod.ErrorReason);
                    }
                }
            }
            if (msg.Content.Contains("Лаура") || msg.Content.Contains("лаура"))
            {
                var speech = new Speech.SpeechRecognition(_client);
                
                Console.WriteLine(context.User + " " + msg);
                await context.Channel.SendMessageAsync("Я понимаю тебя");
                await _service.ExecuteAsync(context, argPos, null);
            }
        }
    }
}