using System;
class Program
{
    static void Main()
    {
        string s;
        Console.WriteLine("enter the string: ");
        s = Console.ReadLine()!;
        bool result = Palindrome.Ispalindrome(s);
        if (result)
            Console.WriteLine("Yes it is palindrome");
        else
            Console.WriteLine("No it is not a palindrome");

    }

}
