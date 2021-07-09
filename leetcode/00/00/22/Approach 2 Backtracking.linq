<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 22. Generate Parentheses
// https://leetcode.com/problems/generate-parentheses/

/*
    Time: maybe O(2^N) or O(4 ^ n / sqrt(n) ) This analysis is hard, but it turns out this is the n-th Catalan number, which is bounded asymptotically by 4 ^ n / sqrt(n)
    Space: O(4 ^ n / sqrt(n) ) for stack and O(n) for storing result.
*/
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        Generate(result, "", 0, 0, n);
        return result;
    }
    
    private void Generate(List<string> result, string current, int open, int close, int max)
    {
        if(current.Length == 2 * max)
        {
            result.Add(current);
            return;
        }
        
        if(open < max)
            Generate(result, current + "(", open + 1, close, max);
        
        if(open > close)
            Generate(result, current + ")", open, close + 1, max);
    }
}

[Test]
[TestCase(5, new string[] { "((((()))))","(((()())))","(((())()))","(((()))())","(((())))()","((()(())))","((()()()))","((()())())","((()()))()","((())(()))","((())()())","((())())()","((()))(())","((()))()()","(()((())))","(()(()()))","(()(())())","(()(()))()","(()()(()))","(()()()())","(()()())()","(()())(())","(()())()()","(())((()))","(())(()())","(())(())()","(())()(())","(())()()()","()(((())))","()((()()))","()((())())","()((()))()","()(()(()))","()(()()())","()(()())()","()(())(())","()(())()()","()()((()))","()()(()())","()()(())()","()()()(())","()()()()()" })]
[TestCase(4, new string[] { "(((())))","((()()))","((())())","((()))()","(()(()))","(()()())","(()())()","(())(())","(())()()","()((()))","()(()())","()(())()","()()(())","()()()()" })]
[TestCase(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
[TestCase(2, new string[] { "()()", "(())" })]
[TestCase(1, new string[] { "()" })]
public void SolutionTests(int n, string[] expected)
{
    var actual = new Solution().GenerateParenthesis(n);
    Assert.That(actual, Is.EquivalentTo(expected));
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