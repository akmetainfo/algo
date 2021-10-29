<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1672. Richest Customer Wealth
// https://leetcode.com/problems/richest-customer-wealth/

/*
    Time: O(N*M)
    Space: O(1)
*/
public class Solution
{
    // Approach1 Trivial
    public int MaximumWealth(int[][] accounts)
    {
        return accounts.Max(i => i.Sum());
    }
}

/*
    Time: O(N*M)
    Space: O(1)
*/
public class Solution3
{
    // Approach1 Trivial
    public int MaximumWealth(int[][] accounts)
    {
        var max = 0;

        for (int i = 0; i < accounts.Length; i++)
        {
            var currentWhealth = accounts[i].Sum();
            if (currentWhealth > max) max = currentWhealth;
        }

        return max;
    }
}

/*
    Time: O(N*M)
    Space: O(1)
*/
public class Solution2
{
    public int MaximumWealth(int[][] accounts)
    {
        var result = int.MinValue;

        foreach (var account in accounts)
        {
            var whealth = account.Sum();

            if (whealth > result)
                result = whealth;
        }

        return result;
    }
}

/*
    Time: O(N*M)
    Space: O(1)
*/
public class Solution1
{
    public int MaximumWealth(int[][] accounts)
    {
        var result = int.MinValue;

        for (int i = 0; i < accounts.Length; i++)
        {
            var whealth = 0;

            for (int j = 0; j < accounts[0].Length; j++)
                whealth += accounts[i][j];

            if (whealth > result)
                result = whealth;
        }

        return result;
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] {1,2,3},
            new int[] {3,2,1},
        },
        6,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {1,5},
            new int[] {7,3},
            new int[] {3,5},
        },
        10,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {2,8,7},
            new int[] {7,1,3},
            new int[] {1,9,5},
        },
        17,
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] accounts, int expected)
{
    var actual = new Solution().MaximumWealth(accounts);
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