using System;

// https://codeforces.com/problemset/problem/71/A
public class Test
{
    static void Main()
    {
        var firstLine   = Console.ReadLine();
        var testsCount = int.Parse(firstLine);

        for (int i = 1; i <= testsCount; i++)
        {
            var line1 = Console.ReadLine();

            var currentResult = WayTooLongWords(line1);
            Console.WriteLine(currentResult);
        }
    }

    private static string WayTooLongWords(string source)
    {
        if(source.Length <= 10)
            return source;
        
        return $"{source[0]}{source.Length - 2}{source[source.Length - 1]}";
    }
}