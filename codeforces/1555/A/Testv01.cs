using System;
using System.Linq;
 
public class Test
{
    static void Main()
    {
        var firstLine   = Console.ReadLine();
        var testsCount = int.Parse(firstLine);
 
        for (int i = 1; i <= testsCount; i++)
        {
            var line = Console.ReadLine();
            var count = long.Parse(line);
 
            var currentResult = Calculate(count);
            Console.WriteLine(currentResult);
        }
    }

    private static long Calculate(long total)
    {
        //$"total={total}".Dump();
        long pizza6Count  = 0;
        long pizza8Count  = 0;
        long pizza10Count = 0;

        while (true)
        {
            if (total <= 0)
                break;

            if (total >= 20)
            {
                var rest = total / 10;
                rest--;
                total        =  total - rest * 10;
                pizza10Count += rest;
                continue;
            }

            if (total >= 15)
            {
                total = total - 10;
                pizza10Count++;
                continue;
            }

            if (total >= 13 && total <= 14)
            {
                total = total - 8;
                pizza8Count++;
                continue;
            }

            if (total >= 11 && total <= 12)
            {
                total = total - 6;
                pizza6Count++;
                continue;
            }

            if (total >= 9 && total <= 10)
            {
                total = total - 10;
                pizza10Count++;
                continue;
            }

            if (total >= 7 && total <= 8)
            {
                total = total - 8;
                pizza8Count++;
                continue;
            }

            if (total >= 1 && total <= 6)
            {
                total = total - 6;
                pizza6Count++;
                continue;
            }
        }

        //$"=> 6={pizza6Count},8={pizza8Count},10={pizza10Count}".Dump();

        var minutesTotal = pizza6Count * 15 + pizza8Count * 20 + pizza10Count * 25;
        return minutesTotal;
    }
}