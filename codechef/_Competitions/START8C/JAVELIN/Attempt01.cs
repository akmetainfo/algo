using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/*
    JavelinQualification(3, 8000, 2, new int[] { 5000,5001,5002 }).Dump(); // 2 2 3
*/

// https://www.codechef.com/START8C/problems/JAVELIN
public class Test
{
    public static void Main()
    {
        var firstLine = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine().Split(' ');
            var N = int.Parse(line1[0]);
            var M = int.Parse(line1[0]);
            var X = int.Parse(line1[2]);

            var line2 = Console.ReadLine().Split(' ');
            var nums = new int[N];
            for (var a = 0; a < N; a++)
            {
                nums[a] = int.Parse(line2[a]);
            }

            var currentResult = JavelinQualification(N, M, X, nums);
            Console.WriteLine(currentResult);
        }
    }

    public static string JavelinQualification(int N, int M, int X, int[] nums)
    {
        var data = nums.Select((x, i) => new { id = i + 1, val = x });

        var results = new List<int>();

        results.AddRange(data.Where(x => x.val >= M).Select(x => x.id));

        var missing = N - results.Count();
        results.AddRange(data.Where(x => x.val < M).OrderByDescending(x => x.id).Select(x => x.id).Take(missing));

        var ids = results.ToArray();
        Array.Sort(ids);

        var sb = new StringBuilder();

        sb.Append(ids.Length);
        sb.Append(' ');

        sb.Append(string.Join(" ", ids));

        return sb.ToString();
    }
}