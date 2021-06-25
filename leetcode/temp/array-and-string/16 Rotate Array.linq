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
//[TestCase(new int[] { 1, 2 }, 0, new int[] { 1, 2 })]
//[TestCase(new int[] { 1, 2 }, 1, new int[] { 2, 1 })]
//[TestCase(new int[] { 1, 2 }, 2, new int[] { 1, 2 })]
//[TestCase(new int[] { 1, 2 }, 3, new int[] { 2, 1 })]
//[TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
//[TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 3, 1, 2 })]
//[TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 2, 3, 1 })]
//[TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 1, 2, 3 })]
//[TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 3, 1, 2 })]
//[TestCase(new int[] { 1, 2, 3 }, 5, new int[] { 2, 3, 1 })]
//[TestCase(new int[] { 1, 2, 3 }, 6, new int[] { 1, 2, 3 })]
//[TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 4, 1, 2, 3 })]
[TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 3, 4, 1, 2 })]
////[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
////[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1, new int[] { 7, 1, 2, 3, 4, 5, 6 })]
////[TestCase(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
public void RotateArray(int[] nums, int k, int[] expected)
{
	new Solution().Rotate0(nums, k);
	Assert.That(nums, Is.EqualTo(expected));
}


// https://leetcode.com/explore/item/1182
#region Условие задачи
/*

Given an array, rotate the array to the right by k steps, where k is non-negative.

Follow up:

    Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
    Could you do it in-place with O(1) extra space?

 

Example 1:

Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]

Example 2:

Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]

 

Constraints:

    1 <= nums.length <= 2 * 104
    -231 <= nums[i] <= 231 - 1
    0 <= k <= 105

Hint #1
The easiest solution would use additional memory and that is perfectly fine.

Hint #2
The actual trick comes when trying to solve this problem without using any additional memory. This means you need to use the original array somehow to move the elements around. Now, we can place each element in its original location and shift all the elements around it to adjust as that would be too costly and most likely will time out on larger input arrays.

Hint #3
One line of thought is based on reversing the array (or parts of it) to obtain the desired result. Think about how reversal might potentially help us out by using an example.

Hint #4
The other line of thought is a tad bit complicated but essentially it builds on the idea of placing each element in its original position while keeping track of the element originally in that position. Basically, at every step, we place an element in its rightful position and keep track of the element already there or the one being overwritten in an additional variable. We can't do this in one linear pass and the idea here is based on cyclic-dependencies between elements.

*/

#endregion

public class Solution
{
	// решение не работает когда length чётное и сдвиг идёт на половину массива
	public void Rotate2(int[] nums, int k)
	{
		var times = k % nums.Length;

		if (times == 0)
			return;

		var from = nums.Length - times;
		var fromValue = nums[from];
		var to = ToPosition(from, times, nums.Length);
		var toValue = nums[to];
		
		var i = 0;
		while( i< nums.Length)
		{
			nums[to] = fromValue;
			fromValue = toValue;
			from = to;
			to = ToPosition(from, times, nums.Length);
			toValue = nums[to];

			i++;
		}
		
		nums.Dump();
	}
	
	private static int ToPosition(int from, int k, int length)
	{
		if (from + k >= length)
		{
			return from + k - length;
		}
		else
		{
			return from + k;
		}
	}

	// Первое решение из трёх - со сдвигом. Оно работает локально, но на leetcode падает Time Limit Exceeded
	public void Rotate1(int[] nums, int k)
	{
		var times = k % nums.Length;

		if (times == 0)
			return;

		for (var i = 0; i < times; i++)
		{
			var swap = nums[nums.Length - 1];
			for (int j = nums.Length - 1; j > 0; j--)
			{
				nums[j] = nums[j - 1];
			}
			nums[0] = swap;
		}
	}
	
	// Тривиальное ршение с дополнительной памятью - так по условиям нельзя
	public void Rotate0(int[] nums, int k)
	{
		var times = k % nums.Length;

		if (times == 0)
			return;

		var result = new List<int>(nums.Length);

		for (int i = nums.Length - times; i < nums.Length; i++)
		{
			result.Add(nums[i]);
		}
		for (int i = 0; i < nums.Length - times; i++)
		{
			result.Add(nums[i]);
		}
		for (int i = 0; i < nums.Length; i++)
		{
			nums[i] = result[i];
		}
	}
}


