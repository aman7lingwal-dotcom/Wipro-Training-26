using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter sentence:");
        string input = Console.ReadLine().ToLower().Replace(" ", "");

        string reversed = "";

        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }

        Console.WriteLine(input == reversed ? "Palindrome" : "Not Palindrome");
    }
}
