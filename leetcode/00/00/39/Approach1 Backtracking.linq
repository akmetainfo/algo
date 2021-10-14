<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 39. Combination Sum
// https://leetcode.com/problems/combination-sum/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        Array.Sort(candidates);
        CombinationSum(candidates, target, result, new List<int>(), 0);
        return result;
    }

    public void CombinationSum(int[] candidates, int target, IList<IList<int>> result, IList<int> choices, int start)
    {
        if (target == 0)
        {
            result.Add(choices.ToList());
            return;
        }

        for (int i = start; i < candidates.Length && target >= candidates[i]; i++)
        {
            choices.Add(candidates[i]);
            CombinationSum(candidates, target - candidates[i], result, choices, i);
            choices.Remove(choices.Last());
        }
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[] { 2,3,6,7 },
        7,
        new List<IList<int>> {
            new List<int> {2, 2, 3},
            new List<int> {7},
        },
    };
    yield return new object[]
    {
        new int[] { 2,3,5 },
        8,
        new List<IList<int>> {
            new List<int> {2,2,2,2},
            new List<int> {2,3,3},
            new List<int> {3,5},
        },
    };
    yield return new object[]
    {
        new int[] { 2 },
        1,
        new List<IList<int>> {
        },
    };
    yield return new object[]
    {
        new int[] { 1 },
        1,
        new List<IList<int>> {
            new List<int> {1},
        },
    };
    yield return new object[]
    {
        new int[] { 1 },
        2,
        new List<IList<int>> {
            new List<int> {1,1},
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[] candidates, int target, IList<IList<int>> expected)
{
    var actual = new Solution().CombinationSum(candidates, target);
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