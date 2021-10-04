<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 77. Combinations
// https://leetcode.com/problems/combinations/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    private enum State
    {
        Initial,
        Skipped,
        Taken
    }

    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();

        // This data represents n simple state machines. We use 
        // count variable to keep track of how many of those 
        // machines are in 'Taken' state.
        var state = new State[n];
        var idx = 0;
        var count = 0;

        while (idx >= 0)
        {
            if (idx == state.Length)
            {
                idx--;
            }
            else if (state[idx] == State.Initial)
            {
                state[idx] = State.Skipped;
                idx++;

                // This condition is checking if there's still enough 
                // unprocessed values to add up to k total values.
                if (state.Length - idx < k - count)
                {
                    idx--;
                }
            }
            else if (state[idx] == State.Skipped)
            {
                state[idx] = State.Taken;
                idx++;
                count++;

                if (count == k)
                {
                    // Once we've got k total values save 
                    // result and stop further propagation.
                    result.Add(Enumerable.Range(0, n).Where(x => state[x] == State.Taken).Select(x => x + 1).ToList());
                    idx--;
                }
            }
            else // state[idx] == State.Taken
            {
                state[idx] = State.Initial;
                count--;
                idx--;
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
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();

        var odometer = new int[k];

        var stop = new int[k]; //final value for odometer
        stop[0] = n - k + 1;
        for (int i = 1; i < k; i++) stop[i] = stop[i - 1] + 1;

        var position = 0;
        odometer[0] = 1;
        while (position >= 0)
        {
            // set all the remaining digits for next round
            for (int i = position + 1; i < k; i++)
                odometer[i] = odometer[i - 1] + 1;

            // increment the last digit of the odometer to the stop value and add them all to the answer
            do
            {
                var newAnswer = new int[k];
                Array.Copy(odometer, newAnswer, k);
                result.Add(newAnswer);
                odometer[^1]++;
            } while (odometer[^1] <= n);

            // find the next position in the odometer to increent
            position = k - 2;
            while ((position >= 0) && ((++odometer[position]) > stop[position]))
                position--;
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
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();

        var p = new int[k];

        for (int i = 0; i < k; i++)
            p[i] = i + 1;

        while (true)
        {
            result.Add(p.ToList());

            int i = k - 1;

            while (i >= 0 && p[i] == n - k + i + 1)
                i--;

            if (i < 0)
                return result;

            var c = ++p[i];

            for (int j = i + 1; j < k; j++)
                p[j] = ++c;
        }
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        4,
        2,
        new List<IList<int>> {
            new List<int> {2, 4},
            new List<int> {3, 4},
            new List<int> {2, 3},
            new List<int> {1, 2},
            new List<int> {1, 3},
            new List<int> {1, 4},
        },
    };
    yield return new object[]
    {
        1,
        1,
        new List<IList<int>> {
            new List<int> {1,}
        },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int n, int k, IList<IList<int>> expected)
{
    var actual = new Solution().Combine(n, k);
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