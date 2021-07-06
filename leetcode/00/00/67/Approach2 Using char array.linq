<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 67. Add Binary
// https://leetcode.com/problems/add-binary/

/*
    Time: O(log n) where n is Math.Max(a.Length, b.Length)
    Space: O(log n)
*/
public class Solution
{
	public string AddBinary(string a, string b)
	{
		var result = new char[Math.Max(a.Length, b.Length) + 1];

		var carry = 0;
		
		var iA = a.Length - 1;
		var iB = b.Length - 1;
        var position = result.Length - 1;

		while (iA >= 0 || iB >= 0)
		{
			var bA = iA < 0 ? 0 : a[iA] - '0';
			var bB = iB < 0 ? 0 : b[iB] - '0';

			result[position] = (bA + bB + carry) % 2 == 1 ? '1' : '0';
			
			carry = (bA + bB + carry) / 2;
			
			iA--;
			iB--;
            position--;
		}

		if(carry == 0)
			return new string(result, 1, result.Length - 1);
			
		result[0] = '1';
		return new string(result);
	}
}

[Test]
[TestCase("11", "1", "100")]
[TestCase("1010", "1011", "10101")]
public void SolutionTests(string a, string b, string expected)
{
    var actual = new Solution().AddBinary(a, b);
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