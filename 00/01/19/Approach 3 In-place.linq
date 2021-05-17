<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 119. Pascal's Triangle II
// https://leetcode.com/problems/pascals-triangle-ii/

/*
    Time: O(n^2)
    Space: O()
*/
public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        int[] result = new int[rowIndex + 1];

        result[0] = 1;

        for (int i = 1; i <= rowIndex; i++)
        {
            for (int j = i; j > 0; j--)
                result[j] += result[j - 1];
        }

        return result;
    }
}

/*
    Time: O()
    Space: O()
*/
public class Solution1
{
    // the new row can be created from previous row by doing in place calc row[i] += row[i-1] and then add a tailing 1.
    // But be careful that you need to do this in reverse order because you don't want the row[i-1]'s value be changed already when you are dealing with row[i]
    public IList<int> GetRow(int rowIndex)
    {
        var result = new List<int>();
        for (var i = 0; i <= rowIndex; i++)
        {
            result.Add(1);
            for (var j = result.Count - 2; j > 0; j--)
            {
                result[j] += result[j - 1];
            }
        }
        return result;
    }
}

/*
    Time: O()
    Space: O()
*/
public class Solution2
{
    // Think how we can move from k-1 to k (for example: 1331 -> 14641) in single for loop.
    // The basic idea is that second value of the sum (3 in this example) will become the first value of the sum in the next iteration of the loop.
    // Since we are overwriting the second value, we store it in a variable.
    public IList<int> GetRow(int rowIndex)
    {
        var result = new int[rowIndex + 1];
        result[0] = 1;

        for (int i = 1; i <= rowIndex; i++)
        {
            int first = result[0];
            for (int j = 1; j < i; j++)
            {
                int second = result[j];
                result[j] = first + second;
                first = second;
            }

            result[i] = 1;
        }
        return result;
    }
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int numRows, IList<int> expected)
{
    var actual = new Solution().GetRow(numRows);
    Assert.That(actual, Is.EqualTo(expected));
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        0,
        new List<int> { 1 },
    };

    yield return new object[]
    {
        1,
        new List<int> { 1, 1 },
    };

    yield return new object[]
    {
        2,
        new List<int> { 1, 2, 1 },
    };

    yield return new object[]
    {
        3,
        new List<int> { 1, 3, 3, 1 },
    };

    yield return new object[]
    {
        4,
        new List<int> { 1, 4, 6, 4, 1 },
    };

    yield return new object[]
    {
        30,
        new List<int> { 1,30,435,4060,27405,142506,593775,2035800,5852925,14307150,30045015,54627300,86493225,119759850,145422675,155117520,145422675,119759850,86493225,54627300,30045015,14307150,5852925,2035800,593775,142506,27405,4060,435,30,1 },
    };
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