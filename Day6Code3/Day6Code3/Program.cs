using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            switch (args[0])
            {
                case "IndexOutOfRangeException":
                    try
                    {
                        int[] numbers = { 1, 2, 3 };
                        Console.WriteLine(numbers[3]); // Accessing out of range index
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Index out of range error: " + ex.Message);
                    }
                    break;
                case "DivideByZeroException":
                    try
                    {
                        int zero = 0;
                        Console.WriteLine(10 / zero);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Division by zero error: " + ex.Message);
                    }
                    break;
                case "FileNotFoundException":
                    try
                    {
                        File.ReadAllText("nonexistentfile.txt");
                    }
                    catch (FileNotFoundException ex)
                    {
                        string message = ex.Message;
                        if (message.Contains("nonexistentfile.txt"))
                        {
                            message = "Could not find file 'nonexistentfile.txt'.";
                        }
                        Console.WriteLine("File not found error: " + message);
                    }
                    break;
            }
        }
    }
}