using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegrammAspMvcDotNetCoreBot.Models
{
    public static class DB
    {
        public static List<string> ReadAllOrders(Message message) // Возврат заказов в состоянии finish
        {
            List<string> all_orders = new List<string>();

            using (var conn = new SqlConnection(AppSettings.ConnectionInf))
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT * FROM Orders WHERE Status_order=@Status AND Chat_id=@Chat_id;";

                    command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Finish";
                    command.Parameters.Add("@Chat_id", SqlDbType.Int).Value = Convert.ToInt32(message.Chat.Id);

                    conn.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string line = "";
                            string Id = Convert.ToString(reader.GetInt32(0));
                            string LName = reader.GetString(2);
                            string FName = reader.GetString(3);
                            string StatusOrder = reader.GetString(4);
                            string Size = reader.GetString(6);
                            string TypePizza = reader.GetString(7);

                            line = ("Id_order: " + Id + "; Last_name: "+ LName +"; First_name: "+ FName +"; Status_order: "+ StatusOrder +"; Size: " + Size + "; TypePizza: " + TypePizza);

                            all_orders.Add(line);
                        }
                    }
                }
            }


            return all_orders;
        } 

        public static async Task<int> CreateOrder(int Chat_id, string LastName, string FirstName) // Создание заказа
        {
            using (var conn = new SqlConnection(AppSettings.ConnectionInf))
            {

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Orders (Chat_id, Last_name, First_name, Status_order, Step_order, Size, TypePiz)
                    VALUES (@Chat, @LName, @FName, @Status, @Step, @Size, @TypePiz);";

                    cmd.Parameters.Add("@Chat", SqlDbType.Int).Value = Convert.ToInt32(Chat_id);
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar).Value = Convert.ToString(LastName);
                    cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = Convert.ToString(FirstName);
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Starting";
                    cmd.Parameters.Add("@Step", SqlDbType.VarChar).Value = "1";
                    cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@TypePiz", SqlDbType.VarChar).Value = "";

                    await conn.OpenAsync();

                    await cmd.ExecuteNonQueryAsync();

                    return 1;

                }

            }
        } 

        public static void UpdateOrder(int id_Order, string Status, string Step, string Size, string TypePiz) // Обновление заказа
        {
            using (var conn = new SqlConnection(AppSettings.ConnectionInf))
            {

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE Orders
                    SET Status_order = @status, Step_order = @step, Size = @size, TypePiz = @typepiz WHERE Id_order=@order;";

                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = Status;
                    cmd.Parameters.Add("@step", SqlDbType.VarChar).Value = Step;
                    cmd.Parameters.Add("@size", SqlDbType.VarChar).Value = Size;
                    cmd.Parameters.Add("@typepiz", SqlDbType.VarChar).Value = TypePiz;
                    cmd.Parameters.Add("@order", SqlDbType.Int).Value = id_Order;

                    conn.Open();

                    cmd.ExecuteScalar();


                }

            }
        }

        public static int Get_Id_Order(Message message, string Status, string Step) // Получение Id заказа
        {
            int num = 0;

            using (var conn = new SqlConnection(AppSettings.ConnectionInf))
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT Id_order FROM Orders WHERE Chat_id=@Chat_id AND Status_order = @Status AND Step_order = @Step;";

                    
                    command.Parameters.Add("@Chat_id", SqlDbType.Int).Value = Convert.ToInt32(message.Chat.Id);
                    command.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
                    command.Parameters.Add("@Step", SqlDbType.VarChar).Value = Step;

                    conn.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = Convert.ToInt32(reader.GetInt32(0));

                            num = Id;
                            
                        }
                    }
                }
            }


            return num;
        }

    }
}
