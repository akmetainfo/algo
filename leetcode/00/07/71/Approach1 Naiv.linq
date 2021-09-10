<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 771. Jewels and Stones
// https://leetcode.com/problems/jewels-and-stones/

/*
    Time: O(N*M) where N is the length of J (Jewels string) and M is the length of S (Stones string)
    Space: O(1)
*/
public class Solution
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        var result = 0;
        foreach (var c in stones)
        {
            if (jewels.Contains(c))
                result++;
        }
        return result;
    }
}

/*
    Time: O(N*M) where N is the length of J (Jewels string) and M is the length of S (Stones string)
    Space: O(1)
*/
public class Solution2
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        return stones.Count(x => jewels.Contains(x));
    }
}

[Test]
[TestCase("aA", "aAAbbbb", 3)]
[TestCase("z", "ZZ", 0)]
public void SolutionTests(string jewels, string stones, int expected)
{
    var actual = new Solution().NumJewelsInStones(jewels, stones);
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