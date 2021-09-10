<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1528. Shuffle String
// https://leetcode.com/problems/shuffle-string/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public string RestoreString(string s, int[] indices)
    {
        var result = new char[s.Length];
        
        for(int i = 0; i < s.Length; i++)
            result[indices[i]] = s[i];
        
        return new string(result);
    }
}

[Test]
[TestCase("codeleet", new int[] { 4,5,6,7,0,2,1,3 }, "leetcode")]
[TestCase("abc", new int[] { 0,1,2 }, "abc")]
[TestCase("aiohn", new int[] { 3,1,4,2,0 }, "nihao")]
[TestCase("aaiougrt", new int[] { 4,0,2,6,7,3,1,5 }, "arigatou")]
[TestCase("art", new int[] { 1,0,2 }, "rat")]
public void SolutionTests(string s, int[] indices, string expected)
{
    var actual = new Solution().RestoreString(s, indices);
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