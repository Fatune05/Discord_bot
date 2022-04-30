using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Discord_bot.Modules
{
    public class RequireOwner2 : PreconditionAttribute
    {
        public async override Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            var ownerId = (await services.GetService<DiscordSocketClient>().GetApplicationInfoAsync()).Owner.Id;
            if (context.User.Id == ownerId)
                return PreconditionResult.FromSuccess();
            else
                return PreconditionResult.FromError("Сейчас, только пользователь Fatune#1350 может воспользоваться этой функцией");
        }
    }
}