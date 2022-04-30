using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using Discord;
using Discord.Audio;
 
namespace Discordbot
{
    private Process CreateStream(string url)
    {
        Process currentsong = new Process();

        currentsong.StartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/C youtube-dl.exe -o - {url} | ffmpeg -i pipe:0 -ac 2 -f s16le -ar 48000 pipe:1",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        currentsong.Start();
        return currentsong;
    }
}