<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 303. Range Sum Query - Immutable
// https://leetcode.com/problems/range-sum-query-immutable/

/*
    Space: O()
*/
public class NumArray
{
    /*
        Time: O()
    */
    public NumArray(int[] nums)
    {
        throw new NotImplementedException();
    }
    
    /*
        Time: O(1)
    */
    public int SumRange(int left, int right)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(
    new string[] { "NumArray","sumRange","sumRange","sumRange" },
    new object[] { new int[]{ -2, 0, 3, -5, 2, -1 }, new[] {0, 2}, new int[] {2, 5}, new int[] {0,5} },
    new int[] { 42, 1, -1, -3 }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, int[] expectedResult)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedResult);
    
    var unit = new NumArray((int[]) actionsParams[0]);
    
    for(var i = 1; i < actionsParams.Length; i++)
    {
        var input = (int[])actionsParams[i];
        var actual = unit.SumRange(input[0], input[1]);
        Assert.That(actual, Is.EqualTo(expectedResult[i]));
    }
}

private void AssertInputIsCorrect(string[] actionsNames, object[] actionsParams, int[] expectedOutput)
{
    if (actionsNames.Length != actionsParams.Length || actionsNames.Length != expectedOutput.Length)
        throw new ArgumentException($"actionsNames.Length={actionsNames.Length}, actionsParams.Length={actionsParams.Length}, expectedOutput.Length={expectedOutput.Length}.");
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