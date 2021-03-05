<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// Shift Array Right

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public void ShiftRight(int[] nums, int from, int filler)
    {
        if (from < 0 || from > nums.Length - 1)
            return;

        for (int i = nums.Length - 1; i > from; i--)
        {
            nums[i] = nums[i - 1];
        }

        nums[from] = filler;
    }
}

[Test]
[TestCase(new int[] { }, -1, 0, new int[] { })]
[TestCase(new int[] { }, 0, 0, new int[] { })]
[TestCase(new int[] { }, 1, 0, new int[] { })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1, 0, new int[] { 1, 2, 3, 4, 5, 6 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 0, new int[] { 0, 1, 2, 3, 4, 5 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 0, new int[] { 1, 0, 2, 3, 4, 5 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 0, new int[] { 1, 2, 0, 3, 4, 5 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 0, new int[] { 1, 2, 3, 0, 4, 5 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, 0, new int[] { 1, 2, 3, 4, 0, 5 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 0, new int[] { 1, 2, 3, 4, 5, 0 })]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, 0, new int[] { 1, 2, 3, 4, 5, 6 })]
public void SolutionTests(int[] nums, int from, int filler, int[] expected)
{
    new Solution().ShiftRight(nums, from, filler);
    Assert.That(nums, Is.EqualTo(expected));
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