<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1720. Decode XORed Array
// https://leetcode.com/problems/decode-xored-array/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public int[] Decode(int[] encoded, int first)
    {
        var result = new int[encoded.Length +1];
        result[0] = first;
        for(var i = 0; i < encoded.Length ; i++)
        {
            var ch = encoded[i] ^ result[i];
            result[i+1] = ch;
        }
        return result;
    }
    
    void Encode()
    {
        var source = new int[] { 1,0,2,1 };
        var result = new int[source.Length -1];
        for(var i = 0; i < source.Length - 1; i++)
        {
            var ch = source[i] ^ source[i+1];
            result[i] = ch;
        }
        result.Dump();
    }    
    
    void Decode()
    {
        var source = new int[] { 1,2,3 };
        var curr = 1;
        var result = new int[source.Length +1];
        result[0] = curr;
        for(var i = 0; i < source.Length ; i++)
        {
            var ch = source[i] ^ result[i];
            result[i+1] = ch;
        }
        result.Dump();
    }
}

[Test]
[TestCase(new int[] { 1,2,3 }, 1, new int[] {1,0,2,1})]
[TestCase(new int[] {6,2,7,3 }, 4, new int[] {4,2,0,7,4})]
public void SolutionTests(int[] encoded, int first, int[] expected)
{
    var actual = new Solution().Decode(encoded, first);
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