using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace Discord_bot.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpC()
        {
            string[] helpStr = new string[10];
            helpStr[0] = "l!clear <кол.сообщений> - Удалить выбранное количество сообщений";
            helpStr[1] = "\nl!luckcookie - Печенье удачи, довольно вкусное";
            helpStr[2] = "\nl!join - Подключиться к голосовому каналу";
            helpStr[3] = "\nl!leave - Покинуть голосовой канал";
            helpStr[4] = "\nl!play <URL ссылка на видео из YouTube> - Лаура подключится к вашему каналу и воспроизведет аудиодорожку";
            helpStr[5] = "\nl!fight <противник> - Дуель на \"Боевой Арене Лауры\"";
            helpStr[6] = "\nl!hit - Нанести удар опоненту";
            helpStr[7] = "\nl!giveup - Сдаться на арене";
            helpStr[8] = "Приглашение Лауры на канал ``` https://goo.gl/Jq6UDK ``` (Вдруг понравится!)";
            helpStr[9] = "\nЧто-то раздражает? Предложения? Пожалуйста, отпишите вот этому Fatune#1350";
            await Context.Channel.SendMessageAsync("```" + helpStr[0] + helpStr[1] + helpStr[2] + helpStr[3] + helpStr[4] + helpStr[5] + helpStr[6] + helpStr[7] + "\n\nВерсия кода 0.4.6```" + helpStr[8] + helpStr[9]);
        }
    }
}