<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

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

// Define other methods and classes here

[Test]
[TestCase("()", true)]
[TestCase("()[]{}", true)]
[TestCase("(]", false)]
[TestCase("([)]", false)]
[TestCase("{[]}", true)]
[TestCase("(", false)]
[TestCase("]", false)]
public void ValidParentheses(string s, bool expected)
{
	var actual = new Solution().IsValid(s);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/1361
#region Условие задачи
/*

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.

 

Example 1:

Input: s = "()"
Output: true

Example 2:

Input: s = "()[]{}"
Output: true

Example 3:

Input: s = "(]"
Output: false

Example 4:

Input: s = "([)]"
Output: false

Example 5:

Input: s = "{[]}"
Output: true
 

Constraints:

    1 <= s.length <= 104
    s consists of parentheses only '()[]{}'.

Hint #1

An interesting property about a valid parenthesis expression is that a sub-expression of a valid expression should also be a valid expression. (Not every sub-expression) e.g.

{ { } [ ] [ [ [ ] ] ] } is VALID expression
          [ [ [ ] ] ]    is VALID sub-expression
  { } [ ]                is VALID sub-expression

Can we exploit this recursive structure somehow?

Hint #2

What if whenever we encounter a matching pair of parenthesis in the expression, we simply remove it from the expression? This would keep on shortening the expression. e.g.

{ { ( { } ) } }
      |_|

{ { (      ) } }
    |______|

{ {          } }
  |__________|

{                }
|________________|

VALID EXPRESSION!

Hint #3

The stack data structure can come in handy here in representing this recursive structure of the problem. We can't really process this from the inside out because we don't have an idea about the overall structure. But, the stack can help us process this recursively i.e. from outside to inwards.

*/

#endregion

public class Solution
{
	public bool IsValid(string s)
	{
		var stack = new Stack<char>(s.Length);
		
		foreach (var element in s)
		{
			switch (element)
			{
				case '(':
				case '[':
				case '{':
					stack.Push(element);
					break;
					
				case ')':
				case ']':
				case '}':
					if(stack.Count == 0)
					{
						return false;
					}
					if(!SameTypeParentheses(stack.Pop(), element))
					{
						return false;
					}
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(element));
			}
		}
		
		return stack.Count == 0;
	}

	private static bool SameTypeParentheses(char a, char b)
	{
		return a == '(' && b == ')' ||
			   a == '[' && b == ']' ||
			   a == '{' && b == '}';
	}
}

#region Хорошие алгоритмы-победители

// 

#endregion

#region unit tests runner

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