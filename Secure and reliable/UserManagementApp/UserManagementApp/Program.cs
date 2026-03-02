using System;
using Serilog;
using UserManagementApp.Logging;
using UserManagementApp.Services;

namespace UserManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerConfig.Configure();

            AuthService auth = new AuthService();
            auth.Register("test", "123", "test@mail.com");
            auth.Login("test", "123");

            Console.WriteLine("Check logs folder now");

            // 🔴 VERY IMPORTANT
            Log.CloseAndFlush();

            Console.ReadLine(); // keep app alive
        }
    }
}
