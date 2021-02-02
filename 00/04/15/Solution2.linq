<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 415. Add Strings
// https://leetcode.com/problems/add-strings/

/*
    Time: O(max(N1​,N2​)), where N1​ and N2​ are length of nums1 and nums2. Here we do max⁡(N1,N2) iterations at most.
    Space: O(max(N1​,N2​)), because the length of the new string is at most max(N1​,N2​) + 1.
*/
public class Solution
{
    public string AddStrings(string num1, string num2)
    {
        var stack = new Stack<char>();

        int carry = 0;
        int i = num1.Length - 1;
        int j = num2.Length - 1;

        while (i >= 0 || j >= 0)
        {
            int x1 = i >= 0 ? num1[i] - '0' : 0;
            int x2 = j >= 0 ? num2[j] - '0' : 0;
            int value = (x1 + x2 + carry) % 10;
            carry = (x1 + x2 + carry) / 10;
            stack.Push((char)(value + '0'));
            i--;
            j--;
        }

        if (carry != 0)
            stack.Push('1');

        return new string(stack.ToArray());
    }
}

[Test]
[TestCase("0", "0", "0")]
[TestCase("0", "2", "2")]
[TestCase("2", "0", "2")]
[TestCase("1", "9", "10")]
[TestCase("100", "201", "301")]
[TestCase("100", "1201", "1301")]
public void SolutionTests(string num1, string num2, string expected)
{
    var actual = new Solution().AddStrings(num1, num2);
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