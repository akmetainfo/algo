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
public void SpiralOrder(int[][] matrix, List<int> expected)
{
	var actual = new Solution().SpiralOrder(matrix);
	Assert.That(actual, Is.EqualTo(expected));
}

private static IEnumerable<object[]> TestCases()
{
	yield return new object[]
	{
		new int[][]
		{
			new int[]{ 1, 2, 3 },
			new int[]{ 4, 5, 6 },
			new int[]{ 7, 8, 9 },
		},
		new List<int> {1,2,3,6,9,8,7,4,5 },
	};

	yield return new object[]
	{
		new int[][]
		{
			new int[] {  1,  2,  3,  4 },
			new int[] {  5,  6,  7,  8 },
			new int[] {  9, 10, 11, 12 },
		},
		new List<int> { 1,2,3,4,8,12,11,10,9,5,6,7 },
	};

	yield return new object[]
	{
		new int[][]
		{
			new int[] {  3, 2 },
		},
		new List<int> { 3, 2 },
	};

	yield return new object[]
	{
		new int[][]
		{
			new int[] {  3 },
			new int[] {  2 },
		},
		new List<int> { 3, 2 },
	};
}

// https://leetcode.com/explore/item/1168
#region Условие задачи
/*

Given an m x n matrix, return all elements of the matrix in spiral order.
 

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:

Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

 

Constraints:

    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 10
    -100 <= matrix[i][j] <= 100

Hint #1

Well for some problems, the best way really is to come up with some algorithms for simulation. Basically, you need to simulate what the problem asks us to do.

Hint #2

We go boundary by boundary and move inwards. That is the essential operation. First row, last column, last row, first column and then we move inwards by 1 and then repeat. That's all, that is all the simulation that we need.

Hint #3

Think about when you want to switch the progress on one of the indexes. If you progress on

i

out of

[i, j]

, you'd be shifting in the same column. Similarly, by changing values for

j

, you'd be shifting in the same row. Also, keep track of the end of a boundary so that you can move inwards and then keep repeating. It's always best to run the simulation on edge cases like a single column or a single row to see if anything breaks or not.


*/

#endregion

public class Solution
{
	public enum Direction { Right, Down, Left, Up }
	
