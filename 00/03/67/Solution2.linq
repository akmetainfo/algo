<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 367. Valid Perfect Square
// https://leetcode.com/problems/valid-perfect-square/

/*
    The sum of the first n odd integers is n^2

    1:  1
    4:  1 + 3
    9:  1 + 3 + 5
    16: 1 + 3 + 5 + 7
    25: 1 + 3 + 5 + 7 + 9
    
    Time: O(sqrt(num))
          num = 1 + 2 + 3 + ... + n = n*(n+1)/2 => n = O(sqrt(num))
    Space: O(1)
    
    Note: O(logn) is more efficient than O(sqrt(n)), so binary search is more efficient!
*/
// https://leetcode.com/problems/valid-perfect-square/discuss/623417/C-solutions-(Binary-Search-and-Math)
public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        int i = 1;

        while (num > 0)
        {
            num = num - i;
            i = i + 2;
        }

        return num == 0 ? true : false;
    }
}

[Test]
[TestCase(1, true)]
[TestCase(2, false)]
[TestCase(3, false)]
[TestCase(4, true)]
[TestCase(5, false)]
[TestCase(6, false)]
[TestCase(7, false)]
[TestCase(8, false)]
[TestCase(9, true)]
[TestCase(14, false)]
[TestCase(16, true)]
public void SolutionTests(int nums, bool expected)
{
    var actual = new Solution().IsPerfectSquare(nums);
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