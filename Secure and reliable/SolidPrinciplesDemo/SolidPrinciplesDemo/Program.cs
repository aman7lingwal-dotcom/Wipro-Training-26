using System;
using SolidPrinciplesDemo.Services;   

namespace SolidPrinciplesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log("Application started");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
