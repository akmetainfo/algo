<Query Kind="Program" />

void Main()
{
    // https://www.codewars.com/kata/54e6533c92449cc251001667/train/csharp

    Kata.UniqueInOrder("AAAABBBCCDAABBB").Dump();
    Kata.UniqueInOrder("ABBCcAD").Dump();
    Kata.UniqueInOrder(new[] { 1, 2, 2, 3, 3 }).Dump();
    Kata.UniqueInOrder(new int[] { }).Dump();
    Kata.UniqueInOrder("").Dump();
    Kata.UniqueInOrder(new int?[] { 1, null, 2, 3, 3, null, null, null, 4, }).Dump();
    Kata.UniqueInOrder(new int?[] { null, 1, 2, null, null, 3, 3, null, null, null, 4, }).Dump();
}

// You can define other methods, fields, classes and namespaces here
public static class Kata
{
    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
    {
        var e = iterable.GetEnumerator();
        
        if (!e.MoveNext())
            yield break;

        var comparer = EqualityComparer<T>.Default;

        var last = e.Current;
        yield return e.Current;

        while (e.MoveNext())
        {
            if (!comparer.Equals(last, e.Current))
            {
                last = e.Current;
                yield return e.Current;
            }
        }
    }
}