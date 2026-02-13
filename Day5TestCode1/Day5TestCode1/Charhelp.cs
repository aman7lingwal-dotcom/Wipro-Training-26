using System;
class Charhelp
{
    // Method to check the non repeat
    public static char Firstnonreapeat(string S)
    {
        int[] arr = new int[26]; // array for storing the freq
        foreach (char c in S)
        {
            arr[c - 'a']++; // since it will be something like c-a == (99-97)=2,i.e., index 2.

        }
        // traversing and storing has been done
        foreach (char c in S)
        { // traverse once more 
            if (arr[c - 'a'] == 1) // as soon as value at index=1 is found return
                return c;
        }
        return '$';
    }
}