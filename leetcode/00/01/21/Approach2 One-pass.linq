<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 121. Best Time to Buy and Sell Stock
// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var result = 0;
        var minprice = prices[0];
        for(var i = 0; i < prices.Length; i++)
        {
            if(prices[i] < minprice) minprice = prices[i];
            var diff = prices[i] - minprice;
            if(diff > result) result = diff;
        }
        return result;
    }
}

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution0
{
    public int MaxProfit(int[] prices)
    {
        var result = 0;
        var minprice = int.MaxValue;
        for (int i = 0; i < prices.Length; i++) {
            if (prices[i] < minprice)
                minprice = prices[i];
            else if (prices[i] - minprice > result)
                result = prices[i] - minprice;
        }
        return result;
    }
}

[Test]
[TestCase(new int[] { 7,1,5,3,6,4 }, 5)]
[TestCase(new int[] { 7,6,4,3,1 }, 0)]
public void SolutionTests(int[] prices, int expected)
{
    var actual = new Solution().MaxProfit(prices);
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