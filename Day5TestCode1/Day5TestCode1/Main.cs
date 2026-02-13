// Main file

using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the string: ");
        string word = Console.ReadLine()!;
        char result = Charhelp.Firstnonreapeat(word);
        if (result == '$')
            Console.WriteLine("All characters repeat: " + result);
        else
            Console.WriteLine("The first Non-repeating character is: " + result);
    }
}