<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 9. Palindrome Number
// https://leetcode.com/problems/palindrome-number/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution
{
    public bool IsPalindrome(int x)
    {
        var s = x.ToString();
        
    	var left = 0;
		var right = s.Length - 1;
		while (left < right)
		{
			if (s[left] != s[right])
				return false;

			left++;
			right--;
		}
        
        return true;
    }
}


/*
    Time: O(n)
    Space: O(n)
*/
public class Solution1
{
    public bool IsPalindrome(int x)
    {
        var s = x.ToString();
        
        for(var i = 0; i < s.Length / 2; i++)
			if (s[i] != s[s.Length - 1 - i])
				return false;
        
        return true;
    }
}

[Test]
[TestCase(0, true)]
[TestCase(121, true)]
[TestCase(-121, false)]
[TestCase(10, false)]
[TestCase(-101, false)]
[TestCase(1234321, true)]
public void SolutionTests(int x, bool expected)
{
    var actual = new Solution().IsPalindrome(x);
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