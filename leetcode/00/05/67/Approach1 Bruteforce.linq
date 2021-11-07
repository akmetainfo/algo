<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 567. Permutation in String
// https://leetcode.com/problems/permutation-in-string/

/*
    Time: O(N!)
    Space: O(N^2)
    
    Time Limit Exceeded
*/
public class Solution
{
    bool flag = false;

    public bool CheckInclusion(string s1, string s2)
    {
        Permute(s1, s2, 0);
        return flag;
    }

    public string Swap(string s, int i0, int i1)
    {
        if (i0 == i1)
            return s;
        var s1 = s.Substring(0, i0);
        var s2 = s.Substring(i0 + 1, i1 - i0 - 1);
        var s3 = s.Substring(i1 + 1);
        return s1 + s[i1] + s2 + s[i0] + s3;
    }

    void Permute(string s1, string s2, int l)
    {
        if (l == s1.Length)
        {
            if (s2.IndexOf(s1) >= 0)
                flag = true;
        }
        else
        {
            for (int i = l; i < s1.Length; i++)
            {
                s1 = Swap(s1, l, i);
                Permute(s1, s2, l + 1);
                s1 = Swap(s1, l, i);
            }
        }
    }
}

/*
    Time: O(N!)
    Space: O(N^2)
    
    Time Limit Exceeded
*/
public class Solution0
{
    public bool CheckInclusion(string s1, string s2)
    {
        var flag = false;
        Permute(s1, s2, ref flag, 0);
        return flag;
    }
    
    private void Permute(string str, string s2, ref bool flag, int start = 0)
    {
        if(start == str.Length)
        {
            if(s2.IndexOf(str) >= 0)
                flag = true;
            return;
        }
        
        for(var i = start; i < str.Length; i++)
        {
            str = Swap(str, start, i);
            Permute(str, s2, ref flag, i + 1);
            str = Swap(str, start, i);
        }
    }

    private string Swap(string src, int i, int j)
    {
        var bytes = src.ToCharArray();
        (bytes[i], bytes[j]) = (bytes[j], bytes[i]);
        return new string(bytes);
    }    
}

[Test]
[TestCase("ab", "eidbaooo", true)]
[TestCase("ab", "eidboaoo", false)]
[TestCase("hello", "ooolleoooleh", false)]
[TestCase("adc", "dcda", true)]
[TestCase("abcdxabcde", "abcdeabcdx", true)]
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