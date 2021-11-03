using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegrammAspMvcDotNetCoreBot.Models.Commands
{
    public class CreateCommand : Command
    {
        public override string Name => @"/create";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            int chatId = Convert.ToInt32(message.Chat.Id);

            await botClient.SendTextMessageAsync(chatId, "Какого размера пиццу ты желаешь ? \r\n25 \r\n35 \r\n45", replyMarkup: GetButtons());
        }

        private IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton {Text = "25"}, new KeyboardButton { Text = "35"}, new KeyboardButton { Text = "45"} }
                }
            };
        }
    }
}
