using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord_bot.Speech
{
    public class SpeechRecognition : CommandHandler
    {
        public SpeechRecognition(DiscordSocketClient client) : base(client)
        { 
            var context = new SocketCommandContext(client, msg);
        }
        public class Answers
        {
            public async Task Hello()
            {
                
            }
        }
    }
}