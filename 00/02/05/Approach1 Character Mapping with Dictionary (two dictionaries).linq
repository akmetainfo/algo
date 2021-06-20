<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 205. Isomorphic Strings
// https://leetcode.com/problems/isomorphic-strings/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        var mappingDictStoT = new int[256];
        Array.Fill(mappingDictStoT, -1);
        
        var mappingDictTtoS = new int[256];
        Array.Fill(mappingDictTtoS, -1);
        
        for (int i = 0; i < s.Length; ++i) {
            char c1 = s[i];
            char c2 = t[i];
            
            // Case 1: No mapping exists in either of the dictionaries
            if (mappingDictStoT[c1] == -1 && mappingDictTtoS[c2] == -1)
            {
                mappingDictStoT[c1] = c2;
                mappingDictTtoS[c2] = c1;
            }
            
            // Case 2: Ether mapping doesn't exist in one of the dictionaries or Mapping exists and
            // it doesn't match in either of the dictionaries or both 
            else if (!(mappingDictStoT[c1] == c2 && mappingDictTtoS[c2] == c1))
            {
                return false;
            }
        }
        
        return true;
    }
}

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution1
{
    public bool IsIsomorphic(string s, string t)
    {
        var mappingDictStoT = new Dictionary<char, char>();
        var mappingDictTtoS = new Dictionary<char, char>();
        
        for (int i = 0; i < s.Length; ++i) {
            char c1 = s[i];
            char c2 = t[i];
            
            // Case 1: No mapping exists in either of the dictionaries
            if (!mappingDictStoT.ContainsKey(c1) && !mappingDictTtoS.ContainsKey(c2))
            {
                mappingDictStoT.Add(c1, c2);
                mappingDictTtoS.Add(c2, c1);
            }
            
            // Case 2: Ether mapping doesn't exist in one of the dictionaries
            else if (mappingDictStoT.ContainsKey(c1) && !mappingDictTtoS.ContainsKey(c2) ||
                     !mappingDictStoT.ContainsKey(c1) && mappingDictTtoS.ContainsKey(c2)
                     )
            {
                return false;
            }
            // or Mapping exists and it doesn't match in either of the dictionaries or both 
            else if (!(mappingDictStoT[c1] == c2 && mappingDictTtoS[c2] == c1))
            {
                return false;
            }
        }
        
        return true;
    }
}

[Test]
[TestCase("egg", "add", true)]
[TestCase("foo", "bar", false)]
[TestCase("paper", "title", true)]
[TestCase("bd", "bb", false)]
public void SolutionTests(string s, string t, bool expected)
{
	var actual = new Solution().IsIsomorphic(s,t);
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