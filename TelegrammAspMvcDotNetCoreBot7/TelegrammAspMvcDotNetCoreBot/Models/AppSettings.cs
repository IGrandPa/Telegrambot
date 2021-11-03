using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegrammAspMvcDotNetCoreBot.Models
{
    public class AppSettings
    {

        public static string Url { get; set; } = "http://localhost:443/{0}";

        public static string Name { get; set; } = "FoodEasybot";

        public static string Key { get; set; } = "1708898419:AAHptyxEVHS62rLwOZISIH7DKLa2dxMiJYI";

        public static string ConnectionInf { get; set; } = "Server=tcp:pizzamax.database.windows.net,1433;Initial Catalog=PizzaDB;Persist Security Info=False;User ID=myadmin;Password=Best_Pizza01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    }
}
