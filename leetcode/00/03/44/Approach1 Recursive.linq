<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 344. Reverse String
// https://leetcode.com/problems/reverse-string/

/*
    Time: O(n)  time to perform 2N/2 swaps.
    Space: O(n) to keep the recursion stack. 
*/
public class Solution
{
    public void ReverseString(char[] s)
    {
        helper(s, 0, s.Length - 1);
    }
    
    private void helper(char[] s, int left, int right)
    {
        if (left >= right)
            return;
            
        var tmp = s[left];
        s[left] = s[right];
        s[right] = tmp;
        
        left++;
        right--;
        
        helper(s, left, right);
    }
}

[Test]
[TestCase(new char[] { 'h','e','l','l','o' }, new char[] { 'o','l', 'l', 'e', 'h'  })]
[TestCase(new char[] { 'H','a','n','n','a','h' }, new char[] { 'h','a','n','n','a','H'  })]
public void SolutionTests(char[] s, char[] expected)
{
    new Solution().ReverseString(s);
    Assert.That(s, Is.EqualTo(expected));
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