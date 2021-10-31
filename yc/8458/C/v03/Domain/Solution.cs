using System;

public class Solution
{
    /*
     * 
     * Time: O(N) where N is nums.Length
     * Space: O(1)
     * 
     * N.B. вход сортированный, а я это даже и не заметил: решение тогда тривиальный проход
     * 
     */
    static void Main(string[] args)
    {
        string N = Console.ReadLine();
        int n = int.Parse(N);

        if (n == 0) return;

        int prev = int.Parse(Console.ReadLine());
        Console.WriteLine(prev);

        for (var i = 1; i < n; i++)
        {
            string numValue = Console.ReadLine();
            int num = int.Parse(numValue);
            if(prev != num)
            {
                prev = num;
                Console.WriteLine(num);
            }
        }
    }
}