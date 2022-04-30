using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.Diagnostics;
using Discord.Audio;

namespace Discord_bot.Modules
{
    public class Play : ModuleBase<SocketCommandContext>
    {
        public IAudioClient clientAudio;

        [Command("join", RunMode = RunMode.Async)]
        [RequireBotPermission(GuildPermission.Speak)]
        public async Task JoinCmd()
        {
            IVoiceChannel channelUser;
            IVoiceChannel channelBot;
            channelUser = (Context.User as IVoiceState).VoiceChannel;
            channelBot = (Context.Guild.CurrentUser as IVoiceState).VoiceChannel;
            Console.WriteLine("\"" + channelUser.Name + "\" " + "\"" + channelBot + "\"");
            if (channelUser == null) { await Context.Channel.SendMessageAsync("Я не вижу тебя в голосовом чате"); return; }
            if (channelBot != null)
            {
                if (channelBot == channelUser) { await Context.Channel.SendMessageAsync("Эм-м... Слеповат видать, я уже на твоём канале"); return; }
                if (channelBot != channelUser) { await Context.Channel.SendMessageAsync("Эй! Меня в последний раз просили стеречь другой канал"); return; }
            }
            clientAudio = await channelUser.ConnectAsync();
        }

        [Command("play", RunMode = RunMode.Async)]
        public async Task PlayCmd(string url)
        {
            IVoiceChannel channelUser;
            IVoiceChannel channelBot;
            channelUser = (Context.User as IVoiceState).VoiceChannel;
            channelBot = (Context.Guild.CurrentUser as IVoiceState).VoiceChannel;
            Console.WriteLine("\"" + channelUser + "\" " + "\"" + channelBot + "\"");
            if (channelBot != channelUser)
            {
                if (channelBot == null)
                {
                    clientAudio = await channelUser.ConnectAsync();
                }
                if (channelBot != null)
                {
                    await Context.Channel.SendMessageAsync("Обождите, а? Я не на твоем канале"); return;
                }
            }
            var output = CreateStream(url).StandardOutput.BaseStream;
            var stream = clientAudio.CreatePCMStream(AudioApplication.Music, 128 * 1024);
            await output.CopyToAsync(stream);
            Console.WriteLine("Создан поток");
            await stream.FlushAsync().ConfigureAwait(false);
            Console.WriteLine("Запущен поток");
        }

        [Command("leave", RunMode = RunMode.Async)]
        public async Task StopAudio()
        {
            IVoiceChannel channelUser;
            IVoiceChannel channelBot;
            channelUser = (Context.User as IVoiceState).VoiceChannel;
            channelBot = (Context.Guild.CurrentUser as IVoiceState).VoiceChannel;
            Console.WriteLine("\"" + channelUser + "\" " + "\"" + channelBot + "\"");
            if(channelBot == null)
            {
                await Context.Channel.SendMessageAsync("Меня нет на каналах! Может быть это ты выйдешь? Из жизни");
                return;
            }
            clientAudio = await channelBot.ConnectAsync();
            await clientAudio.StopAsync();
            channelBot = null;
            await Context.Channel.SendMessageAsync("Уже ушла");
        }

        private Process CreateStream(string url)
        {
            Process currentsong = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C youtube-dl.exe -o - {url} | ffmpeg -i pipe:0 -ac 2 -f s16le -ar 48000 pipe:1",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            currentsong.Start();
            return currentsong;
        }
    }
}
