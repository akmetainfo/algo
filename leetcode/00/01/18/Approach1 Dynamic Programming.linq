<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 118. Pascal's Triangle
// https://leetcode.com/problems/pascals-triangle/

/*
    Time: O(N ^ 2) where N is numRows
    Space: O(N ^ 2)
*/
public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var triangle = new List<IList<int>>();
        triangle.Add(new List<int>() { 1 });

        for (var rowNum = 1; rowNum < numRows; rowNum++)
        {
            var row = new List<int>();
            var prevRow = triangle[rowNum - 1];

            // The first row element is always 1.
            row.Add(1);

            // Each triangle element (other than the first and last of each row)
            // is equal to the sum of the elements above-and-to-the-left and
            // above-and-to-the-right.
            for (int j = 1; j < rowNum; j++)
            {
                row.Add(prevRow[j - 1] + prevRow[j]);
            }

            // The last row element is always 1.
            row.Add(1);

            triangle.Add(row);
        }

        return triangle;
    }
}

/*
    Time: O(N ^ 2) where N is numRows
    Space: O(N ^ 2)
*/
public class Solution1
{
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();
        result.Add(new List<int>() { 1 });
        
        for(var i = 0; i < numRows - 1; i++)
        {
            var row = new List<int>();
            row.Add(1);
            
            for(var j = 0; j < i; j++)
            {
                var prevRow = result[i];
                row.Add(prevRow[j] + prevRow[j+1]);
            }
            
            row.Add(1);
            result.Add(row);
        }
        
        return result;
    }
}


[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int numRows, IList<IList<int>> expected)
{
    var actual = new Solution().Generate(numRows);
    Assert.That(actual, Is.EqualTo(expected));
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        1,
        new List<IList<int>> {
            new List<int> { 1 },
        },
    };

    yield return new object[]
    {
        2,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
        },
    };

    yield return new object[]
    {
        3,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
        },
    };

    yield return new object[]
    {
        4,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
        },
    };

    yield return new object[]
    {
        5,
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
            new List<int> { 1, 4, 6, 4, 1 },
        },
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