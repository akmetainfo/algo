using System;

public class Solution
{
    static void Main(string[] args)
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        var result = IsAnagram(a, b);

        Console.WriteLine(result ? 1 : 0);
    }

    /*
     * 
     * Time: O(N+M) where N is a.Length and M is b.Length
     * Space: O(1) because length of array is constant
     * 
     * TODO: you can use int[26] for english letters
     */
    internal static bool IsAnagram(string a, string b)
    {
        if (a.Length != b.Length)
            return false;

        var arrA = new int[256];
        var arrB = new int[256];

        foreach (var ch in a) arrA[ch]++;
        foreach (var ch in b) arrB[ch]++;

        for (var i = 0; i < arrA.Length; i++)
        {
            if (arrA[i] != arrB[i])
                return false;
        }

        return true;
    }
}