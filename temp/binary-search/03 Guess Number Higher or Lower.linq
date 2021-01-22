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
[TestCase(10, 6)]
[TestCase(1, 1)]
[TestCase(2, 1)]
[TestCase(2, 2)]
public void FindDiagonalOrder(int n, int pick)
{
	var solution = new Solution();
	solution.SetupPick(pick);
	var actual = solution.GuessNumber(n);
	Assert.That(actual, Is.EqualTo(pick));
}

// https://leetcode.com/explore/learn/card/binary-search/125/template-i/951/
#region Условие задачи
/*

We are playing the Guess Game. The game is as follows:

I pick a number from 1 to n. You have to guess which number I picked.

Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.

You call a pre-defined API int guess(int num), which returns 3 possible results:

    -1: The number I picked is lower than your guess (i.e. pick < num).
    1: The number I picked is higher than your guess (i.e. pick > num).
    0: The number I picked is equal to your guess (i.e. pick == num).

Return the number that I picked.

 

Example 1:

Input: n = 10, pick = 6
Output: 6

Example 2:

Input: n = 1, pick = 1
Output: 1

Example 3:

Input: n = 2, pick = 1
Output: 1

Example 4:

Input: n = 2, pick = 2
Output: 2

 

Constraints:

    1 <= n <= 231 - 1
    1 <= pick <= n



*/

#endregion

public class Solution : GuessGame
{
	public int GuessNumber(int n)
	{
		if(this.guess(1) == 0)
			return 1;
			
		if (this.guess(n) == 0)
			return n;

		var left = 1;
		var right = n;
		
		while(left <= right)
		{
			var mid = left + (right - left) / 2;
			
			var guessResult = this.guess(mid);
			
			if(guessResult == 0)
				return mid;
				
			if(guessResult == -1)
			{
				right = mid - 1;
			}
			else
			{
				left = mid + 1;
			}
		}
		
		throw new Exception("Really unexpected exception. Are you a liar?");
	}
}

public class GuessGame
{
	private int _pick;
	
	public void SetupPick(int pick)
	{
		this._pick = pick;
	}
	
	public int guess(int num)
	{
		if (this._pick < num) return -1;
		if (this._pick > num) return 1;
		
		return 0;
	}
}

#region Хорошие алгоритмы-победители

// Решение из моей группы
public class Solution1 : GuessGame
{
	public int GuessNumber(int n)
	{
		int low = 1;
		int high = n;
		int mid;
		int result;
		do
		{
			mid = low + (high - low) / 2;
			result = guess(mid);
			if (result == 1)
			{
				low = mid + 1;
			}
			else if (result == -1)
			{
				high = mid - 1;
			}
		} while (result != 0);
		return mid;
	}
}

// Решение чуть лучше
public class Solution2 : GuessGame
{
	public int GuessNumber(int n)
	{
		int low = 1;
		int high = n;
		while (low <= high)
		{
			int mid = low + (high - low) / 2;
			int res = guess(mid);
			if (res == 0)
				return mid;
			else if (res < 0)
				high = mid - 1;
			else
				low = mid + 1;
		}
		return -1;
	}
}

// Типа, победитель
public class Solution3 : GuessGame
{
	public int GuessNumber(int n)
	{
		int low = 1, high = n;

		while (low <= high)
		{
			int mid = low + (high - low) / 2;
			int guessed = guess(mid);

			if (guessed == 0)
			{
				return mid;
			}

			if (guessed == 1)
			{
				low = mid + 1;
			}
			else
			{
				high = mid - 1;
			}
		}

		return -1; // shouldn't hit here
	}
}

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