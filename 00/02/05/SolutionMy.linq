<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 205. Isomorphic Strings
// https://leetcode.com/problems/isomorphic-strings/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution
{
    /*
    // main idea:
       not permitted mapping with same key or same value
       when the pair is full duplicate - insert it only once
    
    1. Check the length of both string, if not equal - return false
    2. Create an Dictionary<char, char> (map of valid transforming)
    3. in the cycle (i) from first char to last char do:
          if dict doesn't contains value s[i]
                if dict doesn't contains value t[i]
                    add s,t to dictionary
                else
                    return false (situation 'duplicate values')
          else
                if value doesn't match to t[i]
                    return false (situation 'diplicate keys')
    4. Return true
    */
    public bool IsIsomorphic(string s, string t)
    {
        if(s.Length != t.Length)
            return false;
            
        var dict = new Dictionary<char, char>();
        
        for(var i = 0; i < s.Length; i++)
        {
            if(!dict.ContainsKey(s[i]))
            {
                if(!dict.ContainsValue(t[i]))
                    dict.Add(s[i], t[i]);
                else
                    return false;
            }
            else
            {
                if(dict[s[i]] != t[i])
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