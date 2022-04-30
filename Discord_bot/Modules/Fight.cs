using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using System.Threading;
using System.IO;

namespace Discord_bot.Modules
{
    public class Fight : ModuleBase<SocketCommandContext>
    {
        static string player1;
        static string player2;
        static string[] title = File.ReadAllLines(@"C:\Users\Ivan\Documents\Visual Studio 2015\Projects\Discord_bot\Discord_bot\Titles.txt");
        static string Title1;
        static string Title2;
        static string whosTurn;
        static string whoWaits;
        static string placeHolder;
        static System.Timers.Timer maxTimer = new System.Timers.Timer();
        static System.Timers.Timer actionTimer = new System.Timers.Timer();
        static int health1 = 100;
        static int health2 = 100;
        static string SwitchCaseString = "nofight";
        [Command("fight")]
        [Alias("Fight", "Battle", "battle")]
        [Summary("Начать бой с @Пользователь (example: !fight Fatune")]
        public async Task Battle(IUser user)
        {
            //try
            //{
                
            //    int randTitle9 = rand.Next(145);
            //    int randTitle8 = rand.Next(145);
            //    string path = @"C:\Users\Ivan\Documents\Visual Studio 2015\Projects\Discord_bot\Discord_bot\Titles.txt";
            //    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            //    {
            //        for (int i = 0; i < randTitle8; i++)
            //        {
            //            string titleNew1 = sr.ReadLine();
            //        }
            //    }
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //{ "Хилый", "Лицо отваги", "Не", "Преданный герой", "Бревно", "Бард", "Герой", "UltraMarine40000", "Герой-Любовник", "Северянин", "Выживший", "Хан", "Рыцарь", "Наемник", "Воин", "Жрец", "30-летний девственник", "Маг", "Архимаг", "Страж", "Шахид", "Король", "Принцесса", "Принц", "Ромео", "Джульетта", "Убийца богов", "Нежный", "Граф", "Дворецкий", "Горничная", "Владыка", "Айнз ол", "Лучник", "Призыватель", "Мастер меча", "Спаситель", "Ангел", "Демон", "Картошка", "Лук", "Сквайр", "Аве", "Из Тагдаль'е", "Сладенький", "Драконорожденный", "Драконоубийца", "Соловей", "Богатырь", "Вор", "Плут", "Вестник", "Бастард", "Джон Сноу", "Хикка", "Отаку", "Поклонник сестёр", "Голодный", "Безумец", "Лысый", "Не лысый", "Доктор", "Шурлок", "Дикий", "Бэтман", "Шаман", "Король Шаманов", "Король саппортов", "Саппорт", "Леонардо де", "Торговец", "Пекарь", "Владыка правой", "Чумной доктор", "Зефар", "Владелец дьявольского Шарингана", "Джин", "Бог", "Шварц", "Шульц", "Наследник", "Летописец", "Богиня", "Постигший Тогдаль'е", "Мастер Хамона", "Владелец Стенда", "ДИО", "Зубная фея", "Фея", "Гном", "Эльф", "Химера", "Алхимик", "Цельнометаллический алхимик", "Гомонкул", "Фюрер", "Полковник", "Десятник", "Сотник", "Сестра", "Брат", "Мать", "Отец", "Повар", "Кузнец", "Чернокнижник", "Копейщик", "Рыбак", "Гладиатор", "Крестоносец", "Святой", "Друид", "Джз'арго", "Артист", "Император", "Крестьянин", "Извозчик", "Ниндзя", "Шинигами", "Экзорцист", "Монах", "Папа Римский", "Избранный", "Прототип№022", "Прототип№027", "Прототип№000", "Мудрец", "Берсерк", "Черный мечник", "Фетишст", "Фехтовальщик", "Жена", "Муж", "Стрелок", "Самурай", "Жрица", "Из пепла", "Элементаль", "Тиран", "Гусар", "Чиновник", "Адепт", "Единорог", "Чемпион", "100%-ый сок" };
            string[] phrase = new string[] { "А я пожалуй немного вздремну", "Теперь можете начинать веселиться", "Если будет интересно, расскажу создателю", "Медики будут спонсироваться Орденом", "Та собака, которая испортит арену, будет иметь дело со мной лично", "Мясо в правом углу ринга, отбивная в левом, начинайте!", "Поидее, время ограничено, только вот у меня часов нет"};
            if (Context.User.Mention != user.Mention && SwitchCaseString == "nofight")
            {
                UserStatus userSt = UserStatus.DoNotDisturb;
                await Context.Client.SetStatusAsync(userSt);
                SwitchCaseString = "fight_p1";
                player1 = Context.User.Mention;
                player2 = user.Mention;
                string[] whoStarts = new string[] { Context.User.Mention, user.Mention };
                Random rand = new Random();
                int randomIndex = rand.Next(whoStarts.Length);
                int randTitle1 = rand.Next(title.Length);
                int randTitle2 = rand.Next(title.Length);
                int randPhrase = rand.Next(phrase.Length);
                string text = whoStarts[randomIndex];
                Title1 = title[randTitle1];
                Title2 = title[randTitle2];
                whosTurn = text;
                string rdmphrase = phrase[randPhrase];
                if(text == Context.User.Mention)
                {
                    whoWaits = user.Mention;
                }
                else
                {
                    whoWaits = Context.User.Mention;
                }
                maxTimer.Interval = 600000;
                Thread.Sleep(1000);
                maxTimer.Start();
                await ReplyAsync("Начинаю схватку между " + Title1 + " " + player1 + " и " + Title2 + " " + player2 + ", в этот раз " + text + " оказался быстрее." + rdmphrase);
            }
            else
            {
                Console.WriteLine("Схватка не началась");
                if (SwitchCaseString != "nofight")
                {
                    Thread.Sleep(1500);
                    await ReplyAsync(Context.User.Mention + " может ты, конечно, не видишь, но сейчас арена занята");
                }
                else
                {
                    await ReplyAsync(Context.User.Mention + " если ты хочешь убить себя, то можешь взять веревку и стул, только меня в это не ввязывай");
                }
            }
        }
        [Command("giveup")]
        [Alias("GiveUp", "Giveup", "giveUp")]
        [Summary("Остановить схватку и сдаться")]
        public async Task GiveUp()
        {
            if (SwitchCaseString == "fight_p1")
            {
                await ReplyAsync("Битва была прервана, опонент сдался"); //Ввожу рабочие переменные
                SwitchCaseString = "nofight";
                health1 = 100;
                health2 = 100;
                Title1 = null;
                Title2 = null;
                UserStatus userSt = UserStatus.Online;
                await Context.Client.SetStatusAsync(userSt);
            }
            else
            {
                Thread.Sleep(1500);
                await ReplyAsync("Оглянись вокруг чучело, ты видишь чтобы кто-то сражался?");
            }
        }
        [Command("Hit")]
        [Alias("hit", "attack", "Attack", "Slash", "slash")]
        [Summary("Атаковать противника, ударив его в туловище")]
        public async Task Slash()
        {
            if (SwitchCaseString == "fight_p1")
            {
                if (whosTurn == Context.User.Mention)
                {
                    Random rand = new Random();
                    int randomIndex = rand.Next(1, 5);
                    if (randomIndex != 1)
                    {
                        Random rand2 = new Random();
                        Random rand3 = new Random();
                        int randomIndex2 = rand2.Next(1, 4) + rand2.Next(1, 4);
                        int critIndex = rand2.Next(1, 5);
                        int OnePunchIndex = rand3.Next(100);
                        if(OnePunchIndex == 1)
                        {
                            await ReplyAsync("**ВОТ ЭТО СИЛА! СИЛА ОДНОГО УДАРА**");
                            randomIndex2 = 9001;
                            Thread.Sleep(1500);
                        }
                        if (critIndex != 1)
                        {
                            await ReplyAsync(Context.User.Mention + " бьет и наносит " + randomIndex2 + " урона");
                        }
                        else
                        {
                            randomIndex2 += rand2.Next(3, 7);
                            await ReplyAsync(Context.User.Mention + " бьет и наносит **" + randomIndex2 + "** урона, славный крит!");
                        }
                        Thread.Sleep(1500);
                        if (Context.User.Mention != player1)
                        {
                            health1 = health1 - randomIndex2;
                            if (health1 > 0)
                            {
                                placeHolder = whosTurn;
                                whosTurn = whoWaits;
                                whoWaits = placeHolder;
                                await ReplyAsync(Title1 + " " + player1 + " имеет " + health1 + "\n" + Title2 + " " + player2 + " имеет " + health2 + "\n" + whosTurn + " время ответного удара!");
                            }
                            else
                            {
                                await ReplyAsync(Title1 + " " + player1 + " оказался слабее, чем " + Title2 + " " + player2 + ", так как он победил!");
                                SwitchCaseString = "nofight";
                                health1 = 100;
                                health2 = 100;
                                Title1 = null;
                                Title2 = null;
                            }
                        }
                        else if (Context.User.Mention == player1)
                        {
                            health2 = health2 - randomIndex2;
                            if (health2 > 0)
                            {
                                placeHolder = whosTurn;
                                whosTurn = whoWaits;
                                whoWaits = placeHolder;

                                await ReplyAsync(Title2 + " " + player2 + " имеет " + health2 + "\n" + Title1 + " " + player1 + " имеет " + health1 + "\n" + whosTurn + " время ответного удара!");
                            }
                            else
                            {
                                await ReplyAsync(Title2 + " " + player2 + " оказался слабее, чем " + Title1 + " " + player1 + ", он подтвердил свою силу!");
                                SwitchCaseString = "nofight";
                                health1 = 100;
                                health2 = 100;
                                Title1 = null;
                                Title2 = null;
                                UserStatus userSt = UserStatus.Online;
                                await Context.Client.SetStatusAsync(userSt);
                            }
                        }
                        else
                        {
                            await ReplyAsync("Ум-м-м... тут Фатьюн напортачил, отпишите ему об ошибке, а пока... Кто-то должен сдаться");
                        }
                    }
                    else
                    {
                        await ReplyAsync(Context.User.Mention + " Промах, опонент уворачивается");
                        placeHolder = whosTurn;
                        whosTurn = whoWaits;
                        whoWaits = placeHolder;
                        Thread.Sleep(1500);
                        await ReplyAsync(whosTurn + " ухмыльнувшись, начинает действовать!");
                    }
                }
                else
                {
                    await ReplyAsync(Context.User.Mention + " ну вот, потеря равновесия, разве ты не понимаешь, что у тебя не хватает скорости для удара? ");
                }
            }
            else
            {
                await ReplyAsync("Хороший удар, клоун, воздух не чувствует боли");
            }
        }
    }
}