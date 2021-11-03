using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammAspMvcDotNetCoreBot.Models.Commands
{
    public class CheckCommand : Command
    {
        public override string Name => @"/check";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            int chatId = Convert.ToInt32(message.Chat.Id);

            await botClient.SendTextMessageAsync(chatId, "Список ваших заказов таков:", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
