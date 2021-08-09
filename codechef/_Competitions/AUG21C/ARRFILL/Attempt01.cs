using System;
using System.Linq;

/*
    ArrayFilling(10,1,new (int, int)[] {(5,2)} ).Dump(); // 25
    ArrayFilling(8,2,new (int, int)[] {(5,2), (6,3)} ).Dump(); // 41
    ArrayFilling(3,2,new (int, int)[] {(2,2), (1,3)} ).Dump(); // 5
*/

// https://www.codechef.com/AUG21C/problems/ARRFILL
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
            var M = int.Parse(line1[1]);

            var ops = new (int, int)[M];
            for (var j = 0; j < M; j++)
            {
                var line = Console.ReadLine().Split(' ');
                var op = (int.Parse(line[0]), int.Parse(line[1]));
                ops[j] = op;
            }

            var currentResult = ArrayFilling(N, M, ops);
            Console.WriteLine(currentResult);
        }
    }

    private static int ArrayFilling(int N, int M, (int, int)[] ops)
    {
        var orders = Enumerable.Range(0, M).ToArray();

        var ord = DoPermute(orders, 0, M - 1, new List<IList<int>>());

        var maxSum = 0;

        foreach (var order in ord)
        {
            var currentSum = Apply(N, order.ToArray(), ops);
            if (currentSum > maxSum)
                maxSum = currentSum;
        }

        return maxSum;
    }

    #region Permutations

    private static IList<IList<int>> Permute(int[] nums)
    {
        var list = new List<IList<int>>();
        return DoPermute(nums, 0, nums.Length - 1, list);
    }

    private static IList<IList<int>> DoPermute(int[] nums, int start, int end, IList<IList<int>> list)
    {
        if (start == end)
        {
            list.Add(new List<int>(nums));
        }
        else
        {
            for (var i = start; i <= end; i++)
            {
                Swap(ref nums[start], ref nums[i]);
                DoPermute(nums, start + 1, end, list);
                Swap(ref nums[start], ref nums[i]);
            }
        }

        return list;
    }

    private static void Swap(ref int a, ref int b)
    {
        var temp = a;
        a = b;
        b = temp;
    }

    #endregion

    /*

    Apply(10, new int[] { 0 }, new (int, int)[] {(5,2)}).Dump(); // 25

    Apply(8, new int[] { 0, 1 },new (int, int)[] {(5,2), (6,3)}).Dump(); // 32
    Apply(8, new int[] { 1, 0 },new (int, int)[] {(5,2), (6,3)}).Dump(); // 41
    
    Apply(3, new int[] { 0, 1 },new (int, int)[] {(2,2), (1,3)}).Dump(); // 5
    Apply(3, new int[] { 1, 0 },new (int, int)[] {(2,2), (1,3)}).Dump(); // 4

     */
    private static int Apply(int N, int[] orders, (int, int)[] ops)
    {
        var sum = 0;

        var nums = new bool[N];
        var rest = N;

        for (var i = 0; i < orders.Length; i++)
        {
            if (rest == 0)
                break;

            var op = ops[orders[i]];

            for (var j = 0; j < nums.Length; j++)
            {
                if (nums[j] == false && (1 + j) % op.Item2 != 0)
                {
                    nums[j] = true;
                    sum += op.Item1;
                    rest--;
                }
            }
        }

        return sum;
    }
}