using System;

class ReduceString
{
    public static string Reduce(string str, int k)
    {
        char[] result = new char[str.Length]; // store final characters
        int[] count = new int[str.Length];    // store counts
        int j = 0; // acts like stack top

        for (int i = 0; i < str.Length; i++)
        {
            result[j] = str[i];

            // if same as previous character
            if (j > 0 && result[j] == result[j - 1])
                count[j] = count[j - 1] + 1;
            else
                count[j] = 1;

            // if count reaches k → remove k characters
            if (count[j] == k)
                j = j - k; // remove last k chars

            j++;
        }

        // build final string
        return new string(result, 0, j);
    }

    static void Main()
    {
        Console.WriteLine(Reduce("geeksforgeeks", 2)); // gksforgks
        Console.WriteLine(Reduce("qddxxxd", 3));       // q
    }
}
