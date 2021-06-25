<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 118. Pascal's Triangle
// https://leetcode.com/problems/pascals-triangle/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();

        if (numRows == 0)
            return result;

        for (var i = 1; i < numRows + 1; i++)
        {
            if (i == 1)
            {
                result.Add(new List<int> { 1 });
                continue;
            }

            if (i == 2)
            {
                result.Add(new List<int> { 1, 1 });
                continue;
            }

            var row = new List<int>();

            for (var j = 0; j < i; j++)
            {
                if (j == 0 || j == i - 1)
                {
                    row.Add(1);
                }
                else
                {
                    row.Add(result[i - 2][j - 1] + result[i - 2][j]);
                }
            }
            //row.Dump();

            result.Add(row);
        }

        return result;
    }
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int numRows, IList<IList<int>> expected)
{
    var actual = new Solution().Generate(numRows);
    Assert.That(actual, Is.EqualTo(expected));
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        1,
        new List<IList<int>> {
            new List<int> { 1 },
        },
    };

    yield return new object[]
    {
        2,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
        },
    };

    yield return new object[]
    {
        3,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
        },
    };

    yield return new object[]
    {
        4,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
        },
    };

    yield return new object[]
    {
        5,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
            new List<int> { 1, 4, 6, 4, 1 },
        },
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