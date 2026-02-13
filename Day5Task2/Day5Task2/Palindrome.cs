using System;
using System.Text;
public class Palindrome
{
    public static bool Ispalindrome(string s)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
                sb.Append(Char.ToLower(c));
        }
        string newstr = sb.ToString();

        int l = 0;
        int r = newstr.Length - 1;
        while (l < r)
        {
            if (newstr[l] != newstr[r])
                return false;
            l++;
            r--;


        }

        return true;




    }
}
