using System.Threading.Tasks;
using System;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Discord_bot
{
    public class DiscordPr
    {
        private static void Main(string[] args) => new DiscordPr().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        private CommandHandler _handler;
        private static IServiceProvider ConfigureServices()
        {
            var map = new ServiceCollection();
            return map.BuildServiceProvider();
        }

        public async Task StartAsync()
        {
            Console.WriteLine("Начата процедура подключения");
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info
            });
            _commands = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Debug
            });
            Console.WriteLine("Авторизация...");
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, "MzQ1Nzk5MjQ1Mjc5OTIwMTI5.DHBoIQ.598hvkFIu2-NaLmGG3MjF-fKUcM");
            Console.WriteLine("Завершение авторизации");
            await _client.StartAsync();
            string teg = "for own config"; //your \"l!help\"
            Console.WriteLine("Выставление тега: \"" + teg + "\"...");
            await _client.SetStatusAsync(UserStatus.DoNotDisturb);
            await _client.SetGameAsync(teg, null, ActivityType.Watching);
            Console.WriteLine("Начало работы");
            _services = ConfigureServices();
            _handler = new CommandHandler(_client, _commands, _services);
            await _handler.InstallCommandsAsync();
            await Task.Delay(-1);
        }
        private static Task Log(LogMessage message)
        {
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            return Task.CompletedTask;
        }
    }
}