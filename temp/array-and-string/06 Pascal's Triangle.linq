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
[TestCaseSource(nameof(TestCases))]
public void PascalsTriangle(int numRows, IList<IList<int>> expected)
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

// https://leetcode.com/explore/item/1170
#region Условие задачи
/*

Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it.

Example:

Input: 5
Output:
[
     [1],
    [1,1],
   [1,2,1],
  [1,3,3,1],
 [1,4,6,4,1]
]

*/

#endregion

public class Solution
{
	public IList<IList<int>> Generate(int numRows)
	{
		var result = new List<IList<int>>();
		
		if(numRows == 0)
			return result;
			
		for(var i = 1; i < numRows + 1; i++)
		{
			if(i == 1)
			{
				result.Add(new List<int> {1});
				continue;
			}

			if (i == 2)
			{
				result.Add(new List<int> { 1, 1 });
				continue;
			}
			
			var row = new List<int>();
			
			for(var j = 0; j < i; j++)
			{
				if(j == 0 || j == i -1)
				{
					row.Add(1);
				}
				else
				{
					row.Add(result[i-2][j-1] + result[i-2][j]);
				}
			}
			//row.Dump();
			
			result.Add(row);
		}
			
		return result;
	}
}

#region Solution described

/*

Approach 1: Dynamic Programming

Intuition

If we have the a row of Pascal's triangle, we can easily compute the next row by each pair of adjacent values.

Algorithm

Although the algorithm is very simple, the iterative approach to constructing Pascal's triangle can be classified as dynamic programming because we construct each row based on the previous row.

First, we generate the overall triangle list, which will store each row as a sublist. Then, we check for the special case of 000, as we would otherwise return [1][1][1]. If numRows>0numRows > 0numRows>0, then we initialize triangle with [1][1][1] as its first row, and proceed to fill the rows as follows:

Complexity Analysis

Time complexity : O(numRows^2)

Although updating each value of triangle happens in constant time, it is performed O(numRows^2) times. To see why, consider how many overall loop iterations there are. The outer loop obviously runs numRowsnumRowsnumRows times, but for each iteration of the outer loop, the inner loop runs rowNumrowNumrowNum times. Therefore, the overall number of triangle updates that occur is 1+2+3+…+numRows1 + 2 + 3 + \ldots + numRows1+2+3+…+numRows, which, according to Gauss' formula, is

numRows(numRows+1)2=numRows2+numRows2=numRows22+numRows2=O(numRows2) \begin{aligned} \frac{numRows(numRows+1)}{2} &= \frac{numRows^2 + numRows}{2} \\ &= \frac{numRows^2}{2} + \frac{numRows}{2} \\ &= O(numRows^2) \end{aligned} 2numRows(numRows+1)​​=2numRows2+numRows​=2numRows2​+2numRows​=O(numRows2)​

Space complexity : O(numRows^2)

Because we need to store each number that we update in triangle, the space requirement is the same as the time complexity.

*/

/* User's comments

https://youtu.be/7pOzP9m_bX8

*/

#endregion

#region Хорошие алгоритмы-победители

// Ну мой вообще практически идеальный

// Решение из моей группы, чуть оптимальнее
public IList<IList<int>> Generate1(int numRows)
{
	var triangle = new List<IList<int>>(numRows);
	for (var i = 1; i <= numRows; i++)
	{
		var row = new List<int>(i);
		row.Add(1);
		for (var j = 1; j < i - 1; j++)
		{
			row.Add(triangle[i - 2][j] + triangle[i - 2][j - 1]);
		}
		if (i > 1) row.Add(1);
		triangle.Add(row);
	}
	return triangle;
}

// Типа топчик (оптимальнее на какие-то копейки)
public class Solution2
{
	/* // Mine Runtime 74.52% Memory 23.84%
    public IList<IList<int>> Generate(int numRows) {
        var pascal = new List<IList<int>>();
        for (int row = 0; row < numRows; row++)
        {
            var r = new List<int>();
            r.Add(1);
            for (int i = 1; i <= row; i++)
            {
                if (i == row)
                {
                    r.Add(1);
                }
                else
                {
                    r.Add(pascal[row-1][i-1] + pascal[row-1][i]);
                }
            }
            pascal.Add(r);
        }
        return pascal;
    }
    */
	// Mine 2: Runtime Memory
	public IList<IList<int>> Generate(int numRows)
	{
		var pascal = new int[numRows][];
		for (int row = 0; row < numRows; row++)
		{
			pascal[row] = new int[row + 1];
			pascal[row][0] = 1;
			for (int i = 1; i < row; i++)
			{
				pascal[row][i] = pascal[row - 1][i - 1] + pascal[row - 1][i];
			}
			pascal[row][row] = 1;
		}
		return pascal;
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