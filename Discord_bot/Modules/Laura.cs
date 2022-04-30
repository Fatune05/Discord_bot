using System.Threading.Tasks;
using Discord.Commands;
namespace Discord_bot.Modules
{
    public class Laura : ModuleBase<SocketCommandContext>
    {
        [Command("Laura")]
        [Alias("laura")]
        public async Task Test_C()
        {
            await Context.Channel.SendMessageAsync("Да, это моё имя, проверяешь меня?");
        }
    }
}
