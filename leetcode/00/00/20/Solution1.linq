<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 20. Valid Parentheses
// https://leetcode.com/problems/valid-parentheses/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        var mappings = new Dictionary<char, char>()
        {
            {')', '('},
            {'}', '{'},
            {']', '['},
        };

        foreach (char c in s)
        {
            if (mappings.ContainsKey(c))
            {
                // If the stack is empty, set a dummy value of '#'
                var topElement = stack.Count == 0 ? '#' : stack.Pop();

                if (topElement != mappings[c])
                    return false;
            }
            else
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }
}

[Test]
[TestCase("()", true)]
[TestCase("()[]{}", true)]
[TestCase("(]", false)]
[TestCase("([)]", false)]
[TestCase("{[]}", true)]
[TestCase("(", false)]
[TestCase("]", false)]
public void SolutionTests(string s, bool expected)
{
    var actual = new Solution().IsValid(s);
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