<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1544. Make The String Great
// https://leetcode.com/problems/make-the-string-great/

/*
    Time: O(N) because we travers all chars in string
    Space: O(N) for storing characters on stack
*/
public class Solution
{
    public string MakeGood(string s)
    {
        var stack = new Stack<char>();
        for(var i = s.Length - 1; i >= 0; i--)
        {
            var peek = stack.Count() == 0 ? '#' : stack.Peek();
            if(IsSameCharButDifferentCase(s[i], peek))
                stack.Pop();
            else
                stack.Push(s[i]);
        }
        return new string(stack.ToArray());
    }
    
    private bool IsSameCharButDifferentCase(char a, char b)
    {
        if(char.ToLower(a) != char.ToLower(b))
            return false;
            
        return !(a == b);
    }
}

[Test]
[TestCase("leEeetcode", "leetcode")]
[TestCase("abBAcC", "")]
[TestCase("s", "s")]
public void SolutionTests(string s, string expected)
{
    var actual = new Solution().MakeGood(s);
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