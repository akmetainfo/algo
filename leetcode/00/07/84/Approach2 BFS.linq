<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 784. Letter Case Permutation
// https://leetcode.com/problems/letter-case-permutation/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public IList<string> LetterCasePermutation(string s)
    {
        var queue = new Queue<string>();
        queue.Enqueue(s);

        for (int i = 0; i < s.Length; i++)
        {
            if (Char.IsDigit(s[i]))
                continue;
            else
            {
                int size = queue.Count;
                for (int j = 0; j < size; j++)
                {
                    var charArr = queue.Dequeue().ToArray();

                    charArr[i] = Char.ToUpper(charArr[i]);
                    queue.Enqueue(new string(charArr));

                    charArr[i] = Char.ToLower(charArr[i]);
                    queue.Enqueue(new string(charArr));
                }
            }
        }

        return queue.ToList();
    }
}

[Test]
[TestCase("a1b2", new string[] { "a1b2", "a1B2", "A1b2", "A1B2" })]
[TestCase("3z4", new string[] { "3z4", "3Z4" })]
[TestCase("12345", new string[] { "12345" })]
[TestCase("0", new string[] { "0" })]
public void SolutionTests(string s, string[] expected)
{
    var actual = new Solution().LetterCasePermutation(s);
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