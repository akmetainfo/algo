<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 119. Pascal's Triangle II
// https://leetcode.com/problems/pascals-triangle-ii/

/*
    Time: O(n), where n is rowIndex
    Space: O(n)
*/
public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        var row = new List<int>(Math.Max(rowIndex + 1, 1));

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

    yield return new object[]
    {
        30,
        new List<int> { 1,30,435,4060,27405,142506,593775,2035800,5852925,14307150,30045015,54627300,86493225,119759850,145422675,155117520,145422675,119759850,86493225,54627300,30045015,14307150,5852925,2035800,593775,142506,27405,4060,435,30,1 },
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