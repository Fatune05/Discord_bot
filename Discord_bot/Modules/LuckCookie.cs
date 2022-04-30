using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.Webhook;
using System.Threading;

namespace Discord_bot.Modules
{
    public class LuckCookie : ModuleBase<SocketCommandContext>
    {
        [Command("luckcookie")]
        [Alias("lc", "LC", "LuckCookie", "Luckcookie")]
        [Summary("Съешь печенье")]
        public async Task Test_C()
        {
            Console.WriteLine("Вызвана команда печенья удачи");
            Random rand = new Random();
            int cok = rand.Next() % 12 + 1;
            int luc = rand.Next() % 12 + 1;
            int tlk = rand.Next() % 8;
            switch(tlk)
            {
                case (0):
                    {
                        await Context.Channel.SendMessageAsync("Печенье везения? Ладно, сейчас попробую");
                        break;
                    }
                case (1):
                    {
                        await Context.Channel.SendMessageAsync("Почему я? -_-' Я не хочу сейчас есть печенье...");
                        break;
                    }
                case (2):
                    {
                        await Context.Channel.SendMessageAsync("Ням-м! Дай мне секунду");
                        break;
                    }
                case (3):
                    {
                        await Context.Channel.SendMessageAsync("За всё платишь ты!");
                        break;
                    }
                case (4):
                    {
                        await Context.Channel.SendMessageAsync("Хорошо, хорошо, только не стони");
                        break;
                    }
                case (5):
                    {
                        await Context.Channel.SendMessageAsync("Я думала мне придется искать кондитерский ради печенья, а оказалось, что в Ордене его куча!");
                        break;
                    }
                case (6):
                    {
                        await Context.Channel.SendMessageAsync("Если я буду есть столько сладостей, я буду не в форме. У меня вообще-то турнир на носу!");
                        break;
                    }
                case (7):
                    {
                        await Context.Channel.SendMessageAsync("Давай, Лаура, ты справишься, ещё одна печенька... Дайте мне воды!");
                        break;
                    }
            }
            Thread.Sleep(4000);
            await Context.Channel.SendMessageAsync("В этой лежало число " + cok);
            Thread.Sleep(2000);
            if (luc == 12)
            {
                await Context.Channel.SendMessageAsync("Ахах, всё для тебя. Поздравляю с неудачей, черный конверт");
            }
            if(luc == 1)
            {
                await Context.Channel.SendMessageAsync("Как не посмотри, но у тебя в добавок удача, бумажка золотая");
            }
            if(luc != 12 && luc != 1)
            {
                await Context.Channel.SendMessageAsync("Белый листок, ничего нового");
            }
        }
    }
}