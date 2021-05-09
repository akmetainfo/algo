<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 119. Pascal's Triangle II
// https://leetcode.com/problems/pascals-triangle-ii/

/*
    Time: O(n)
    Space: O()
*/
public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        var row = new List<int>(Math.Max(rowIndex + 1, 1));

        if (rowIndex < 0)
            return row;

        row.Add(1);

        // We can do O(n). first element is 1, next = prev * (n-k) / (k+1)
        for (int i = 0; i < rowIndex; i++)
        {
            // This is to promote the expression's type to long so that we handle int overflow
            // that may happen due to multiplication.
            long x = rowIndex - i;

            row.Add((int)(row[i] * x / (i + 1)));
        }

        return row;
    }
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int numRows, IList<int> expected)
{
    var actual = new Solution().GetRow(numRows);
    Assert.That(actual, Is.EqualTo(expected));
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        0,
        new List<int> { 1 },
    };

    yield return new object[]
    {
        1,
        new List<int> { 1, 1 },
    };

    yield return new object[]
    {
        2,
        new List<int> { 1, 2, 1 },
    };

    yield return new object[]
    {
        3,
        new List<int> { 1, 3, 3, 1 },
    };

    yield return new object[]
    {
        4,
        new List<int> { 1, 4, 6, 4, 1 },
    };
}

#region unit tests runner

void Main()
{
    var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

    var args = new string[]
    {
         "-noheader",
         $"--work={workDir}",
    };

    RunUnitTests(args);
}

void RunUnitTests(string[] args, Assembly assembly = null)
{
    Console.SetOut(new NoDisposeTextWriter(Console.Out));
    Console.SetError(new NoDisposeTextWriter(Console.Error));
    new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
    private readonly TextWriter writer;
    public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

    public override Encoding Encoding => writer.Encoding;
    public override IFormatProvider FormatProvider => writer.FormatProvider;
    public override void Write(char value) => writer.Write(value);
    public override void Flush() => writer.Flush();
    // forward all other overrides as necessary

    protected override void Dispose(bool disposing)
    {
        // no nothing
    }
}

#endregion