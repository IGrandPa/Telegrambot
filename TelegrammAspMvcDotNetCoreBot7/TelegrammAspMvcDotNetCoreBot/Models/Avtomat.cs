using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegrammAspMvcDotNetCoreBot.Models
{
    public static class Avtomat
    {
        static string[] vhod_alf = { "/start", "/create", "/finish","cancel","check" };
        static string[] sost_alf = { "s0", "s1", "s2"};
        static string[,] matrix_sost = {
            {"s1","er","er","er","er" },
            {"er","s2","er","s0","s1" },
            {"er","er","s0","s0","er" }
        };

        
    }
}
