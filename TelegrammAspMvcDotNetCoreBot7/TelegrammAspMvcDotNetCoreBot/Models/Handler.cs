using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegrammAspMvcDotNetCoreBot.Models
{
    public static class Handler
    {
        public static bool isThisCommand(string mess)
        {
            bool flag = false;

            if(mess.Contains('/'))
            {
                flag = true;
            }
            else
            {
                flag = false;
            }


            return flag;
        }

        public static async Task whatToDo(Message message, TelegramBotClient botClient)
        {
            string text = message.Text;
            int chatId = Convert.ToInt32(message.Chat.Id);

            if (text == "25" || text == "35" || text=="45")
            {
                await botClient.SendTextMessageAsync(chatId, "Какую пиццу желаете ?", replyMarkup: GetButtons());
            }

            if(text == "Мексиканская" || text == "Гавайская" || text == "Маргарита")
            {
                await botClient.SendTextMessageAsync(chatId, "Хорошо", replyMarkup: GetButtons2());
            }
        }

        private static IReplyMarkup GetButtons2()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton {Text = "/finish"} }
                }
            };
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton {Text = "Мексиканская"}, new KeyboardButton { Text = "Гавайская" }, new KeyboardButton { Text = "Маргарита" } }
                }
            };
        }
    }
}
