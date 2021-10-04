<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 77. Combinations
// https://leetcode.com/problems/combinations/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        if (n < k)
            return new List<IList<int>>();

        if (k == 0)
            return new List<IList<int>> { new List<int>() };

        var output = Combine(n - 1, k - 1);
        foreach (var inner in output)
            inner.Add(n);

        var o2 = Combine(n - 1, k);
        foreach (var inner in o2)
            output.Add(inner);

        return output;
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        4,
        2,
        new List<IList<int>> {
            new List<int> {2, 4},
            new List<int> {3, 4},
            new List<int> {2, 3},
            new List<int> {1, 2},
            new List<int> {1, 3},
            new List<int> {1, 4},
        },
    };
    yield return new object[]
    {
        1,
        1,
        new List<IList<int>> {
            new List<int> {1,}
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int n, int k, IList<IList<int>> expected)
{
    var actual = new Solution().Combine(n, k);
    Assert.That(actual, Is.EquivalentTo(expected));
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