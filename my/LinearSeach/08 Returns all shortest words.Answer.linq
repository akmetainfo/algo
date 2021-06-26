<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 08 Returns all shortest words

/*
Given list of words return all words with minimal length.
Word is a non-empty string.
*/

/*
    Time: O(n), two-pass
    Space: O(1)
*/
public class Solution
{
    public List<string> ShortestWords(string[] words)
    {
        var result = new List<string>();
        if(words.Length == 0)
            return result;
        var minWordLen = GetMinWordLen(words);
        foreach(var word in words)
            if(word.Length == minWordLen)
                result.Add(word);
        return result;
    }
    
    private int GetMinWordLen(string[] words)
    {
        var result = words[0].Length;
        foreach(var word in words)
            if(word.Length < result)
                result = word.Length;
        return result;
    }
}

[Test]
[TestCase(new string[] { }, new string[] { })]
[TestCase(new string[] { "a", }, new string[] { "a" })]
[TestCase(new string[] { "a", "b", "cd" }, new string[] { "a", "b" })]
public void SolutionTests(string[] words, string[] expected)
{
    var actual = new Solution().ShortestWords(words);
    Assert.That(actual, Is.EquivalentTo(expected));
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