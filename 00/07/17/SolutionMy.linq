<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 717. 1-bit and 2-bit Characters
// https://leetcode.com/problems/1-bit-and-2-bit-characters/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        var i = 0;
        while (i < bits.Length)
        {
            if (i == bits.Length - 1)
                return true;

            if (i == bits.Length - 2 && bits[i] == 1)
                return false;

            if (bits[i] == 0)
            {
                i++;
                continue;
            }

            i += 2;
        }

        return true;
    }
}

[Test]
[TestCase(new int[] { 1, 0, 0 }, true)]
[TestCase(new int[] { 1, 1, 1, 0  }, false)]
public void SolutionTests(int[] bits, bool expected)
{
    var actual = new Solution().IsOneBitCharacter(bits);
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