using System;
using System.Reflection;

// Define your custom attribute class here
// Complete Step 1:............
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
class InfoAttribute : Attribute
{
    public string Description { get; }
    public int Version { get; }

    public InfoAttribute(string description, int version)
    {
        Description = description;
        Version = version;
    }
}

// Example usage of the custom attribute
// Complete Step 2:............
[Info("This is a sample class.", 1)]
class SampleClass
{
    // Apply attribute to property
    [Info("This is a sample property.", 3)]
    public string SampleProperty { get; set; }

    // Apply attribute to method
    [Info("This is a sample method.", 2)]
    public void SampleMethod()
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Implement scenarios to demonstrate attribute usage
        // Complete Step 3:............
        Type type = typeof(SampleClass);

        // Class attribute
        InfoAttribute classAttr = (InfoAttribute)Attribute.GetCustomAttribute(type, typeof(InfoAttribute));
        Console.WriteLine($"Class Description: {classAttr.Description}, Version: {classAttr.Version}");

        // Method attribute
        MethodInfo method = type.GetMethod("SampleMethod");
        InfoAttribute methodAttr = (InfoAttribute)Attribute.GetCustomAttribute(method, typeof(InfoAttribute));
        Console.WriteLine($"Method Description: {methodAttr.Description}, Version: {methodAttr.Version}");

        // Property attribute
        PropertyInfo property = type.GetProperty("SampleProperty");
        InfoAttribute propAttr = (InfoAttribute)Attribute.GetCustomAttribute(property, typeof(InfoAttribute));
        Console.WriteLine($"Property Description: {propAttr.Description}, Version: {propAttr.Version}");
    }
}