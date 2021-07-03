<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 520. Detect Capital
// https://leetcode.com/problems/detect-capital/

/*
    Time: O(n), where n is the length of the word.
    Space: O(1)
*/
public class Solution
{
    public bool DetectCapitalUse(string word)
    {
        if(word.Length == 1)
            return true;
            
        if(!Char.IsUpper(word[0]) && Char.IsUpper(word[1]))
            return false;
            
        if(Char.IsUpper(word[0]) && Char.IsUpper(word[1]))
        {
            for (int i = 2; i < word.Length; i++)
            {
                if(!Char.IsUpper(word[i]))
                    return false;
            }
        }
        else
        {
            for (int i = 2; i < word.Length; i++)
            {
                if (Char.IsUpper(word[i]))
                    return false;
            }
        }
        
        return true;
    }
}

[Test]
[TestCase("USA", true)]
[TestCase("FlaG", false)]
[TestCase("A", true)]
[TestCase("a", true)]
[TestCase("aA", false)]
[TestCase("AA", true)]
[TestCase("Ab", true)]
[TestCase("ab", true)]
[TestCase("abcd", true)]
[TestCase("Abcd", true)]
public void SolutionTests(string word, bool expectedResult)
{
    var result = new Solution().DetectCapitalUse(word);
    Assert.That(result, Is.EqualTo(expectedResult));
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