#region Хорошие алгоритмы-победители

// Мой алгоритм был с дополнительной памятью, так что считай и не решил. Но были почему-то и ещё хуже решения.

// Из начала нормального распределения
public class Solution1 {
    
    public void Shift(int[] nums, int k) {
        
        var n = nums.Length;
        
        if(n > 1) {
            
            for(var i = 0; i < k; i++) {
                
                var t = nums[n-1];
                
                System.Buffer.BlockCopy(nums, 0, nums, sizeof(int), sizeof(int) * (n - 1));
                
                nums[0] = t;
            }
        };
    }

	public void Rotate(int[] nums, int k)
	{

		var n = nums.Length;

		var rotate = k / n;

		var extra = rotate > 0 ? (rotate % 2) * n : 0;

		var shift = k % n + extra;

		Shift(nums, shift);
	}
}

// Лучше
public void Rotate2(int[] nums, int k)
{
	if (nums.Length > 1)
	{
		int[] newNums = new int[nums.Length];

		for (int i = 0; i < nums.Length; i++)
		{
			if (i + k > nums.Length - 1)
			{
				if (i + k - nums.Length > nums.Length - 1)
				{
					newNums[i + k - nums.Length - nums.Length] = nums[i];
				}
				else
				{
					newNums[i + k - nums.Length] = nums[i];
				}
			}
			else
			{
				newNums[i + k] = nums[i];
			}
		}
		for (int i = 0; i < nums.Length; i++)
		{
			nums[i] = newNums[i];
		}
	}
}

// Лучше, но принцип как у меня: дополнительная память
public void Rotate3(int[] nums, int k)
{

	var new_array = new int[nums.Length];


	for (int i = 0; i < nums.Length; i++)
	{

		if (k % 2 == 0) new_array[(i + k) % nums.Length] = nums[i];
		else new_array[(i + k) % nums.Length] = nums[i];





	}

	for (int i = 0; i < nums.Length; i++)
	{
		nums[i] = new_array[i];
	}






}

// Лучше
public class Solution4
{
	public void Rotate(int[] nums, int k)
	{
		if (nums == null || nums.Length == 0)
			return;

		k = k % nums.Length;

		swap(nums, 0, nums.Length - 1);
		swap(nums, 0, k - 1);
		swap(nums, k, nums.Length - 1);
	}

	private void swap(int[] nums, int l, int r)
	{
		//Console.Write(l + "|" + r);
		while (l < r)
		{
			var temp = nums[l];
			nums[l++] = nums[r];
			nums[r--] = temp;
		}
	}
}


// Лучше, и гм, странно как-то используется доп. память
public void Rotate5(int[] nums, int k)
{
	Queue heldNum = new Queue();
	for (int i = 0; i < nums.Length; i++)
	{
		int indexToGrab = i - k;
		while (indexToGrab < 0)
		{
			indexToGrab = nums.Length + indexToGrab;
		}

		heldNum.Enqueue(nums[i]);

		if (indexToGrab < i)
		{
			nums[i] = (int)heldNum.Dequeue();
		}
		else
		{
			nums[i] = nums[indexToGrab];
		}
	}

}

// Это вершина
public class Solution6 {
    public void Rotate(int[] nums, int k) {
        if(k > nums.Length) k = k% nums.Length;
        reverse(nums,0, nums.Length-1);
        reverse(nums,0, k-1);
        reverse(nums,k, nums.Length-1);
            
    }
    
    public void reverse(int[] nums, int start, int end){
        
        while(start < end){
            int temp = nums[start];
            nums[start] = nums[end];
			nums[end] = temp;
			start++;
			end--;
		}
	}
}

// Это в принципе тоже практически вершина, но формально - прошли вершину
public class Solution7
{
	public void Rotate(int[] nums, int k)
	{
		k %= nums.Length;
		Reverse(ref nums, 0, nums.Length - 1);
		Reverse(ref nums, 0, k - 1);
		Reverse(ref nums, k, nums.Length - 1);
	}

