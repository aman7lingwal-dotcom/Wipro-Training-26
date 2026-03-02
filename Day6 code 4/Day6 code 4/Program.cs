using System;
using System.IO;


public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            try
            {
                try
                {
                    switch (args[0])
                    {
                        case "IndexOutOfRangeException":
                            int[] arr = new int[2];
                            Console.WriteLine(arr[5]); // trigger
                            break;

                        case "DivideByZeroException":
                            int a = 10, b = 0;
                            Console.WriteLine(a / b);
                            break;

                        case "FileNotFoundException":
                            File.Open("nonexistentfile.txt", FileMode.Open);
                            break;

                        case "CustomException":
                            throw new CustomException("Custom exception occurred");
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(
                        "Index out of range error: Index was outside the bounds of the array."
                    );
                    throw;
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Divide by zero error: Attempted to divide by zero.");
                    throw;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("File not found error: Could not find the specified file.");
                    throw;
                }
                catch (CustomException ex)
                {
                    Console.WriteLine("Custom error: " + ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Execution completed.");
            }
        }
    }
}

// Custom exception
public class CustomException : Exception
{
    public CustomException(string message) : base(message) { }
}