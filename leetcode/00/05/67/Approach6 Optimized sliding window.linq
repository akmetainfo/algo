<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 567. Permutation in String
// https://leetcode.com/problems/permutation-in-string/

/*
    Time: O(N + (M - N)) where N = s1.Length, M = s2.Length
    Space: O(1)
*/
public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;
            
        var s1map = new int[26];
        var s2map = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            s1map[s1[i] - 'a']++;
            s2map[s2[i] - 'a']++;
        }

        var count = 0;
        
        for (int i = 0; i < 26; i++)
            if (s1map[i] == s2map[i])
                count++;

        for (int i = 0; i < s2.Length - s1.Length; i++)
        {
            var r = s2[i + s1.Length] - 'a';
            var l = s2[i] - 'a';
            if (count == 26)
                return true;
            s2map[r]++;
            if (s2map[r] == s1map[r])
                count++;
            else if (s2map[r] == s1map[r] + 1)
                count--;
            s2map[l]--;
            if (s2map[l] == s1map[l])
                count++;
            else if (s2map[l] == s1map[l] - 1)
                count--;
        }
        
        return count == 26;
    }
}

[Test]
[TestCase("ab", "eidbaooo", true)]
[TestCase("ab", "eidboaoo", false)]
[TestCase("hello", "ooolleoooleh", false)]
[TestCase("adc", "dcda", true)]
public void SolutionTests(string s1, string s2, bool expected)
{
    var actual = new Solution().CheckInclusion(s1, s2);
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