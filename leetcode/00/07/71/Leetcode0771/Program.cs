using System;

namespace Leetcode0771
{
    // https://leetcode.com/problems/jewels-and-stones/
    class Program
    {
        static void Main()
        {
            var jewels = Console.ReadLine();
            var stones = Console.ReadLine();

            var solution = new Solution();
            var result   = solution.NumJewelsInStones(jewels, stones);
            Console.WriteLine(result);
        }
    }
}