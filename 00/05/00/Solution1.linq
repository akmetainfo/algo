<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 500. Keyboard Row
// https://leetcode.com/problems/keyboard-row/

/*
    Time: O(n)
    Space: O()
*/
public class Solution
{
    public string[] FindWords(string[] words)
    {
        var result = new List<string>();
        
        foreach (var word in words)
        {
            if(IsOneRowWord(word))
                result.Add(word);
        }
        
        return result.ToArray();
    }
    
    private bool IsOneRowWord(string word)
    {
        if(word.Length < 2)
            return true;
            
        int rownumForFirst = Row(word[0]);
        
        for (int i = 1; i < word.Length; i++)
        {
            if(Row(word[i]) != rownumForFirst)
                return false;
        }
        
        return true;
    }
    
    private int Row(char key)
    {
        switch(key)
        {
            case 'q':
            case 'w':
            case 'e':
            case 'r':
            case 't':
            case 'y':
            case 'u':
            case 'i':
            case 'o':
            case 'p':
            case 'Q':
            case 'W':
            case 'E':
            case 'R':
            case 'T':
            case 'Y':
            case 'U':
            case 'I':
            case 'O':
            case 'P':
                return 1;
                
            case 'a':
            case 's':
            case 'd':
            case 'f':
            case 'g':
            case 'h':
            case 'j':
            case 'k':
            case 'l':
            case 'A':
            case 'S':
            case 'D':
            case 'F':
            case 'G':
            case 'H':
            case 'J':
            case 'K':
            case 'L':
                return 2;
                
            case 'z':
            case 'x':
            case 'c':
            case 'v':
            case 'b':
            case 'n':
            case 'm':
            case 'Z':
            case 'X':
            case 'C':
            case 'V':
            case 'B':
            case 'N':
            case 'M':
                return 3;
                
            default:
                throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}

[Test]
[TestCase(new string[] { "Hello", "Alaska", "Dad", "Peace" }, new string[] { "Alaska", "Dad" })]
[TestCase(new string[] { "omk" }, new string[] { })]
[TestCase(new string[] { "adsdf","sfd" }, new string[] { "adsdf","sfd" })]
public void SolutionTests(string[] words, string[] expectedResult)
{
    var result = new Solution().FindWords(words);
    Assert.That(expectedResult, Is.EquivalentTo(result));
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