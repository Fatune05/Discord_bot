using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;

namespace Discord_bot.Modules
{
    public class Clear : ModuleBase<SocketCommandContext>
    {
        [Command("clear")]
        [Alias("Clear", "delete", "Delete")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task ClearHistory(uint ucount)
        {
            int count = Convert.ToInt32(ucount);
            try
            {
                var messages = await Context.Channel.GetMessagesAsync(count + 1).FlattenAsync();
                int mCount = messages.Count();
                foreach (var message in messages)
                {
                    await message.DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "The server responded with error 404 (NotFound): \"Unknown Message\"")
                {
                    await Context.Channel.SendMessageAsync("Что-то ОПЯТЬ пошло не по плану, попробуйте ещё раз, отчет отправлю");
                }
            }
            finally
            {
                if (count % 10 >= 1 && count % 10 < 5)
                {
                    if (count % 10 > 1)
                    {
                        await Context.Channel.SendMessageAsync("Завершено удаление сообщений, удалено " + count + " сообщения");
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Завершено удаление сообщений, удалено " + count + " сообщение");
                    }
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Завершено удаление сообщений, удалено " + count + " сообщений");
                }
                Console.WriteLine("Завершено удаление сообщений");
            }
        }
        //{
        //    IUserMessage msg = Context.Message;
        //    Console.WriteLine("1");
        //    int messagesDeleted = 0;
        //    var messageClear = await msg.Channel.SendMessageAsync("Начинаю удаление сообщений");
        //    var lastMessageID = messageClear.Id;
        //    int num = Convert.ToInt32(amount);
        //    Console.WriteLine("Начинается удаление сообщений");

        //    Console.WriteLine(num);
        //    try
        //    {
        //        var stop = false;
        //        while (num > messagesDeleted)
        //        {
        //            var msgs = await msg.Channel.GetMessagesAsync(lastMessageID, Direction.Before, num - messagesDeleted).OfType<IUserMessage>().ToList();
        //            foreach (IUserMessage message in msgs)
        //            {
        //                Console.WriteLine("3");
        //                await message.DeleteAsync();
        //                messagesDeleted++;
        //                Console.WriteLine("4");
        //                if (messagesDeleted >= num || msgs.Count == 0)
        //                {
        //                    Console.WriteLine("5");
        //                    stop = true;
        //                    break;
        //                }
        //                lastMessageID = msgs.Last().Id;
        //            }
        //            if (stop || msgs.Count == 0)
        //            {
        //                break;
        //            }
        //        }
        //    }
//            catch (Exception ex)
//            {
//                if (ex.Message != "The server responded with error 404 (NotFound): \"Unknown Message\"")
//                {
//                    await Context.Channel.SendMessageAsync("Что-то ОПЯТЬ пошло не по плану, попробуйте ещё раз, отчет отправлю");
//    }
//}
        //    finally
        //    {
        //        Console.WriteLine("6");
        //        if (amount % 10 >= 1 && amount % 10 < 5)
        //        {
        //            if (amount % 10 > 1)
        //            {
        //                await Context.Channel.SendMessageAsync("Завершено удаление сообщений, удалено {num} сообщения");
        //            }
        //            else
        //            {
        //                await Context.Channel.SendMessageAsync("Завершено удаление сообщений, удалено {num} сообщение");
        //            }
        //        }
        //        else
        //        {
        //            await Context.Channel.SendMessageAsync("Завершено удаление сообщений, удалено {num} сообщений");
        //        }
        //        Console.WriteLine("Завершено удаление сообщений");
        //    }
        //}
    }
}