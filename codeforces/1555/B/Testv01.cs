using System;
using System.Linq;
 
public class Test
{
    /*
        Distance(8, 5,  2, 1, 7, 4, 4, 2).Dump(); // expected: 1.000000000
        Distance(5, 4,  2, 2, 5, 4, 3, 3).Dump(); // expected: -1
        Distance(1, 8,  0, 3, 1, 6, 1, 5).Dump(); // expected: 2.000000000
        Distance(8, 1,  3, 0, 6, 1, 5, 1).Dump(); // expected: 2.000000000
        Distance(8, 10, 4, 5, 7, 8, 8, 5).Dump(); // expected: 0.000000000
     */
    static void Main()
    {
        var firstLine   = Console.ReadLine();
        var testsCount = int.Parse(firstLine);
 
        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine().Split(' ');
            var W     = int.Parse(line1[0]);
            var H     = int.Parse(line1[1]);

            var line2 = Console.ReadLine().Split(' ');
            var x1    = int.Parse(line2[0]);
            var y1    = int.Parse(line2[1]);
            var x2    = int.Parse(line2[2]);
            var y2    = int.Parse(line2[3]);

            var line3 = Console.ReadLine().Split(' ');
            var w     = int.Parse(line3[0]);
            var h     = int.Parse(line3[1]);

            var currentResult = Distance(W, H, x1, y1, x2, y2, w, h);
            Console.WriteLine(currentResult);
        }
    }

    private double Distance(int W, int H, int x1, int y1, int x2, int y2, int w, int h)
    {
        // case 1. No way to put second table

        if ((x2 - x1 + w > W) && (y2 - y1 + h > H))
            return -1;

        // case 2. There's enough place to put second table without moving

        // TODO: second table can be in more than one quadrant!

        var xBefore = x1;
        var xAfter  = W - x2;
        var yHigher = H - y2;
        var yLower  = y1;

        if (xBefore >= w && yHigher >= h) // upper-left quadrant
            return 0;

        if (xAfter >= w && yHigher >= h) // upper-right quadrant
            return 0;

        if (xBefore >= w && yLower >= h) // lower-left quadrant
            return 0;

        if (xAfter >= w && yLower >= h) // lower-right quadrant
            return 0;

        //$"xBefore={xBefore}, xAfter={xAfter}, yHigher={yHigher}, yLower={yLower}".Dump();

        // case 3. We need to move

        var maxHoriz = w - Math.Max(xBefore, xAfter);
        var maxVert  = h - Math.Max(yHigher, yLower);

        if (maxHoriz == 0)
            return maxVert;

        if (maxVert == 0)
            return maxHoriz;

        //$"maxHoriz={maxHoriz} ({xBefore},{xAfter} - {w}), maxVert={maxVert} ({yHigher},{yLower} - {h})".Dump();
        //$"maxHoriz={maxHoriz}, maxVert={maxVert}".Dump();
        return Math.Sqrt(maxHoriz * maxHoriz + maxVert * maxVert);
    }
}