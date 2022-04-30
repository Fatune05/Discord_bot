using System.Threading.Tasks;
using System;
using Discord;
using Discord.WebSocket;


namespace Discord_bot
{
    public class DiscordPr
    {
        static void Main(string[] args) => new DiscordPr().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;
        
        public async Task StartAsync()
        {
            Console.WriteLine("Начата процедура подключения");
            _client = new DiscordSocketClient();
            Console.WriteLine("Авторизация...");
            await _client.LoginAsync(TokenType.Bot, "MzQ1Nzk5MjQ1Mjc5OTIwMTI5.DHBoIQ.598hvkFIu2-NaLmGG3MjF-fKUcM");
            await _client.StartAsync();
            string teg = "for own config"; //your \"l!help\"
            Console.WriteLine("Выставление тега: \"" + teg + "\"...");
            await _client.SetStatusAsync(UserStatus.DoNotDisturb);
            await _client.SetGameAsync(teg, null, ActivityType.Watching);
            Console.WriteLine("Завершение авторизации");
            Console.WriteLine("Начало работы");
            _handler = new CommandHandler(_client);
            await Task.Delay(-1);
        }
    }
}