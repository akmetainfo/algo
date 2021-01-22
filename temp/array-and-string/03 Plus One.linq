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
[TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
[TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
[TestCase(new int[] { 0 }, new int[] { 1 })]
[TestCase(new int[] { 9 }, new int[] { 1, 0 })]
public void RemoveElement(int[] nums, int[] expectedArr)
{
	var actual = new Solution().PlusOne(nums);
	//nums.Dump();
	Assert.That(actual, Is.EqualTo(expectedArr));
}

// https://leetcode.com/explore/item/1148
#region Условие задачи
/*

Given a non-empty array of decimal digits representing a non-negative integer, increment one to the integer.

The digits are stored such that the most significant digit is at the head of the list, and each element in the array contains a single digit.

You may assume the integer does not contain any leading zero, except the number 0 itself.

 

Example 1:

Input: digits = [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.

Example 2:

Input: digits = [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.

Example 3:

Input: digits = [0]
Output: [1]

 

Constraints:

    1 <= digits.length <= 100
    0 <= digits[i] <= 9

*/

#endregion

public class Solution
{
	public int[] PlusOne(int[] digits)
	{
		bool needRaise = true;
		
		for(var i = digits.Length; i > 0; --i)
		{
			if(!needRaise)
				break;
				
			digits[i-1] = digits[i-1] + 1;
			if(digits[i-1] == 10)
			{
				digits[i-1] = 0;
			}
			else
			{
				needRaise = false;
			}
		}
		
		if(!needRaise)
			return digits;

		var result = new int[digits.Length + 1];
		result[0] = 1;
		for(var i = 0; i < digits.Length; i++)
		{
			result[i+1] = digits[i];
		}
		
		return result;
	}
}

#region Хорошие алгоритмы-победители

// Мой ответ хуже чем ответ из столбца перед вершиной нормального распределения

// Это ответ из моей группы и он красив тем, что не нужно копировать массив - ведь туда нули копируются
public int[] PlusOne1(int[] digits)
{
	for (int i = digits.Length - 1; i >= 0; i--)
	{
		if (digits[i] == 9)
		{
			digits[i] = 0;
		}
		else
		{
			digits[i] += 1;
			return digits;
		}
	}

	int[] result = new int[digits.Length + 1];
	result[0] = 1;
	return result;
}

// ответ из группы "перед вершиной нормали"
// правильный неймспейсинг: carry вместо needRaise
public int[] PlusOne2(int[] digits)
{
	bool carry = false;
	for (int i = digits.Length - 1; i >= 0; i--)
	{
		if (digits[i] < 9)
		{
			digits[i]++;
			carry = false;
			break;
		}
		else
		{
			digits[i] = 0;
			carry = true;
		}
	}
	if (carry) // need to add a 1 at the head
	{
		int[] res = new int[digits.Length + 1];
		res[0] = 1;
		for (int i = 0; i < digits.Length; i++)
		{
			res[i + 1] = digits[i];
		}
		return res;
	}
	return digits;
}

// Вершина нормали, так себе ответ
public class Solution3
{
	void copyArray(int[] A1, int[] A2)
	{
		int s1 = A1.Length;
		int s2 = A2.Length;
		for (int i = 1; i < s1; i++)
		{
			A1[i] = A2[i - 1];
		}
	}
	public int[] PlusOne3(int[] digits)
	{
		int size = digits.Length;
		int carry = 0;
		int sum = digits[size - 1] + 1 + carry;
		if (sum > 9)
		{
			carry = 1;
			digits[size - 1] = 0;
			for (int i = size - 2; i >= 0; i--)
			{
				sum = digits[i] + carry;
				carry = 0;
				if (sum > 9)
				{
					carry = 1;
					digits[i] = 0;
				}
				else
				{
					digits[i] = sum;
					break;
				}
			}
		}
		else
		{
			digits[size - 1] = sum;
		}

		if (carry == 1)
		{
			int[] result = new int[size + 1];
			copyArray(result, digits);
			result[0] = carry;
			return result;
		}
		return digits;
	}
}

// чуть лучше
public class Solution4
{
	public int[] PlusOne4(int[] digits)
	{
		var result = new List<int>();
		int carry = 0;
		AddNum(digits, digits.Length - 1, ref carry, result);
		return result.ToArray();
	}

	private void AddNum(int[] digits, int index, ref int carry, List<int> result)
	{
		if (index < 0)
		{
			if (carry == 1)
				result.Insert(0, 1);

			return;
		}
		int sum = 0;
		if (index == digits.Length - 1)
			sum = digits[index] + carry + 1;
		else
			sum = digits[index] + carry;

		carry = sum / 10;
		result.Insert(0, sum % 10);
		AddNum(digits, index - 1, ref carry, result);
	}
}

// Резко лучше
public int[] PlusOne5(int[] digits)
{
	bool carry = false;
	int n = digits.Length;
	for (int i = n - 1; i >= 0; i--)
	{
		if (digits[i] < 9)
		{
			digits[i]++;
			carry = false;
			break;
		}
		else
		{
			digits[i] = 0;
			carry = true;
		}
	}
	if (carry) // need to add a 1 at the head
	{
		int[] res = new int[n + 1];
		res[0] = 1;
		for (int i = 0; i < n; i++)
		{
			res[i + 1] = digits[i];
		}
		return res;
	}
	return digits;
}

// ещё лучше
public int[] PlusOne6(int[] digits)
{
	int i = digits.Length - 1;
	while (i >= 0)
	{
		if (digits[i] != 9)
		{
			digits[i] = digits[i] + 1;
			return digits;
		}
		digits[i] = 0;
		i--;
	}
	int[] result = new int[digits.Length + 1];
	result[0] = 1;
	return result;
}

public int[] PlusOne7(int[] digits)
{
	bool shouldCarry = false;
	digits[digits.Length - 1]++;
	for (int i = digits.Length - 1; i >= 0; i--)
	{
		if (shouldCarry)
		{
			digits[i]++;
		}
		if (digits[i] >= 10)
		{
			shouldCarry = true;
			digits[i] = digits[i] - 10;
		}
		else
		{
			shouldCarry = false;
		}
	}

	if (shouldCarry)
	{
		int[] newDigits = new int[digits.Length + 1];
		newDigits[0] = 1;
		for (int i = 0; i < digits.Length; i++)
		{
			newDigits[i + 1] = digits[i];
		}
		return newDigits;
	}
	return digits;
}

// Типа лучше
public int[] PlusOne8(int[] digits)
{
	int leastSig = digits.Length - 1;
	if (digits[leastSig] < 9)
	{
		digits[leastSig] = digits[leastSig] + 1;
		return digits;
	}
	else
	{
		bool carryOver = false;

		for (int i = leastSig; i >= 0; i--)
		{
			int newDigit = digits[i] + 1;
			if (newDigit == 10)
			{
				newDigit = 0;
				carryOver = true;
			}
			else
			{
				carryOver = false;
			}
			digits[i] = newDigit;
			if (carryOver == false)
			{
				break;
			}
		}

		if (carryOver)
		{
			int[] newDigits = new int[leastSig + 2];
			newDigits[0] = 1;
			for (int i = 0; i <= leastSig; i++)
			{
				newDigits[i + 1] = digits[i];
			}
			return newDigits;
		}
		else
		{
			return digits;
		}
	}
}

// Идеал, хм. Типа список побеждает
public int[] PlusOne9(int[] digits)
{
	List<int> list = new List<int>(digits);
	int length = list.Count;
	int i = 1;
	list[length - i] += 1;
	while (list[length - i] == 10)
	{
		list[length - i] = 0;
		if (length > i)
		{
			list[length - i - 1] += 1;
			i++;
		}
		else
		{
			list.Insert(0, 1);
		}
	}
	return list.ToArray();

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