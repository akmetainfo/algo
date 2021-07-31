using System;
 
public class Test
{
    public static void Main()
    {
        var firstLine   = Console.ReadLine();
        var testsCount = int.Parse(firstLine);
 
        for (int i = 1; i <= testsCount; i++)
        {
            var line  = Console.ReadLine().Split(' ');
            var a = int.Parse(line[0]);
            var b = int.Parse(line[1]);

            var currentResult = Sum(a, b);
            Console.WriteLine(currentResult);
        }
    }
 
    private static int Sum(int a, int b)
    {
        return a + b;
    }
}