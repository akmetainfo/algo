<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

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

// Define other methods and classes here

[Test]
[TestCase(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new int[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
[TestCase(new int[] { 73, 74 }, new int[] { 1, 0 })]
[TestCase(new int[] { 73 }, new int[] { 0 })]
[TestCase(new int[] { 73, 72 }, new int[] { 0, 0 })]
[TestCase(new int[] { 32, 31, 33 }, new int[] { 2, 1, 0 })]
public void DailyTemperatures(int[] t, int[] expected)
{
	var actual = new Solution().DailyTemperatures(t);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/1363
#region Условие задачи
/*

 Given a list of daily temperatures T, return a list such that, for each day in the input, tells you how many days you would have to wait until a warmer temperature. If there is no future day for which this is possible, put 0 instead.

For example, given the list of temperatures T = [73, 74, 75, 71, 69, 72, 76, 73], your output should be [1, 1, 4, 2, 1, 1, 0, 0].

Note: The length of temperatures will be in the range [1, 30000]. Each temperature will be an integer in the range [30, 100].

Hint #1

If the temperature is say, 70 today, then in the future a warmer temperature must be either 71, 72, 73, ..., 99, or 100. We could remember when all of them occur next.

*/

#endregion

public class Solution
{
	// Approach 1 'Next Array' https://leetcode.com/problems/daily-temperatures/solution/
	/*
		Approach #1: Next Array [Accepted]
		
		Intuition
		
		The problem statement asks us to find the next occurrence of a warmer temperature. Because temperatures can only be in [30, 100], if the temperature right now is say, T[i] = 50, we only need to check for the next occurrence of 51, 52, ..., 100 and take the one that occurs soonest.
		
		Algorithm
		
		Let's process each i in reverse (decreasing order). At each T[i], to know when the next occurrence of say, temperature 100 is, we should just remember the last one we've seen, next[100].
		
		Then, the first occurrence of a warmer value occurs at warmer_index, the minimum of next[T[i]+1], next[T[i]+2], ..., next[100].
		
	
		Complexity Analysis
		
		    Time Complexity: O(NW), where NNN is the length of T and WWW is the number of allowed values for T[i]. Since W=71W = 71W=71, we can consider this complexity O(N).
		
		    Space Complexity: O(N+W), where NNN is the length of T and WWW is the number of allowed values for T[i]. Since W=71W = 71W=71, we can consider the space complexity as O(N).
		
	
	*/
	public int[] DailyTemperatures1(int[] T)
	{
		var ans = new int[T.Length];
		var next = new int[101];
		
		for (int i = 0; i < next.Length; i++)
			next[i] = int.MaxValue;
		
		for (int i = T.Length - 1; i >= 0; --i)
		{
			int warmer_index = int.MaxValue;
			
			for (int t = T[i] + 1; t <= 100; ++t)
			{
				if (next[t] < warmer_index)
					warmer_index = next[t];
			}
			
			if (warmer_index < int.MaxValue)
				ans[i] = warmer_index - i;
				
			next[T[i]] = i;
		}
		return ans;
	}

	// Approach 2: 'Stack' https://leetcode.com/problems/daily-temperatures/solution/
	/*
		Approach #2: Stack [Accepted]
		
		Intuition
		
		Consider trying to find the next warmer occurrence at T[i]. What information (about T[j] for j > i) must we remember?
		
		Say we are trying to find T[0]. If we remembered T[10] = 50, knowing T[20] = 50 wouldn't help us, as any T[i] that has its next warmer ocurrence at T[20] would have it at T[10] instead. However, T[20] = 100 would help us, since if T[0] were 80, then T[20] might be its next warmest occurrence, while T[10] couldn't.
		
		Thus, we should remember a list of indices representing a strictly increasing list of temperatures. For example, [10, 20, 30] corresponding to temperatures [50, 80, 100]. When we get a new temperature like T[i] = 90, we will have [5, 30] as our list of indices (corresponding to temperatures [90, 100]). The most basic structure that will satisfy our requirements is a stack, where the top of the stack is the first value in the list, and so on.
		
		Algorithm
		
		As in Approach #1, process indices i in descending order. We'll keep a stack of indices such that T[stack[-1]] < T[stack[-2]] < ..., where stack[-1] is the top of the stack, stack[-2] is second from the top, and so on; and where stack[-1] < stack[-2] < ...; and we will maintain this invariant as we process each temperature.
		
		After, it is easy to know the next occurrence of a warmer temperature: it's simply the top index in the stack.
		
		Here is a worked example of the contents of the stack as we work through T = [73, 74, 75, 71, 69, 72, 76, 73] in reverse order, at the end of the loop (after we add T[i]). For clarity, stack only contains indices i, but we will write the value of T[i] beside it in brackets, such as 0 (73).
		
		    When i = 7, stack = [7 (73)]. ans[i] = 0.
		    When i = 6, stack = [6 (76)]. ans[i] = 0.
		    When i = 5, stack = [5 (72), 6 (76)]. ans[i] = 1.
		    When i = 4, stack = [4 (69), 5 (72), 6 (76)]. ans[i] = 1.
		    When i = 3, stack = [3 (71), 5 (72), 6 (76)]. ans[i] = 2.
		    When i = 2, stack = [2 (75), 6 (76)]. ans[i] = 4.
		    When i = 1, stack = [1 (74), 2 (75), 6 (76)]. ans[i] = 1.
		    When i = 0, stack = [0 (73), 1 (74), 2 (75), 6 (76)]. ans[i] = 1.
	
		Complexity Analysis
		
	    Time Complexity: O(N), where NNN is the length of T and WWW is the number of allowed values for T[i]. Each index gets pushed and popped at most once from the stack.
	
	    Space Complexity: O(W). The size of the stack is bounded as it represents strictly increasing temperatures.
	
	*/
	public int[] DailyTemperatures(int[] T)
	{
		int[] ans = new int[T.Length];
		var stack = new Stack<int>();
		for (int i = T.Length - 1; i >= 0; --i)
		{
			while (stack.Count != 0 && T[i] >= T[stack.Peek()]) stack.Pop();
			ans[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
			stack.Push(i);
		}
		return ans;
	}

	// without using stack, works on my PC, but got 'Time Limit Exceeded' on leetcode
	public int[] DailyTemperaturesMy(int[] T)
	{
		var result = new int[T.Length];
		for (int i = 0; i < T.Length; i++)
		{
			var pointer = i;
			while (++pointer < T.Length)
			{
				if (T[pointer] > T[i])
				{
					result[i] = pointer - i;
					break;
				}
			}
		}

		return result;
	}
}

#region Хорошие алгоритмы-победители

// https://leetcode.com/problems/daily-temperatures/solution/

#endregion

#region unit tests runner

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