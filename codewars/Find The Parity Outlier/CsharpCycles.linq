<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    // even: 2, 4... odd == 1,3...
    public int FindParityOutlier(int[] numbers)
    {
        var numbersEven = 0;
        
        var numbersOdd = 0;
        
        var i = 0;
        while(i < numbers.Length)
        {
            if(numbers[i] % 2 == 0)
            {
                numbersEven++;
            }
            else
            {
                numbersOdd++;
            }
            i++;
        }
        
        var rest = numbersEven > numbersOdd ?  1 : 0 ;
        
        i = 0;
        while(i < numbers.Length)
        {
            if(numbers[i] % 2 == rest)
                return numbers[i];
        
            i++;
        }
        throw new Exception();
    }
}

[Test]
[TestCase(new int[] { 2, 4, 0, 100, 4, 11, 2602, 36 }, 11)]
[TestCase(new int[] { 160, 3, 1719, 19, 11, 13, -21 }, 160)]
public void SolutionTests(int[] numbers, int expected)
{
    var actual = new Solution().FindParityOutlier(numbers);
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