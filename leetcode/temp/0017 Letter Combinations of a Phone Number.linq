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
[TestCase("234", new string[] { "adg","adh","adi","aeg","aeh","aei","afg","afh","afi","bdg","bdh","bdi","beg","beh","bei","bfg","bfh","bfi","cdg","cdh","cdi","ceg","ceh","cei","cfg","cfh","cfi" })]
//[TestCase("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
//[TestCase("", new string[] { })]
//[TestCase("2", new string[] { "a", "b", "c" })]
//[TestCase("3", new string[] { "d", "e", "f" })]
//[TestCase("4", new string[] { "g", "h", "i" })]
//[TestCase("5", new string[] { "j", "k", "l" })]
//[TestCase("6", new string[] { "m", "n", "o" })]
//[TestCase("7", new string[] { "p", "q", "r", "s" })]
//[TestCase("8", new string[] { "t", "u", "v" })]
//[TestCase("9", new string[] { "w", "x", "y", "z" })]
public void FindDiagonalOrder(string digits, string[] expected)
{
	var actual = new Solution().LetterCombinations(digits);
	actual.Dump();
	Assert.That(actual, Is.EquivalentTo(expected));
}

// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
#region Условие задачи
/*

Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

 

Example 1:

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

Example 2:

Input: digits = ""
Output: []

Example 3:

Input: digits = "2"
Output: ["a","b","c"]

 

Constraints:

    0 <= digits.length <= 4
    digits[i] is a digit in the range ['2', '9'].


*/

#endregion

public class Solution
{
	public IList<string> LetterCombinations(string digits)
	{
		var result = new List<string>();
		
		if(digits.Length == 0)
			return result;
			
		return GetResult(digits, digits.Length, "");
	}
	
	private static IList<string> GetResult(string digits, int count, string prefix)
	{
		var result = new List<string>();
		
		if(count == 1)
		{
			foreach (var element in GetAlfabet(digits[0]))
			{
				result.Add($"{prefix}{element}");
			}
			
			return result;
		}
		
		var firstChar = digits[0];
		var rest = digits.Substring(1);
		foreach (var element in GetAlfabet(firstChar))
		{
			var newPref = prefix + digits.Substring(0, digits.Length - count + 1);
			result.AddRange(GetResult(rest, count - 1, newPref));
		}
		
		return result;
	}

	private static char[] GetAlfabet(char source)
	{
		switch (source)
		{
			case '2':
				return new char[] { 'a', 'b', 'c' };
			case '3':
				return new char[] { 'd', 'e', 'f' };
			case '4':
				return new char[] { 'g', 'h', 'i' };
			case '5':
				return new char[] { 'j', 'k', 'l' };
			case '6':
				return new char[] { 'm', 'n', 'o' };
			case '7':
				return new char[] { 'p', 'q', 'r', 's' };
			case '8':
				return new char[] { 't', 'u', 'v' };
			case '9':
				return new char[] { 'w', 'x', 'y', 'z' };
			default:
				throw new ArgumentOutOfRangeException(nameof(source));
		}
	}
}

public class SolutionOld
{
	public IList<string> LetterCombinations(string digits)
	{
		var result = new List<string>();

		if (digits.Length == 0)
			return result;

		return GetResult(digits, digits.Length, "");
	}

	private static IList<string> GetResult(string digits, int count, string prefix)
	{
		var result = new List<string>();

		if (count == 1)
		{
			foreach (var element in GetAlfabet(digits[0]))
			{
				result.Add($"{prefix}{element}");
			}

			return result;
		}

		var firstChar = digits[0];
		var rest = digits.Substring(1);
		foreach (var element in GetAlfabet(firstChar))
		{
			result.AddRange(GetResult(rest, count - 1, element.ToString()));
		}

		return result;
	}

	private static char[] GetAlfabet(char source)
	{
		switch (source)
		{
			case '2':
				return new char[] { 'a', 'b', 'c' };
			case '3':
				return new char[] { 'd', 'e', 'f' };
			case '4':
				return new char[] { 'g', 'h', 'i' };
			case '5':
				return new char[] { 'j', 'k', 'l' };
			case '6':
				return new char[] { 'm', 'n', 'o' };
			case '7':
				return new char[] { 'p', 'q', 'r', 's' };
			case '8':
				return new char[] { 't', 'u', 'v' };
			case '9':
				return new char[] { 'w', 'x', 'y', 'z' };
			default:
				throw new ArgumentOutOfRangeException(nameof(source));
		}
	}
}


#region Solutions

/*

*/

#endregion

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