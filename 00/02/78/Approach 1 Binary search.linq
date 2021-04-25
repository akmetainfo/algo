<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 278. First Bad Version
// https://leetcode.com/problems/first-bad-version/

/*
    Time: O(n) Assume that isBadVersion(version) takes constant time to check if a version is bad. It takes at most n - 1 checks, therefore the overall time complexity is O(n).
    Space: O(1)
*/
public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        var left = 1;
        var right = n;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (!IsBadVersion(mid))
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}

[Test]
[TestCase(5, 4)]
[TestCase(5, 5)]
[TestCase(1, 1)]
public void SolutionTests(int n, int firstBadVersion)
{
    var solution = new Solution();
    solution.Setup(firstBadVersion);
    var actual = solution.FirstBadVersion(n);
    Assert.That(actual, Is.EqualTo(firstBadVersion));
}

public class VersionControl
{
    private int _firstBadVersion;

    public void Setup(int firstBadVersion)
    {
        this._firstBadVersion = firstBadVersion;
    }

    public bool IsBadVersion(int num)
    {
        return num >= this._firstBadVersion;
    }
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