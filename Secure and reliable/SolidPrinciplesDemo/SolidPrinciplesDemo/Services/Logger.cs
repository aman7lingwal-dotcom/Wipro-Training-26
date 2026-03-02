using System;

namespace SolidPrinciplesDemo.Services
{
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();

        private Logger() { }

        public static Logger Instance
        {
            get { return instance; }
        }

        public void Log(string message)
        {
            Console.WriteLine("LOG: " + message);
        }
    }
}
