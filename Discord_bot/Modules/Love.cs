using System;
using System.Threading.Tasks;
using Discord.Commands;
namespace Discord_bot.Modules
{
    public class Love : ModuleBase<SocketCommandContext>
    {
        [Command("Love")]
        [Alias("love")]
        [RequireOwner()]
        public async Task LoveTask()
        {
            string[] lovePhrase = new string[] {"Я тебя тоже люблю, дорогой", "Создатель, конечно я люблю тебя тоже, разве я обязана это повторять?", "Просто... Просто продолжай заниматься тем чем был занят, не отвлекайся", "Ты знаешь, что я тебе всем обязана", "Вот самовлюбленный павлин!", "Ты хоть понимаешь, что ты меня такой создал? Я не могу не любить тебя", "Эй, ты ведь понимаешь, что ты просишь самолично, любить себя?.. Да, я люблю тебя... ЧЕРТОВ ЗАДРОТ!"};
            Random rand = new Random();
            int rnd = rand.Next(lovePhrase.Length);
            await Context.Channel.SendMessageAsync(lovePhrase[rnd]);
        }
    }
}
