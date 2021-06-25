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
public void FindDiagonalOrder(int[][] nums, int[] expected)
{
	var actual = new Solution().FindDiagonalOrder(nums);
	//nums.Dump();
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
		new int[] {1,2,4,7,5,3,6,8,9 },
	};

	yield return new object[]
	{
		new int[][]
		{
			new int[] {  1,  2,  3,  4 },
			new int[] {  5,  6,  7,  8 },
			new int[] {  9, 10, 11, 12 },
			new int[] { 13, 14, 15, 16 },
		},
		new int[] { 1,2,5,9,6,3,4,7,10,13,14,11,8,12,15,16 },
	};

	yield return new object[]
	{
		new int[][] {},
		new int[] {},
	};
	
	yield return new object[]
	{
		new int[][]
		{
			new int[] { 1,  2,  3,  4 },
			new int[] { 5,  6,  7,  8 },
			new int[] { 9, 10, 11, 12 },
		},
		new int[] { 1 ,2 ,5 ,9 ,6 ,3 ,4 ,7 ,10 ,11 ,8 ,12  },
	};
}

// https://leetcode.com/explore/item/1167
#region Условие задачи
/*

Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.

Example:

Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]

Output:  [1,2,4,7,5,3,6,8,9]

Explanation:

Note:

The total number of elements of the given matrix will not exceed 10,000.


*/

#endregion

public class Solution
{
	public int[] FindDiagonalOrder(int[][] matrix)
	{
		if (matrix.Length == 0)
			return new int[0];

		var jMax = matrix[0].Length;
		var iMax = matrix.Length;
		var max = iMax * jMax;
		var result = new int[max];
		var i = 0;
		var j = 0;

		var isUp = true;

		for (int k = 0; k < max;)
		{
			if (isUp)
			{
				for (; i >= 0 && j < jMax; j++, i--)
				{
					result[k] = matrix[i][j];
					k++;
				}

				if (i < 0 && j <= jMax - 1)
					i = 0;

				if (j == jMax)
				{
					i = i + 2;
					j--;
				}
			}
			else
			{
				for (; j >= 0 && i < iMax; i++, j--)
				{
					result[k] = matrix[i][j];
					k++;
				}

				if (j < 0 && i <= iMax - 1)
					j = 0;

				if (i == iMax)
				{
					j = j + 2;
					i--;
				}
			}

			isUp = !isUp;
		}

		return result;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще даже чуть лучше чем вершина нормального распределения

// Чуть лучше моего, логика непонятна
public int[] FindDiagonalOrder1(int[][] matrix)
{
	if (matrix == null || matrix.Length == 0) return new int[0];
	int rows = matrix.Length;
	int columns = matrix[0].Length;
	int[] result = new int[rows * columns];
	int r = 0, c = 0;
	for (int i = 0; i < rows * columns; i++)
	{
		result[i] = matrix[r][c];
		if ((r + c) % 2 == 0)
		{
			if (r - 1 >= 0 && c + 1 < columns)
			{
				r = r - 1;
				c = c + 1;
			}
			else if (r - 1 < 0 && c + 1 < columns)
			{
				c = c + 1;
			}
			else
			{
				r = r + 1;
			}
		}
		else
		{
			if (c - 1 >= 0 && r + 1 < rows)
			{
				c = c - 1;
				r = r + 1;
			}
			else if (c - 1 < 0 && r + 1 < rows)
			{
				r = r + 1;
			}
			else
			{
				c = c + 1;
			}
		}
	}

	return result;
}

// Ещё лучше

public int[] FindDiagonalOrder2(int[][] matrix)
{
	int x = 0, y = 0;
	int[] returnArray;
	//int position = 0;
	bool isIncrease = true;
	int r = matrix.Length;
	if (r == 0)
		return new int[0];
	int c = matrix[0].Length;
	if (c == 0)
		return new int[0];
	int total = r * c;
	returnArray = new int[total];
	for (int position = 0; position < total; position++)
	{
		returnArray[position] = matrix[x][y];
		//int newX = x,newY = y; 
		if (isIncrease)
		{
			x--;
			y++;
			if (y > c - 1)
			{
				y = c - 1;
				x += 2;
				isIncrease = false;
			}
			if (x < 0)
			{
				x = 0;
				isIncrease = false;
			}
		}
		else
		{
			x++;
			y--;
			if (x > r - 1)
			{
				x = r - 1;
				y += 2;
				isIncrease = true;
			}
			if (y < 0)
			{
				y = 0;
				isIncrease = true;
			}

		}
	}
	//returnArray[position] = matrix[r-1][c-1];
	//returnArray[]= matrix[2][1];
	return returnArray;
}

// Типа виннер
public int[] FindDiagonalOrder3(int[][] matrix)
{
	if (matrix == null || matrix.Length < 1)
	{
		return new int[0];
	}

	int rows = matrix.Length;
	int columns = matrix[0].Length;

	int[] result = new int[rows * columns];
	int r = 0;
	int c = 0;
	for (int i = 0; i < result.Length; i++)
	{
		result[i] = matrix[r][c];

		if ((r + c) % 2 == 0)
		{
			// As columns are getting increased, there might be chance when we reached last column
			if (c == columns - 1)
			{
				// move to next row
				r++;
			}
			// As row are getting decaresed, there might be chance we reached to first row
			else if (r == 0)
			{
				// move to next column
				c++;
			}
			else
			{
				r--;
				c++;
			}
		}
		else
		{
			if (r == rows - 1)
			{
				c++;
			}
			else if (c == 0)
			{
				r++;
			}
			else
			{
				r++;
				c--;
			}
		}
	}

	return result;
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