	void Reverse(ref int[] nums, int start, int end)
	{
		while (start < end)
		{
			(nums[start], nums[end]) = (nums[end], nums[start]);
			start++;
			end--;
		}
	}
}

// Типа резко лучше, хотя похоже что тот же самый алгоритм
public class Solution8
{
	public void Rotate(int[] nums, int k)
	{
		k %= nums.Length;
		Reverse(ref nums, 0, nums.Length - 1);
		Reverse(ref nums, 0, k - 1);
		Reverse(ref nums, k, nums.Length - 1);
	}

	void Reverse(ref int[] nums, int start, int end)
	{
		while (start < end)
		{
			(nums[start], nums[end]) = (nums[end], nums[start]);
			start++;
			end--;
		}
	}
}

// хм
public class Solution9
{
	public void Rotate(int[] nums, int k)
	{
		int numberOfRotations = k % nums.Length;
		if (numberOfRotations == 0)
		{
			return;
		}
		int rotationsCompleted = 0;
		for (int startingIndex = 0; rotationsCompleted < nums.Length; startingIndex++)
		{
			int valueForNewIndex = nums[startingIndex];
			for (int i = 1; i <= nums.Length; i++)
			{
				int newIndex = (startingIndex + (i * numberOfRotations)) % nums.Length;
				int temp = nums[newIndex];
				nums[newIndex] = valueForNewIndex;
				valueForNewIndex = temp;
				rotationsCompleted++;
				if (newIndex == startingIndex)
				{
					break;
				}
			}
		}

		/*int numberOfRotations = k % nums.Length;
        if (numberOfRotations == 0)
        {
            return;
        }
        
        var newArray = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int newIndex = (i+numberOfRotations) % nums.Length;
            newArray[newIndex] = nums[i];
        }
        
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = newArray[i];
        }*/
	}
}

// 
public class Solution10
{
	public void Rotate(int[] nums, int k)
	{
		k = k % nums.Length;
		Reeverse(nums, 0, nums.Length - 1);
		Reeverse(nums, k, nums.Length - 1);
		Reeverse(nums, 0, k - 1);
	}

	private static void Reeverse(int[] nums, int i, int j)
	{
		while (i < j)
		{
			int temp = nums[i];
			nums[i] = nums[j];
			nums[j] = temp;
			i++;
			j--;
		}
	}
}

//
public class Solution11
{
	public void Rotate(int[] nums, int k)
	{
		int numElements = nums.Length;
		int tmp = nums[0];
		int startIndex = 0;
		int startCounter = 0;


		while (numElements != 0)
		{
			if (numElements > 0 && numElements != nums.Length && startIndex == startCounter)
			{
				startIndex++;
				startCounter++;
				tmp = nums[startIndex];
			}

			var swapIndex = startIndex + k;
			var numToSwap = tmp;

			while (swapIndex >= nums.Length)
			{
				swapIndex -= nums.Length;
			}

			tmp = nums[swapIndex];
			nums[swapIndex] = numToSwap;
			startIndex = swapIndex;
			numElements--;
		}
	}
}

// Изящнее из всех решений с доп. памятью
public void Rotate12(int[] nums, int k)
{
	int[] a = new int[nums.Length];

	for (int i = 0; i < nums.Length; i++)
	{
		a[(i + k) % nums.Length] = nums[i];
	}
	for (int i = 0; i < nums.Length; i++)
	{
		nums[i] = a[i];
	}
}

// Победитель
public class Solution13
{
	public void Rotate(int[] nums, int k)
	{
		k %= nums.Length;

		Reverse(nums, 0, nums.Length - 1);
		Reverse(nums, k, nums.Length - 1);
		Reverse(nums, 0, k - 1);

	}
	private void Reverse(int[] array, int start, int end)
	{

		while (start < end)
		{
			int temp = array[start];
			array[start] = array[end];
			array[end] = temp;
			start++;
			end--;
		}
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