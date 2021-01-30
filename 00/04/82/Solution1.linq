<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 482. License Key Formatting
// https://leetcode.com/problems/license-key-formatting/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public string LicenseKeyFormatting(string S, int K)
    {
        var sb = new StringBuilder();
        var count = 0;
        
        for (int i = S.Length - 1; i >= 0; i--)
        {
            if(S[i] == '-')
                continue;
                
            sb.Insert(0, Char.ToUpper(S[i]));
            
            count++;
            
            if(count == K)
            {
                sb.Insert(0, '-');
                count = 0;
            }
        }
        
        if(sb.Length == 0)
            return string.Empty;
        
        if(count == 0)
            sb.Remove(0, 1);
        
        return sb.ToString();
    }
}

[Test]
[TestCase("5F3Z-2e-9-w", 4, "5F3Z-2E9W")]
[TestCase("2-5g-3-J", 2, "2-5G-3J")]
[TestCase("r", 1, "R")]
[TestCase("---", 3, "")]
public void SolutionTests(string S, int K, string expected)
{
    var result = new Solution().LicenseKeyFormatting(S, K);
    Assert.That(result, Is.EqualTo(expected));
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