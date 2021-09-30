<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 567. Permutation in String
// https://leetcode.com/problems/permutation-in-string/

/*
    Time: O(N + 26 * (M - N) * N) where N = s1.Length, M = s2.Length
    Space: O(1)
    
    Time Limit Exceeded (as said in solution tab, but really not)
*/
public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        var s1map = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; i++)
        {
            if (!s1map.ContainsKey(s1[i]))
                s1map.Add(s1[i], 0);

            s1map[s1[i]]++;
        }

        for (int i = 0; i <= s2.Length - s1.Length; i++)
        {
            var s2map = new Dictionary<char, int>();
            for (int j = 0; j < s1.Length; j++)
            {
                if (!s2map.ContainsKey(s2[i + j]))
                    s2map.Add(s2[i + j], 0);

                s2map[s2[i + j]]++;
            }
            if (Matches(s1map,s2map))
                return true;
        }
        return false;
    }

    private bool Matches(Dictionary<char, int> s1map, Dictionary<char, int> s2map)
    {
        return s1map.Count == s2map.Count && !s1map.Except(s2map).Any();;
    }
}

[Test]
[TestCase("ab", "eidbaooo", true)]
[TestCase("ab", "eidboaoo", false)]
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