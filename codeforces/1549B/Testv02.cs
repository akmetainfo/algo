using System;
using System.Linq;

// https://codeforces.com/contest/1549/problem/A 
public class Test
{
    static void Main()
    {
        var firstLine = Console.ReadLine();
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

        var pos = n - 2;
        var carry = false;

        while (true)
        {
            //$"pos = {pos}".Dump();

            if (pos < -1)
                return result;

            string newW = $"{TwoFrom(a, pos)}{TwoFrom(b, pos)}";
            //newW.Dump();
            result += Weigth(newW);

            if (carry && newW == "0101")
                result++;

            if (carry && newW == "0111")
                result++;

            pos -= 2;
            carry = Carry(newW);
        }

        throw new Exception("Unexpected!");
    }

    private static string TwoFrom(string x, int pos)
    {
        if (pos == -1)
            return "0" + x.Substring(0, 1);

        return x.Substring(pos, 2);
    }

    // precalculated values for 0 - f (hex)
    private static int Weigth(string x)
    {
        switch (x)
        {
            case "0000": return 0;
            case "0001": return 1;
            case "0010": return 1;
            case "0011": return 2;
            case "0100": return 0;
            case "0101": return 0;
            case "0110": return 1;
            case "0111": return 1;
            case "1000": return 0;
            case "1001": return 1;
            case "1010": return 0;
            case "1011": return 1;
            case "1100": return 0;
            case "1101": return 1;
            case "1110": return 1;
            case "1111": return 2;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static bool Carry(string x)
    {
        switch (x)
        {
            case "0000": return false;
            case "0001": return false;
            case "0010": return false;
            case "0011": return false;
            case "0100": return false;
            case "0101": return false;
            case "0110": return false;
            case "0111": return false;
            case "1000": return true;
            case "1001": return true;
            case "1010": return true;
            case "1011": return true;
            case "1100": return true;
            case "1101": return false;
            case "1110": return true;
            case "1111": return false;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}