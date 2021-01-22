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
[TestCase("0", "0", "0")]
[TestCase("0", "1", "1")]
[TestCase("1", "0", "1")]
[TestCase("1", "1", "10")]
[TestCase("1111", "0000", "1111")]
[TestCase("1111", "0", "1111")]
[TestCase("1010", "0101", "1111")]
[TestCase("11", "1", "100")]
[TestCase("111", "1", "1000")]
[TestCase("1", "111", "1000")]
[TestCase("1010", "1011", "10101")]
public void AddBinary(string a, string b, string expected)
{
	var actual = new Solution().AddBinary(a, b);
	Assert.That(actual, Is.EqualTo(expected));
}


// https://leetcode.com/explore/item/1160
#region Условие задачи
/*

Given two binary strings a and b, return their sum as a binary string.

 

Example 1:

Input: a = "11", b = "1"
Output: "100"

Example 2:

Input: a = "1010", b = "1011"
Output: "10101"

 

Constraints:

    1 <= a.length, b.length <= 104
    a and b consist only of '0' or '1' characters.
    Each string does not contain leading zeros except for the zero itself.

*/

#endregion

public class Solution
{
	public string AddBinary(string a, string b)
	{
		var result = a.Length > b.Length
			? new char[a.Length]
			: new char[b.Length];

		bool carry = false;
		
		var iA = a.Length - 1;
		var iB = b.Length - 1;

		while (!(iA < 0 && iB < 0))
		{
			var bA = iA < 0 ? false : a[iA] == '1';
			var bB = iB < 0 ? false : b[iB] == '1';

			//char cA = iA < 0 ? '-' : a[iA];
			//char cB = iB < 0 ? '-' : b[iB];
			//$"string a. i = {iA} cA = '{cA}' {bA}".Dump();
			//$"string b. i = {iB} cB = '{cB}' {bB}".Dump();
			
			bool bCurrent = bA ^ bB ^ carry;

			int position = iA >= iB ? iA : iB;
			
			result[position] = bCurrent ? '1' : '0';
			
			carry = carry 
					? !(!bA && !bB)
					: bA && bB;
			
			iA--;
			iB--;
		}

		//DisplayString(new string(result));

		if(!carry)
			return new string(result);
			
		var one = new char[] { '1' };
		var newResult = one.Concat(result);
		return new string(newResult.ToArray());
	}
}

static readonly string[] LowNames =
 {
	 "NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL",
	 "BS", "HT", "LF", "VT", "FF", "CR", "SO", "SI",
	 "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB",
	 "CAN", "EM", "SUB", "ESC", "FS", "GS", "RS", "US"
 };
public static void DisplayString(string text)
{
	Console.WriteLine("String length: {0}", text.Length);
	foreach (char c in text)
	{
		if (c < 32)
		{
			Console.WriteLine("<{0}> U+{1:x4}", LowNames[c], (int)c);
		}
		else if (c > 127)
		{
			Console.WriteLine("(Possibly non-printable) U+{0:x4}", (int)c);
		}
		else
		{
			Console.WriteLine("{0} U+{1:x4}", c, (int)c);
		}
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще сильно левее вершины нормального распределения

// Решение из моей группы:

public string AddBinary1(string a, string b)
{
	int aPos = a.Length - 1;
	int bPos = b.Length - 1;
	int carry = 0;
	var output = new StringBuilder();

	while (aPos >= 0 || bPos >= 0)
	{
		var aDigit = GetDigit(a, aPos--);
		var bDigit = GetDigit(b, bPos--);
		var sum = aDigit ^ bDigit ^ carry;
		output.Insert(0, sum);
		carry = (aDigit & carry) |
				(bDigit & carry) |
				(aDigit & bDigit);
	}

	if (carry > 0)
	{
		output.Insert(0, carry);
	}

	return output.ToString();
}


private int GetDigit(string a, int pos)
{
	if (pos < 0) return 0;
	return a[pos] == '0' ? 0 : 1;
}

// Решение лучше:
public string AddBinary2(string a, string b)
{
	var carry = false;
	var aCursor = a.Length - 1;
	var bCursor = b.Length - 1;
	var sb = new StringBuilder();
	while (!(aCursor < 0 && bCursor < 0))
	{
		var aValue = aCursor >= 0 ? a[aCursor] == '1' : false;
		var bValue = bCursor >= 0 ? b[bCursor] == '1' : false;

		bool digit = (aValue ^ bValue) ^ carry;
		sb.Insert(0, digit ? '1' : '0');
		carry = (aValue & bValue) | (bValue & carry) | (aValue & carry);

		aCursor--;
		bCursor--;
	}

	//Console.WriteLine($"{aCursor} {bCursor}");

	if (carry)
		sb.Insert(0, '1');

	return sb.ToString();
}

// Ещё лучше
public string AddBinary3(string a, string b)
{
	int aLen = a.Length;
	int bLen = b.Length;
	if (aLen == 0)
	{
		return b;
	}
	if (bLen == 0)
	{
		return a;
	}

	if (aLen < bLen)
	{
		a = AppendZero(a, bLen - aLen);
	}
	else if (aLen > bLen)
	{
		b = AppendZero(b, aLen - bLen);
	}

	string opt = "";
	int result;
	int carry = 0;
	for (int i = a.Length - 1; i >= 0; i--)
	{
		if (a[i] == '1' && b[i] == '1')
		{
			if (carry == 1)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			carry = 1;
		}
		else if (a[i] == '1' || b[i] == '1')
		{
			if (carry == 1)
			{
				result = 0;
				carry = 1;
			}
			else
			{
				result = 1;
				carry = 0;
			}
		}
		else
		{
			result = carry;
			carry = 0;
		}
		opt = result + opt;
	}

	return carry == 1 ? carry + opt : opt;
}

private string AppendZero(string s, int length)
{
	for (int i = 0; i < length; i++)
	{
		s = '0' + s;
	}
	return s;
}

// Типа победитель
public string AddBinary(string a, string b)
{
	int ai = a.Length - 1, bi = b.Length - 1, carry = 0;
	Stack<char> result = new Stack<char>();

	while (ai >= 0 || bi >= 0 || carry > 0)
	{
		int c1 = ai >= 0 ? a[ai--] - '0' : 0;
		int c2 = bi >= 0 ? b[bi--] - '0' : 0;

		int sum = c1 ^ c2 ^ carry;
		carry = (c1 | carry) & (c2 | carry) & (c1 | c2);

		result.Push((char)(sum + '0'));
	}

	return new string(result.ToArray());
}


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