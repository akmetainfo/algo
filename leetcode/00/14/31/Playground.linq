<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1431. Kids With the Greatest Number of Candies
// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new int[] { 2, 3, 5, 1, 3 }, 3, new bool[] { true, true, true, false, true })]
[TestCase(new int[] { 4, 2, 1, 1, 2 }, 1, new bool[] { true, false, false, false, false })]
[TestCase(new int[] { 12, 1, 12 }, 10, new bool[] { true, false, true })]
public void SolutionTests(int[] candies, int extraCandies, int[] expected)
{
    var actual = new Solution().KidsWithCandies(candies, extraCandies);
    Assert.That(actual, Is.EqualTo(expected));
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