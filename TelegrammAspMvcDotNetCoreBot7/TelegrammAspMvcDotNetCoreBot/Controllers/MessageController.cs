using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegrammAspMvcDotNetCoreBot.Models;

namespace TelegrammAspMvcDotNetCoreBot.Controllers
{
    [Route("api/message/update")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Method GET unuvalable";
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();
            string line = message.Text;

            //if (Handler.isThisCommand(line))
            //{

            //    foreach (var command in commands)
            //    {
            //        if (command.Contains(message))
            //        {
            //            await command.Execute(message, botClient);
            //            break;
            //        }
            //    }

            //}
            //else
            //{
            //    await Handler.whatToDo(message, botClient);
            //}

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }


            return Ok();
        }
    }
}
