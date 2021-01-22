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
public void PascalsTriangleII(int numRows, IList<int> expected)
{
	var actual = new Solution().GetRow(numRows);
	Assert.That(actual, Is.EqualTo(expected));
}

private static IEnumerable<object[]> TestCases()
{
	yield return new object[]
	{
		0,
		new List<int> { 1 },
	};

	yield return new object[]
	{
		1,
		new List<int> { 1, 1 },
	};

	yield return new object[]
	{
		2,
		new List<int> { 1, 2, 1 },
	};

	yield return new object[]
	{
		3,
		new List<int> { 1, 3, 3, 1 },
	};

	yield return new object[]
	{
		4,
		new List<int> { 1, 4, 6, 4, 1 },
	};
}

// https://leetcode.com/explore/item/1171
#region Условие задачи
/*

Given an integer rowIndex, return the rowIndexth row of the Pascal's triangle.

Notice that the row index starts from 0.


In Pascal's triangle, each number is the sum of the two numbers directly above it.

Follow up:

Could you optimize your algorithm to use only O(k) extra space?

 

Example 1:

Input: rowIndex = 3
Output: [1,3,3,1]

Example 2:

Input: rowIndex = 0
Output: [1]

Example 3:

Input: rowIndex = 1
Output: [1,1]

 

Constraints:

    0 <= rowIndex <= 33



*/

#endregion

public class Solution
{
	public IList<int> GetRow(int rowIndex)
	{
		if(rowIndex == 0)
			return new List<int> { 1 };

		var row = new List<int> { 1, 1 };
		if (rowIndex == 1)
			return row;

		var i = 2;
		while (i < rowIndex + 2)
		{
			var nextRow = new List<int>();

			for (var j = 0; j < i; j++)
			{
				if (j == 0 || j == i - 1)
				{
					nextRow.Add(1);
				}
				else
				{
					nextRow.Add(row[j - 1] + row[j]);
				}
			}
			
			i++;
			row = nextRow;
		}
		//row.Dump();
		
		return row;
	}
}


#region Хорошие алгоритмы-победители

// Ну мой сильно не долетел до подножия...

// Solutions
// 1. Recursion: Use i and j as row and column.  When j = 1 and j = i then return 1.  Recurse for all others, adding the values before it.
public class Solution1
{
	private Dictionary<string, int> memo = new Dictionary<string, int>();

	public IList<int> GetRow(int rowIndex)
	{ // 3
		List<int> values = new List<int>();// {1, 3}

		for (int i = 0; i <= rowIndex; i++) // 1
		{
			int currentValue = GetRowValue(i, rowIndex);
			values.Add(currentValue);
		}

		return values;
	}

	public int GetRowValue(int column, int row) // 1,3
	{
		if (column == 0 || column == row)
		{
			return 1;
		}

		string key = row.ToString() + ":" + column.ToString();

		if (!memo.ContainsKey(key))
		{
			memo[key] = GetRowValue(column - 1, row - 1) + GetRowValue(column, row - 1);
		}

		return memo[key];
	}
}

//
public class Solution2
{
	Dictionary<(int, int), int> memoize = new Dictionary<(int, int), int>();
	public IList<int> GetRow(int rowIndex)
	{
		if (rowIndex == 0) return new List<int> { 1 };
		if (rowIndex == 1) return new List<int> { 1, 1 };

		List<int> rt = new List<int>();
		for (int i = 0; i < rowIndex + 1; i++)
		{
			if (i == 0 || i == rowIndex) rt.Add(1);
			else
			{
				rt.Add(CalcPascal(rowIndex, i));
			}
		}
		return rt;
	}

	public int CalcPascal(int row, int col)
	{
		if (col == 0 || col == row) return 1;
		if (memoize.ContainsKey((row, col))) return memoize[(row, col)];
		int retval = CalcPascal(row - 1, col - 1) + CalcPascal(row - 1, col);
		memoize[(row, col)] = retval;
		return retval;
	}
}

//
public IList<int> GetRow3(int rowIndex)
{
	IList<IList<int>> triangle = new List<IList<int>>();

	triangle.Add(new List<int>() { 1 });
	if (rowIndex == 0)
		return triangle[0];


	for (int numRow = 1; numRow <= rowIndex; numRow++)
	{
		IList<int> row = new List<int>();
		IList<int> prvRow = triangle[0];

		row.Add(1);

		// For the first row   it will not go inside

		for (int j = 1; j < numRow; j++)
		{

			row.Add(prvRow[j - 1] + prvRow[j]);
		}

		row.Add(1);

		triangle.Add(row);
		triangle.RemoveAt(0);
	}

	return triangle[0];
}

// Вершина
public IList<int> GetRow4(int rowIndex)
{
	IList<IList<int>> triangle = new List<IList<int>>();

	triangle.Add(new List<int>() { 1 });
	if (rowIndex == 0)
		return triangle[0];


	for (int numRow = 1; numRow <= rowIndex; numRow++)
	{
		IList<int> row = new List<int>();
		IList<int> prvRow = triangle[numRow - 1];

		row.Add(1);

		// For the first row   it will not go inside

		for (int j = 1; j < numRow; j++)
		{

			row.Add(prvRow[j - 1] + prvRow[j]);
		}

		row.Add(1);

		triangle.Add(row);
	}

	return triangle[rowIndex];
}

//
public IList<int> GetRow5(int rowIndex)
{
	List<int> vals = new List<int>();
	vals.Add(1);
	if (rowIndex == 0)
		return vals;

	vals.Add(1);

	for (int i = 2; i <= rowIndex; ++i)
	{
		for (int j = 1; j < i; ++j)
		{
			vals.Add(vals[0] + vals[1]);
			vals.RemoveAt(0);
		}

		vals.Add(1);
	}


	return vals;
}

//
public IList<int> GetRow6(int k)
{
	var arr = new int[k + 1];
	arr[0] = 1;

	for (var i = 1; i <= k; i++)
		for (var j = i; j > 0; j--)
			arr[j] = arr[j] + arr[j - 1];

	return arr;
}

//
public IList<int> GetRow7(int rowIndex)
{
	List<int> vals = new List<int>();
	vals.Add(1);
	if (rowIndex == 0)
		return vals;

	vals.Add(1);

	for (int i = 2; i <= rowIndex; ++i)
	{
		for (int j = 1; j < i; ++j)
		{
			vals.Add(vals[0] + vals[1]);
			vals.RemoveAt(0);
		}

		vals.Add(1);
	}


	return vals;
}

//
public IList<int> GetRow8(int rowIndex)
{
	IList<int> temp = new List<int>() { 1 };
	IList<int> result = new List<int>() { 1 };
	for (int k = 0; k < rowIndex; k++)
	{
		result = new List<int> { 1 };
		for (int j = 1; j < temp.Count; j++)
		{
			result.Add(temp[j - 1] + temp[j]);
		}
		result.Add(1);
		temp = new List<int>(result);
	}
	return result;
}

// Победитель 
public IList<int> GetRow9(int rowIndex)
{
	//edge case
	if (rowIndex < 0)
		return null;

	//Time Complexity : O(N2), Space Complexity : O(N)
	//DP with memoization
	IList<int> res = new List<int>();
	res.Add(1);

	for (int i = 0; i < rowIndex; i++)
	{
		for (int j = i; j > 0; j--)
		{
			res[j] = res[j] + res[j - 1];
		}
		res.Add(1);
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