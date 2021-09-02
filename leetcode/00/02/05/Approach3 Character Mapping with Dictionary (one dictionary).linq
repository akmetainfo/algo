<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 205. Isomorphic Strings
// https://leetcode.com/problems/isomorphic-strings/

/*
    Time: O(n^2) because ContainsValue is O(n)
    Space: O(n)
*/
public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        var mapping = new Dictionary<char,char>();

        for(int i = 0; i < s.Length; i++)
        {
            //1) s[i] exists; but not mapped to t[i]
            if (mapping.ContainsKey(s[i]) && mapping[s[i]]!=t[i])
                return false;
            //2) t[i] exists in values; but s[i] is not in key => another c is mapped to t[i]
            if (mapping.ContainsValue(t[i]) && !mapping.ContainsKey(s[i]))
                return false;
            //3) s[i] is never mapped before; we can just map s[i];
            if (!mapping.ContainsKey(s[i]))
                mapping.Add(s[i],t[i]);
        }
        
        return true;
    }
}

/*
    Time: O(n^2) because ContainsValue is O(n)
    Space: O(n)
*/
public class Solution1
{
    public bool IsIsomorphic(string s, string t)
    {
        var dict = new Dictionary<char, char>();
          
        for(int i = 0; i < s.Length; i++)
        {
		    // characters of string s are keys
            if(dict.ContainsKey(s[i]))
            {
                if(dict[s[i]] != t[i])
                    return false;
            }
			// if value was mapped to some other key previously
            else if(dict.ContainsValue(t[i]))
            {
                return false;
            }
            else
            {              
                dict.Add(s[i], t[i]);
            }
        }
        
        return true;
    }
}


/*
    Time: O(n^2) because ContainsValue is O(n)
    Space: O(n)
*/
public class Solution2
{
    public bool IsIsomorphic(string s, string t)
    {
        var dict = new Dictionary<char, char>();
        
        for(int i = 0; i < s.Length; i++)
        {
            if(dict.ContainsKey(s[i]) && dict[s[i]] != t[i])
                return false;
            else if (!dict.ContainsKey(s[i]) && dict.ContainsValue(t[i]))
                return false;
            else if (!dict.ContainsKey(s[i]) && !dict.ContainsValue(s[i]))
                dict.Add(s[i], t[i]);
        }
        
        return true;
    }
}

/*
    Time: O(n^2) because ContainsValue is O(n)
    Space: O(n)
*/
public class Solution3
{
    public bool IsIsomorphic(string s, string t)
    {
        var dict = new Dictionary<char, char>();
        
        for(var i = 0; i < s.Length; i++)
        {
            if(!dict.ContainsKey(s[i]) && !dict.ContainsValue(t[i]))
                dict[s[i]] = t[i];
            else if(!dict.ContainsKey(s[i]) || dict[s[i]] != t[i])
                return false;
        }
        
        return true;
    }
}

[Test]
[TestCase("egg", "add", true)]
[TestCase("foo", "bar", false)]
[TestCase("paper", "title", true)]
[TestCase("bd", "bb", false)]
[TestCase("abcdefghijklmnopqrstuvwxyzva", "abcdefghijklmnopqrstuvwxyzck", false)]
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