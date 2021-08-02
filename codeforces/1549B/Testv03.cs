using System;
using System.Linq;

// https://codeforces.com/contest/1549/problem/A 
public class Test
{
    static void Main()
    {
        var firstLine   = Console.ReadLine();
        var testsCount = int.Parse(firstLine);
 
        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine();
            var n = int.Parse(line1);
            var line2 = Console.ReadLine();
            var line3 = Console.ReadLine();

            var currentResult = PawnGame(n, line2, line3);
            Console.WriteLine(currentResult);
        }
    }

    private static int PawnGame(int n, string a, string b)
    {
        //$"---------{a}--------".Dump();
        var result = 0;

        var carry = false;

        for (var i = n - 1; i >= 0; i--)
        {
            var x = a[i];
            var y = b[i];

            if (carry == false)
            {
                if (x == '0' && y == '1')
                    result++;

                if (x == '1')
                    carry = true;
                else
                    carry = false;
            }
            else
            {
                if (x == '0' && y == '1')
                    result++;

                if (x == '1' && y == '0')
                    carry = true;
                else
                    carry = false;
            }
        }

        return result;
    }
}