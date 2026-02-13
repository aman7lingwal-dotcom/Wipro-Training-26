using System;

class Vehicle
{
    // Define properties
    // Complete Step 1:............
    protected string Make;
    protected string Model;
    protected int Year;

    // Define constructor
    // Complete Step 2:............
    public Vehicle(string make, string model, int year)
    {
        this.Make = make;
        this.Model = model;
        this.Year = year;
    }

    // Define virtual method
    // Complete Step 3:............
    public virtual void Display()
    {
        Console.WriteLine($"Make:{Make},Model:{Model},Year:{Year}");

    }
}

class Car : Vehicle
{
    // Override GetInfo method
    // Complete Step 4:............
    public Car(string make, string model, int year) : base(make, model, year) { }
    public override void Display()
    {
        Console.WriteLine($"Car: {Year} {Make} {Model}");
    }
}

class Motorcycle : Vehicle
{
    // Override GetInfo method
    // Complete Step 5:............
    public Motorcycle(string make, string model, int year) : base(make, model, year) { }
    public override void Display()
    {
        Console.WriteLine($"Motorcycle: {Year} {Make} {Model}");

    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter vehicle details for Car
        Console.WriteLine("Enter car make:");
        // Complete Step 6:............
        string carmake = Console.ReadLine()!;

        Console.WriteLine("Enter car model:");
        // Complete Step 7:............
        string carmodel = Console.ReadLine()!;
        Console.WriteLine("Enter car year:");
        // Complete Step 8:............
        int caryear = Convert.ToInt32(Console.ReadLine());
        // Prompt the user to enter vehicle details for Motorcycle
        Console.WriteLine("Enter motorcycle make:");
        // Complete Step 9:............
        string motorcyclemake = Console.ReadLine()!;
        Console.WriteLine("Enter motorcycle model:");
        // Complete Step 10:............
        string motorcyclemodel = Console.ReadLine()!;
        Console.WriteLine("Enter motorcycle year:");
        // Complete Step 11:............
        int motorcycleyear = Convert.ToInt32(Console.ReadLine());
        // Create instances of Car and Motorcycle
        // Complete Step 12:............
        Car car = new Car(carmake, carmodel, caryear);
        Motorcycle motor = new Motorcycle(motorcyclemake, motorcyclemodel, motorcycleyear);

        // Display vehicle information
        // Complete Step 13:............
        car.Display();
        motor.Display();
    }
}