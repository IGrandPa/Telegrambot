using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegrammAspMvcDotNetCoreBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            int chatId = Convert.ToInt32(message.Chat.Id);
            string LName = Convert.ToString(message.Chat.LastName);
            string FName = Convert.ToString(message.Chat.FirstName);
            //string emptyText = "";
            //await Task.Run(()=> DB.CreateOrder(chatId,LName,FName)); 

            //await DB.CreateOrder(chatId, LName, FName);
            
            await botClient.SendTextMessageAsync(chatId, "Привет, вижу ты хочешь заказать пиццу. \r\n Держи инструкцию: \r\n /create - начать построение заказа \r\n /check - проверить твои текущие заказы \r\n /cancel - отменить выбранный заказ", replyMarkup: GetButtons());
        }

        private IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton {Text = "/create"}, new KeyboardButton { Text = "/check"}, new KeyboardButton { Text = "/cancel"} }
                }
            };
        }
    }
}
