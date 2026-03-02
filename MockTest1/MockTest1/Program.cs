using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //Input 1: Main String 
        string mainString = GetInput("");

        //Input 2: Sub String  
        string substring = GetInput("");

        // Input 3: Character to be replaced 
        char charToReplace = GetInput("")[0];

        // Input 4: Character to be replaced with 
        char replacementChar = GetInput("")[0];

        bool substringExists = CheckSubstringExists(mainString, substring);
        string replacedString = ReplaceCharacter(mainString, charToReplace, replacementChar);
        string caseSwapped = SwapCase(mainString);
        string noSpaces = RemoveWhitespace(mainString);
        Dictionary<char, int> letterCount = CountLetters(mainString);

        Console.WriteLine($"Substring Exists: {(substringExists ? "Yes" : "No")}");
        Console.WriteLine($"Replaced: {replacedString}");
        Console.WriteLine($"Case Swapped: {caseSwapped}");
        Console.WriteLine($"No Spaces: {noSpaces}");
        Console.WriteLine($"Letter Count: {string.Join(", ", letterCount.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");
    }

    static string GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine()!;
    }

    static bool CheckSubstringExists(string main, string sub)
    {
        // Write your code below
        return main.Contains(sub);
    }

    static string ReplaceCharacter(string input, char oldChar, char newChar)
    {
        // write your code below
        return input.Replace(oldChar, newChar);
    }

    static string SwapCase(string input)
    {
        // Write your code below
        string res = "";
        foreach(char c in input) {
            if (char.IsUpper(c)) res += char.ToLower(c);
            else if (char.IsLower(c)) res += char.ToUpper(c);
            else res += c;
        }
        return res;
    }

    static string RemoveWhitespace(string input)
    {
        // Write your code below
        
        return new string(input.Where(c =>!char.IsWhiteSpace(c)).ToArray());
        //--- just for testing below
        // return new string(input.Where(c => !char.IsNumber(c)).ToArray());
    }

    static Dictionary<char, int> CountLetters(string input)
    {
        // Write your code below
        Dictionary<char, int> count = new Dictionary<char, int>();
        foreach(char c in input) {
            if (char.IsLetter(c)) {
                if (count.ContainsKey(c)) count[c]++;
                else count[c] = 1;
            }
        }
        return count;
        
    }
}