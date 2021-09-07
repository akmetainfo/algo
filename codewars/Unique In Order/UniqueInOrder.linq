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
        if(iterable == null)
            throw new ArgumentNullException(nameof(iterable));
            
        var iterator = iterable.GetEnumerator();
        
        T current = default(T);
        
        while(iterator.MoveNext())
        {
            if(default(T).Equals(current))
            {
                current = iterator.Current;
                var next = iterator.Current;
                if (!default(T).Equals(next))
                    yield return current;
            }
            else
            {
                var next = iterator.Current;
                //$"{(current == null ? "!" : current)} - {(next == null ? "!" : next)}".Dump();
                //if (current.Equals(next))
                if (EqualityComparer<T>.Default.Equals(current, next) || (next == null))
                {
                    $"{(current == null ? "!" : current)} - {(next == null ? "!" : next)}".Dump();
                    //"wow".Dump();
                    //current = next;
                }
                else
                {
                    current = next;
                    yield return next;
                }
            }
        }
        yield break;
    }
}