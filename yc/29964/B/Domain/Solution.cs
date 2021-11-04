using System;
using System.Linq;

public class Solution
{
    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine();
        var split = firstLine.Split(' ');
        var n = int.Parse(split[0]);
        var x = int.Parse(split[1]);
        var k = int.Parse(split[2]);

        var deadlines = new int[n];
        for (var i = 0; i < n; i++)
        {
            string numValue = Console.ReadLine();
            int num = int.Parse(numValue);
            deadlines[i] = num;
        }

        var result = TechDept(n, x, k, deadlines);

        Console.WriteLine(result);
    }

    /*
     * 
     * Time: O(N)
     * Space: O(1)
     * 
     */
    internal static int TechDept(int n, int x, int k, int[] deadlines)
    {
        var maxDeadline = deadlines.Max();

        var dayRobot = x * (maxDeadline / x);

        var dayKey = k * (maxDeadline / k);

        var result = dayKey < k ? k : 100;

        return result;
    }
}