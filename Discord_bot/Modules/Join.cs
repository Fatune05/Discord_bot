using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Audio;
using System;

namespace Discord_bot.Modules
{
    public class Join : ModuleBase<SocketCommandContext>
    {
        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinCmd()
        {
            CommandService service = new CommandService();
            DiscordSocketClient client = new DiscordSocketClient();
            Console.WriteLine("Подключение к голосовому каналу");
            IVoiceChannel channelUser;
            IVoiceChannel channelBot;
            channelUser = (Context.User as IVoiceState).VoiceChannel;
            channelBot = (client.CurrentUser as IVoiceState).VoiceChannel;
            if (channelUser == null) { await Context.Channel.SendMessageAsync("Я не вижу тебя в голосовом чате"); return; }
            if (channelBot != null)
            {
                if (channelBot == channelUser) { await Context.Channel.SendMessageAsync("Эм-м... Слеповат видать, я уже на твоём канале"); }
                if (channelBot != channelUser) { await Context.Channel.SendMessageAsync("Эй! Меня в последний раз просили стеречь другой канал"); }
            }
            IAudioClient clientAudio = await channelUser.ConnectAsync();
        }
    }
}
