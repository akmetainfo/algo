using System;

public class Solution
{
    static void Main(string[] args)
    {
        string N = Console.ReadLine();
        int n = int.Parse(N);

        var data = new int[n][];
        for (var i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            var splits = line.Split(' ');
            var x = int.Parse(splits[0]);
            var y = int.Parse(splits[1]);
            data[i] = new int[] { x, y };
        }

        string K = Console.ReadLine();
        int k = int.Parse(K);

        string lineFromTo = Console.ReadLine();
        var splitsFromTo = lineFromTo.Split(' ');
        var from = int.Parse(splitsFromTo[0]);
        var to = int.Parse(splitsFromTo[1]);

        var result = GraphMinPath(n, data, k, from, to);

        Console.WriteLine(result);
    }

    /*
     * 
     * Time: O()
     * Space: O()
     * 
     */
    internal static int GraphMinPath(int n, int[][] data, int k, int from, int to)
    {
    }
}