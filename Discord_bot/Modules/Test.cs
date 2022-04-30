using System.Threading.Tasks;
using Discord.Commands;

namespace Discord_bot.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("Test")]
        [RequireOwner()]
        public async Task Test_C()
        {
            await Context.Channel.SendMessageAsync("Прохожу проверку реакции на команды, команду приняла, завершение теста");
        }
    }
}
