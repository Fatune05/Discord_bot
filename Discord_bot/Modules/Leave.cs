using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Audio;

namespace Discord_bot.Modules
{
    public class Leave : ModuleBase<SocketCommandContext>
    {
        [Command("leave", RunMode = RunMode.Async)]
        public async Task StopAudio()
        {
            Console.WriteLine("Вызвана команда выхода из голосового чата");
            IVoiceChannel channel = (Context.User as IVoiceState).VoiceChannel;
            IAudioClient client = await channel.ConnectAsync();
            await client.StopAsync();
            await Context.Channel.SendMessageAsync("Уже ушла");
        }
    }
}