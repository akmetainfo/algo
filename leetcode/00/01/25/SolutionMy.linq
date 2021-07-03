<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 125. Valid Palindrome
// https://leetcode.com/problems/valid-palindrome/

/*
    Time: O(n), where n is length of s
    Space: O(1)
*/
public class Solution
{
    public bool IsPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;
        while(left<right)
        {
            if(!char.IsLetterOrDigit(s[left]))
            {
                left++;
                continue;
            }
            
            if(!char.IsLetterOrDigit(s[right]))
            {
                right--;
                continue;
            }
            
            if(char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;
            
            left++;
            right--;
        }
        return true;
    }
}

[Test]
[TestCase("A man, a plan, a canal: Panama", true)]
[TestCase("race a car", false)]
public void SolutionTests(string s, bool expected)
{
    var actual = new Solution().IsPalindrome(s);
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