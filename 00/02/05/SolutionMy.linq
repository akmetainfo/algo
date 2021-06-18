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
    1. Check the length of both string, if not equal - return false
    2. Create an Dictionary<char, char> (map of valid transforming)
    3. in the cycle (i) from first char to last char do:
          if dict contains value s[i]
                if dict contains key t[i] and its value is not equals to s[i] return false
          else
                if dict contains key t[i] and its value is not equals to s[i] return false
                add t, s to dictionary
    4. Return true
    */
    // The main problem to check if array contains more than one pair with same value
    // Solution is: revert key and value (store not pair k,v, but store pair v, k)
    public bool IsIsomorphic(string s, string t)
    {
        if(s.Length != t.Length)
            return false;
            
        var dict = new Dictionary<char, char>();
        
        for(var i = 0; i < s.Length; i++)
        {
            if(dict.ContainsValue(s[i]))
            {
                if(dict.ContainsKey(t[i]) && dict[t[i]] != s[i])
                    return false;
            }
            else
            {
                if(dict.ContainsKey(t[i]) && dict[t[i]] != s[i])
                    return false;
                dict.Add(t[i], s[i]);
            }
        }
        
        return true;
    }
}

[Test]
[TestCase("egg", "add", true)]
[TestCase("foo", "bar", false)]
[TestCase("paper", "title", true)]
[TestCase("badc", "baba", false)]
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