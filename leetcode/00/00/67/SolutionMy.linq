<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 67. Add Binary
// https://leetcode.com/problems/add-binary/

/*
    Time: O()
    Space: O()
*/
public class Solution {
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

			bool bCurrent = bA ^ bB ^ carry;

			int position = iA >= iB ? iA : iB;
			
			result[position] = bCurrent ? '1' : '0';
			
			carry = carry 
					? !(!bA && !bB)
					: bA && bB;
			
			iA--;
			iB--;
		}

		if(!carry)
			return new string(result);
			
		var one = new char[] { '1' };
		var newResult = one.Concat(result);
		return new string(newResult.ToArray());
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