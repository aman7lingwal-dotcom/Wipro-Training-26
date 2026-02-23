using System;

// 1. Properties Demo
public class PropertyDemo
{
    // Public property
    public int PublicValue { get; set; }

    // Private property
    private string PrivateValue { get; set; }

    public PropertyDemo()
    {
        PublicValue = 5;
        PrivateValue = "Private Value";
    }

    public string GetPrivateValue()
    {
        return PrivateValue;
    }
}

// 2. Static Members Demo
public class StaticDemo
{
    public static int StaticValue;

    // Static constructor
    static StaticDemo()
    {
        StaticValue = 10;
        Console.WriteLine("Static Constructor");
    }

    public static void StaticMethod()
    {
        Console.WriteLine("Static Method");
    }
}

// 3. Static Class
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

// Program entry point
public class Program
{
    public static void Main()
    {
        // PropertyDemo output
        PropertyDemo demo = new PropertyDemo();
        Console.WriteLine(demo.PublicValue);
        Console.WriteLine(demo.GetPrivateValue());

        // StaticDemo output
        Console.WriteLine(StaticDemo.StaticValue);
        StaticDemo.StaticMethod();

        // MathHelper output
        Console.WriteLine(MathHelper.Add(10, 5));
        Console.WriteLine(MathHelper.Subtract(10, 5));
    }
}