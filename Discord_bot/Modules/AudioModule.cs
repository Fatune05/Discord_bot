using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;
using Discord.Audio;
using System.Diagnostics;

namespace Discord_bot.Modules
{
    public class AudioModule : ModuleBase<SocketCommandContext>
    {
        [Command("play", RunMode = RunMode.Async)]
        public async Task play(string url)
        {
            IVoiceChannel channel = (Context.User as IVoiceState).VoiceChannel;
            IAudioClient client = await channel.ConnectAsync();

            var output = CreateStream(url).StandardOutput.BaseStream;
            var stream = client.CreatePCMStream(AudioApplication.Music, 128 * 1024);
            output.CopyToAsync(stream);
            stream.FlushAsync().ConfigureAwait(false);
        }
        private AudioService _service;

        public AudioModule(AudioService service)
        {
            _service = service;
        }

    }
}