<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1791. Find Center of Star Graph
// https://leetcode.com/problems/find-center-of-star-graph/

/*
    Time: O(N), where N is node's count
    Space: O(N)    
*/
public class Solution
{
    public int FindCenter(int[][] edges)
    {
        var dict = new Dictionary<int, int>();
        
        foreach (var edge in edges)
        {
            int vertex;
            
            vertex = edge[0];

            if (!dict.ContainsKey(vertex))
                dict.Add(vertex, 0);
            dict[vertex]++;

            vertex = edge[1];

            if (!dict.ContainsKey(vertex))
                dict.Add(vertex, 0);
            dict[vertex]++;
        }
        
        foreach (var pair in dict)
            if (pair.Value == edges.Length) // also: edges.Length = dict.Count - 1
                return pair.Key;
        
        throw new Exception("The given edges must represent a valid star graph!");
    }
}


/*
    Time: O(N)
    Space: O(?)
*/
public class Solution1
{
    public int FindCenter(int[][] edges)
    {
        return edges.Take(2)
                    .SelectMany(x => x)
                    .GroupBy(x => x)
                    .OrderBy(x => x.Count())
                    .Select(x => x.Key)
                    .LastOrDefault();
    }
}


private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][]
        {
            new[] {1,2},
            new[] {2,3},
            new[] {4,2},
        },
        2
    };
    yield return new object[]
    {
        new int[][]
        {
            new[] {1,2},
            new[] {5,1},
            new[] {1,3},
            new[] {1,4},
        },
        1
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] edges, int expected)
{
    var actual = new Solution().FindCenter(edges);
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