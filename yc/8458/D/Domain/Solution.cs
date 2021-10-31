using System;
using System.Collections.Generic;

public class Solution
{
    static void Main(string[] args)
    {
        string N = Console.ReadLine();
        int n = int.Parse(N);

        var result = GenerateValidParenthesis(n);

        foreach (var str in result)
            Console.WriteLine(str);
    }

    /*
     * 
     * Time: maybe O(2^N) or O(4 ^ N / sqrt(N) ) This analysis is hard, but it turns out this is the n-th Catalan number, which is bounded asymptotically by 4 ^ N / sqrt(N)
     * Space: O(4 ^ N / sqrt(N) ) for stack and O(N) for storing result (or assume it O(1) as auxilary).
     * 
     */
    internal static IList<string> GenerateValidParenthesis(int n)
    {
        var result = new List<string>();
        Backtracking(result, string.Empty, 0, 0, n);
        return result;
    }

    private static void Backtracking(List<string> result, string current, int open, int close, int max)
    {
        if (current.Length == 2 * max)
        {
            result.Add(current);
            return;
        }

        if (open < max)
            Backtracking(result, current + "(", open + 1, close, max);

        if (open > close)
            Backtracking(result, current + ")", open, close + 1, max);
    }

}