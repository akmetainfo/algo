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
[TestCase(new int[] { 1, 0, 2, 3, 0, 4, 5, 0 }, new int[] { 1, 0, 0, 2, 3, 0, 0, 4 })]
[TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 })]
public void AllZero(int[] source, int[] expected)
{
	new Solution().DuplicateZeros(source);
	Assert.That(expected, Is.EqualTo(source));
}

public class Solution
{
	public void DuplicateZeros(int[] arr)
	{
		for(var i = 0; i < arr.Length-1; i++)
		{
			if(arr[i] == 0)
			{
				// shift elements
				for(var j = arr.Length-2; j >= i ; j--)
				{
					arr[j+1] = arr[j];
				}
				// duplicate zero
				arr[++i] = 0;
			}
		}
	}
}

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