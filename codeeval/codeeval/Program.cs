using System;

class Book
{
    // Define properties
    // Complete Step 1:............
    public string Title;
    public string Author;
    public int Year;

    // Define constructor
    // Complete Step 2:............
    public Book(string title, string author, int year)
    {
        this.Title = title;
        this.Author = author;
        this.Year = year;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter book details
        Console.WriteLine("Enter book's title:");
        // Complete Step 3:............
        string title = Console.ReadLine();

        Console.WriteLine("Enter book's author:");
        // Complete Step 4:............
        string author = Console.ReadLine();

        Console.WriteLine("Enter book's year:");
        // Complete Step 5:............
        int year = Convert.ToInt32(Console.ReadLine());

        // Create an instance of the Book class
        // Complete Step 6:.........
        Book b = new Book(title, author, year);
        Console.WriteLine();
        Console.WriteLine("Details are:");
        Console.WriteLine("Book Title: " + b.Title);
        Console.WriteLine("Book Author: " + b.Author);
        Console.WriteLine("Book Year: " + b.Year);
        // Print book details
        // Complete Step 7:............
    }
}