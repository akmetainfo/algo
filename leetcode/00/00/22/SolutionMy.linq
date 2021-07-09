<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 22. Generate Parentheses
// https://leetcode.com/problems/generate-parentheses/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var newN = 2 * n;
        for (var i = 0; i < 1 << newN; i++)
        {
            var str = Generate(newN, i);
            if (IsValid(str))
                result.Add(str);
        }
        return result;
    }

    public string Generate(int size, int n)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < size; i++)
        {
            var digit = n % 2;
            sb.Append(digit == 0 ? "(" : ")");
            n = n / 2;
        }

        return sb.ToString();
    }

    public bool IsValid(string s)
    {
        if (s == "") return true;

        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else
            {
                if (c == ')' && (!stack.Any() || stack.Pop() != '('))
                {
                    return false;
                }
                else if (c == ']' && (!stack.Any() || stack.Pop() != '['))
                {
                    return false;
                }
                else if (c == '}' && (!stack.Any() || stack.Pop() != '{'))
                {
                    return false;
                }
            }
        }

        return !stack.Any();
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