<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 989. Add to Array-Form of Integer
// https://leetcode.com/problems/add-to-array-form-of-integer/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<int> AddToArrayForm(int[] A, int K)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { 1, 2, 0, 0 }, 34, new int[] { 1, 2, 3, 4 })]
[TestCase(new int[] { 2, 7, 4 }, 181, new int[] { 4, 5, 5 })]
[TestCase(new int[] { 2, 1, 5 }, 806, new int[] { 1, 0, 2, 1 })]
[TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, 1, new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
public void SolutionTests(int[] A, int K, int[] expected)
{
    var actual = new Solution().AddToArrayForm(A, K);
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