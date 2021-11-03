<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 78. Subsets
// https://leetcode.com/problems/subsets/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        throw new NotImplementedException();
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[] {1,2,3},
        new List<IList<int>> {
            new List<int> {},
            new List<int> {1},
            new List<int> {2},
            new List<int> {3},
            new List<int> {1, 2},
            new List<int> {1, 3},
            new List<int> {2, 3},
            new List<int> {1, 2, 3},
        },
    };
    yield return new object[]
    {
        new int[] {0},
        new List<IList<int>> {
            new List<int> {},
            new List<int> {0},
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[] nums, IList<IList<int>> expected)
{
    var actual = new Solution().Subsets(nums);
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