using System;

class CustomCollection
{
    // Define internal data structure
    // Complete Step 1:............
    private string[] data = new string[10];

    // Implement indexer
    // Complete Step 2:............
    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < data.Length)
                return data[index];
            return null;
        }
        set
        {
            if (index >= 0 && index < data.Length)
                data[index] = value;
        }
    }

    // Define method to set elements
    // Complete Step 3:............
    public void SetElement(int index, string value)
    {
        this[index] = value;
    }

    // Define method to get elements
    // Complete Step 4:............
    public string GetElement(int index)
    {
        return this[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create instance of CustomCollection
        // Complete Step 7:............
        CustomCollection collection = new CustomCollection();


        // Loop to set and get values based on user input
        for (int i = 0; i < 3; i++)
        {
            // Prompt the user to set elements
            Console.WriteLine("Enter index to set:");
            // Complete Step 5:............
            int setIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter value to set:");
            // Complete Step 6:............
            string value = Console.ReadLine();

            collection.SetElement(setIndex, value);

            // Prompt the user to get the elements
            Console.WriteLine("Enter index to get:");
            // Complete Step 8:............
            int getIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Retrieved value: " + collection.GetElement(getIndex));
        }
    }
}