	public IList<int> SpiralOrder(int[][] matrix)
	{
		if (matrix.Length == 0)
			return new int[0];

		var iMax = matrix.Length;
		var jMax = matrix[0].Length;
		var iMin = 0;
		var jMin = 0;

		var max = iMax * jMax;
		
		var result = new List<int>(max);
		
		var i = 0;
		var j = 0;
		
		var direction = Direction.Right;
		
		for(var pointer = 0; pointer < max; )
		{
			switch (direction)
			{
				case Direction.Right:
					while(j<jMax)
					{
						result.Add(matrix[i][j]);
						j++;
						pointer++;
					}
					i++; j--; jMax--; direction = Direction.Down;
					break;
					
				case Direction.Down:
					while (i < iMax)
					{
						result.Add(matrix[i][j]);
						i++;
						pointer++;
					}
					i--; j--; iMax--; direction = Direction.Left;
					break;

				case Direction.Left:
					while (j >= jMin)
					{
						result.Add(matrix[i][j]);
						j--;
						pointer++;
					}
					i--; j++; jMin++; direction = Direction.Up;
					break;

				case Direction.Up:
					while (i > iMin)
					{
						result.Add(matrix[i][j]);
						i--;
						pointer++;
					}
					i++; j++; iMin++; direction = Direction.Right;
					break;
					
				default:
					throw new ArgumentOutOfRangeException(nameof(direction));
			}
		}

		return result;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще ровнёхонько на вершине нормального распределения

// Решение из моей же группы (такое же, но а) опять начинают обход с -1 и б) немного код иначе)
public IList<int> SpiralOrder1(int[][] matrix)
{
	var direction = 0; // 0, right, 1 down, 2 left, 3 up
	var result = new List<int>();
	var row = 0;
	var col = 0;
	var numRows = matrix.Length;
	var numCols = matrix[0].Length;
	var minRowCompleted = -1;
	var maxRowCompleted = numRows;
	var minColCompleted = -1;
	var maxColCompleted = numCols;
	var endRow = -1;
	var endCol = numCols - 1;
	while (result.Count < numRows * numCols)
	{
		result.Add(matrix[row][col]);
		switch (direction)
		{
			case 0: // right
				if (col < endCol)
				{
					col++;
				}
				else
				{
					direction = 1;
					minRowCompleted = row;
					endRow = maxRowCompleted - 1;
					row++;
				}
				break;
			case 1: // down
				if (row < endRow)
				{
					row++;
				}
				else
				{
					direction = 2;
					maxColCompleted = col;
					endCol = minColCompleted + 1;
					col--;
				}
				break;
			case 2: //left
				if (col > endCol)
				{
					col--;
				}
				else
				{
					direction = 3;
					maxRowCompleted = row;
					row--;
					endRow = minRowCompleted + 1;
				}
				break;
			case 3: //up
				if (row > endRow)
				{
					row--;
				}
				else
				{
					direction = 0;
					minColCompleted = col;
					col++;
					endCol = maxColCompleted - 1;
				}
				break;

		}
	}

	return result;
}

// Чуть лучше. И надо сказать более наглядно
public IList<int> SpiralOrder2(int[][] matrix)
{
	IList<int> result = new List<int>();
	int startRow = 0, endRow = matrix.Length - 1, startCol = 0, endCol = matrix[0].Length - 1;
	int dir = 0;

	while (startRow <= endRow && startCol <= endCol)
	{
		switch (dir)
		{
			case 0://right
				for (int col = startCol; col <= endCol; col++) result.Add(matrix[startRow][col]);
				startRow++;
				break;
			case 1://down
				for (int row = startRow; row <= endRow; row++) result.Add(matrix[row][endCol]);
				endCol--;
				break;
			case 2://left
				for (int col = endCol; col >= startCol; col--) result.Add(matrix[endRow][col]);
				endRow--;
				break;
			case 3:// up
				for (int row = endRow; row >= startRow; row--) result.Add(matrix[row][startCol]);
				startCol++;
				break;

		}

		dir = (dir + 1) % 4;
	}

	return result;
}

// Ещё лучше. Вариант интересен рекурсией.
public class Solution3
{
	public IList<int> SpiralOrder(int[][] matrix)
	{
		List<int> results = new List<int>();

		if (matrix == null) return results;
		if (matrix.Length == 0) return results;
		if (matrix[0].Length == 0) return results;

		SpiralOrder(matrix, 0, results);

		return results;
	}

	public void SpiralOrder(int[][] matrix, int recursionLevel, List<int> results)
	{
		int topRow = recursionLevel;
		int bottomRow = (matrix.Length - 1) - recursionLevel;
		int leftColumn = recursionLevel;
		int rightColumn = (matrix[0].Length - 1) - recursionLevel;

		if (topRow > bottomRow) return;
		if (leftColumn > rightColumn) return;

		for (int col = leftColumn; col <= rightColumn; col++)
			results.Add(matrix[topRow][col]);

		for (int row = (topRow + 1); row <= bottomRow; row++)
			results.Add(matrix[row][rightColumn]);

		for (int col = rightColumn - 1; col >= leftColumn && (topRow != bottomRow); col--)
			results.Add(matrix[bottomRow][col]);

		for (int row = (bottomRow - 1); row >= (topRow + 1) && (leftColumn != rightColumn); row--)
			results.Add(matrix[row][leftColumn]);

		SpiralOrder(matrix, recursionLevel + 1, results);
	}
}

// И ещё быстрее. Интересно тем, что обошлись без направления - просто они идут подряд, недурно.
public IList<int> SpiralOrder4(int[][] matrix)
{
	IList<int> nums = new List<int>();
	int top = -1, left = -1, bottom = matrix.Length, right = matrix[0].Length;
	int begin = -1, total = matrix.Length * matrix[0].Length;
	while (left < right || top < bottom)
	{
		begin = left + 1;
		while (begin < right && top + 1 < bottom)
		{
			nums.Add(matrix[top + 1][begin]);
			begin += 1;
		}
		top += 1;
		begin = top + 1;
		while (begin < bottom && right - 1 > left)
		{
			nums.Add(matrix[begin][right - 1]);
			begin += 1;
		}
		right -= 1;
		begin = right - 1;
		while (begin > left && bottom - 1 > top)
		{
			nums.Add(matrix[bottom - 1][begin]);
			begin -= 1;
		}
		bottom -= 1;
		begin = bottom - 1;
		while (begin > top && left + 1 < right)
		{
			nums.Add(matrix[begin][left + 1]);
			begin -= 1;
		}
		left += 1;
	}
	return nums;
}

// И ещё.
public IList<int> SpiralOrder5(int[][] matrix)
{
	var size = matrix.Length * matrix[0].Length;
	var result = new List<int>(size);

	var colL = 0;
	var colR = matrix[0].Length - 1;
	var rowT = 0;
	var rowB = matrix.Length - 1;
	while (result.Count < size)
	{
		for (int i = colL; i <= colR; i++)
		{
			result.Add(matrix[rowT][i]);
		}
		rowT++;

		for (int i = rowT; i <= rowB; i++)
		{
			result.Add(matrix[i][colR]);
		}
		colR--;

		if (result.Count == size)
		{
			break;
		}

		for (int i = colR; i >= colL; i--)
		{
			result.Add(matrix[rowB][i]);
		}
		rowB--;

		for (int i = rowB; i >= rowT; i--)
		{
			result.Add(matrix[i][colL]);
		}
		colL++;
	}

	return result;
}

// Типа топчик.
public IList<int> SpiralOrder6(int[][] grid)
{
	var rowLen = grid.Length;
	var colLen = grid[0].Length;
	var r1 = 0;
	var r2 = rowLen - 1;
	var c1 = 0;
	var c2 = colLen - 1;
	var res = new List<int>();
	while (r1 <= r2 && c1 <= c2)
	{
		for (int i = c1; i <= c2; i++)
		{
			res.Add(grid[r1][i]);
		}

		r1++;

		for (int i = r1; i <= r2; i++)
		{
			res.Add(grid[i][c2]);
		}
		c2--;
		if (r1 <= r2)
		{
			for (int i = c2; i >= c1; i--)
			{
				res.Add(grid[r2][i]);
			}
			r2--;
		}
		if (c1 <= c2)
		{
			for (int i = r2; i >= r1; i--)
			{
				res.Add(grid[i][c1]);
			}
		}
		c1++;
	}

	return res;
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