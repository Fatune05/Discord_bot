using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using Discord.Commands;
using System.Reflection;
using System;

namespace Discord_bot.Modules
{
    public class Punch : ModuleBase<SocketCommandContext>
    {
        [Command("Punch")]
        [Alias("punch")]
        public async Task FacePunch(IUser user)
        {
            await Context.Channel.SendMessageAsync("Бьет по лицу " + user.Mention);
        }
    }
}
