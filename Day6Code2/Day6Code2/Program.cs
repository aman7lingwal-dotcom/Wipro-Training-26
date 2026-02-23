using System;

// Define PropertyDemo class
public class PropertyDemo
{
    // Public property
    public int PublicValue { get; set; }

    // Private property
    private string PrivateValue { get; set; }

    // Constructor
    public PropertyDemo()
    {
        PublicValue = 5;
        PrivateValue = "Private Value";
    }

    // Method to access private property
    public string GetPrivateValue()
    {
        return PrivateValue;
    }
}

// Define StaticDemo class
public class StaticDemo
{
    // Static variable
    public static int StaticNumber;

    // Static constructor
    static StaticDemo()
    {
        StaticNumber = 10;
    }

    // Static method
    public static void StaticMethod()
    {
        Console.WriteLine("Static Method");
    }
}

// Define MathHelper static class
public static class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}

// Program class
public class Program
{
    public static void Main()
    {
        // Step 1: PropertyDemo
        PropertyDemo demo = new PropertyDemo();
        Console.WriteLine(demo.PublicValue);
        Console.WriteLine(demo.GetPrivateValue());

        // Step 2: StaticDemo
        Console.WriteLine(StaticDemo.StaticNumber);
        StaticDemo.StaticMethod();

        // Step 3: MathHelper
        Console.WriteLine(MathHelper.Add(10, 5));
        Console.WriteLine(MathHelper.Subtract(10, 5));
    }
}