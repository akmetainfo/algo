<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 67. Add Binary
// https://leetcode.com/problems/add-binary/

/*
    Time: Time: O(n) where n = max(a.Length, b.Length)
    Space: O(n)
*/
public class Solution
{
	public string AddBinary(string a, string b)
	{
        var sb = new StringBuilder();

		var carry = 0;
		
		var iA = a.Length - 1;
		var iB = b.Length - 1;

		while (iA >= 0 || iB >= 0)
		{
			var bA = iA < 0 ? 0 : a[iA] - '0';
			var bB = iB < 0 ? 0 : b[iB] - '0';

			sb.Insert(0, (bA + bB + carry) % 2);
			
			carry = (bA + bB + carry) / 2;
			
			iA--;
			iB--;
		}

		if(carry == 0)
			return sb.ToString();
			
		sb.Insert(0, '1');
		return sb.ToString();
	}
}

/*
    Time: Time: O(n) where n = max(a.Length, b.Length)
    Space: O(n)
*/
public class Solution1
{
	public string AddBinary(string a, string b)
	{
        var sb = new StringBuilder();

		var carry = 0;
		
		var iA = a.Length - 1;
		var iB = b.Length - 1;

		while (iA >= 0 || iB >= 0 || carry > 0)
		{
			var bA = iA < 0 ? 0 : a[iA] - '0';
			var bB = iB < 0 ? 0 : b[iB] - '0';

			sb.Insert(0, (bA + bB + carry) % 2);
			
			carry = (bA + bB + carry) / 2;
			
			iA--;
			iB--;
		}

		return sb.ToString();
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