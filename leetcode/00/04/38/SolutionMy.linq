<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 438. Find All Anagrams in a String
// https://leetcode.com/problems/find-all-anagrams-in-a-string/


/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        var pDict = GetFrequency(p);
        
        for(var i = 0; i < s.Length; i++)
        {
            if(i + p.Length > s.Length)
                continue;
                
            if(!pDict.ContainsKey(s[i]))
                continue;
                
            var sDict = GetFrequency(s.Substring(i, p.Length));
                
            if(IsAnagram(sDict, pDict))
                result.Add(i);
        }
        
        return result;
    }
    
    private static Dictionary<char, int> GetFrequency(string s)
    {
        var result = new Dictionary<char, int>();
        
        foreach (var element in s)
        {
            if (!result.ContainsKey(element))
                result.Add(element, 0);

            result[element]++; ;
        }
        
        return result;
    }
    
    private static bool IsAnagram(Dictionary<char, int> s, Dictionary<char, int> t)
    {
        foreach (var element in s)
        {
            if (!t.ContainsKey(element.Key))
                return false;
                
            if(s[element.Key] != element.Value)
                return false;
        }

        foreach (var element in t)
        {
            if (!s.ContainsKey(element.Key))
                return false;
                
            if(t[element.Key] != element.Value)
                return false;
        }

        return true;
    }
}

/*
    Time: O(N^2)
    Space: O(N)
    
    Time Limit Exceeded
*/
public class Solution1
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        
        for(var i = 0; i < s.Length; i++)
        {
            if(i + p.Length > s.Length)
                continue;
                
            if(IsAnagram(p, s.Substring(i, p.Length)))
                result.Add(i);
        }
        
        return result;
    }
    
    // See leetcode 242. Valid Anagram
    private static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var storage = new Dictionary<char, int>();

        foreach (var element in s)
        {
            if (!storage.ContainsKey(element))
                storage.Add(element, 0);

            storage[element]++; ;
        }

        foreach (var element in t)
        {
            if (!storage.ContainsKey(element))
                storage.Add(element, 0);

            storage[element]--;
        }

        foreach (var element in storage)
        {
            if (element.Value != 0)
                return false;
        }

        return true;
    }
}


[Test]
[TestCase("cbaebabacd", "abc", new int[] { 0,6 })]
[TestCase("abab", "ab", new int[] { 0,1,2 })]
[TestCase("ababababab", "aab", new int[] { 0,2,4,6 })]
public void SolutionTests(string s, string p, int[] expected)
{
    var result = new Solution().FindAnagrams(s, p);
    Assert.That(result, Is.EquivalentTo(expected));
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