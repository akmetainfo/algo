<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1346. Check If N and Its Double Exist
// https://leetcode.com/problems/check-if-n-and-its-double-exist/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool CheckIfExist(int[] arr)
    {
		var hs = new HashSet<int>();

        var hasZero = false;

        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
            {
                if (hasZero)
                    return true;

                hasZero = true;

                continue;
            }

            if (!hs.Contains(arr[i]))
            {
                hs.Add(arr[i]);
            }

            if (arr[i] != 0 && hs.Contains(2 * arr[i]))
                return true;

            if (arr[i] % 2 == 0 && hs.Contains((arr[i] / 2)))
                return true;
        }

        return false;
    }
}

[Test]
[TestCase(new int[] { 10 }, false)]
[TestCase(new int[] { 0,0 }, true)]
[TestCase(new int[] { 2, 5, 4 }, true)]
[TestCase(new int[] { -2,0,10,-19,4,6,-8 }, false)]
public void SolutionTests(int[] arr, bool expected)
{
    var actual = new Solution().CheckIfExist(arr);
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