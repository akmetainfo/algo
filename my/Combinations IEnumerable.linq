<Query Kind="Program">
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
    Combinations(new int[] {1,2,3,4,5}, 3).Dump();
}

// You can define other methods, fields, classes and namespaces here
private static bool NextCombination(IList<int> num, int n, int k)
{
    bool finished;

    var changed = finished = false;

    if (k <= 0) return false;

    for (var i = k - 1; !finished && !changed; i--)
    {
        if (num[i] < n - 1 - (k - 1) + i)
        {
            num[i]++;

            if (i < k - 1)
                for (var j = i + 1; j < k; j++)
                    num[j] = num[j - 1] + 1;
            changed = true;
        }
        finished = i == 0;
    }

    return changed;
}

public static IEnumerable Combinations<T>(IEnumerable<T> elements, int k)
{
    var elem = elements.ToArray();
    var size = elem.Length;

    if (k > size) yield break;

    var numbers = new int[k];

    for (var i = 0; i < k; i++)
        numbers[i] = i;

    do
    {
        yield return numbers.Select(n => elem[n]);
    }
    while (NextCombination(numbers, size, k));
}

