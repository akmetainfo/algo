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
[TestCase(new int[] { 4,3,2,7,8,2,3,1 }, new int[] { 5,6 })]
public void RemoveElement(int[] nums, int[] expectedArr)
{
	var result = new Solution().FindDisappearedNumbers(nums);
	//nums.Dump();
	Assert.That(expectedArr, Is.EqualTo(result));
}

// https://leetcode.com/explore/item/3270
#region Условие задачи
/*
Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

Find all the elements of [1, n] inclusive that do not appear in this array.

Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.

Example:

Input:
[4,3,2,7,8,2,3,1]

Output:
[5,6]

Hint #1
This is a really easy problem if you decide to use additional memory. For those trying to write an initial solution using additional memory, think counters!
Hint #2
However, the trick really is to not use any additional space than what is already available to use. Sometimes, multiple passes over the input array help find the solution. However, there's an interesting piece of information in this problem that makes it easy to re-use the input array itself for the solution.

Hint #3
The problem specifies that the numbers in the array will be in the range [1, n] where n is the number of elements in the array. Can we use this information and modify the array in-place somehow to find what we need?

*/

#endregion

public class Solution
{
	public IList<int> FindDisappearedNumbers(int[] nums)
	{
		var result = new List<int>();

		// Что если мы всем элементы будем располагать на свои места?
		// и здорово, что есть элементы, которые встречаются дважды - это даст возможность ставить дыры, которые можно использовать под своп
		// количество удвоений - это и есть размерность нашего List'а
		// как узнать, что число задвоилось? надо его куда-то сохранить, чтобы помнить? Или же просто "если встретится ещё раз и при этом на месте уже есть число - то значит, это удвоение"?
		// и если число задвоилось - то можно быть уверенным, что оно в массиве есть и его не нужно переносить в итоговый List
		// Итак, допустим мы берём очередное i'тое число. Пробуем поставить его на своё место, а то что там было поставить во временную переменную (и идём дальше)
		// (это ещё вот какой вопрос непонятный: а много нам понадобится таких временных переменных? Может быть так, что n-1 переменных?)
		// (если подумать, то максимальное число удвоений не может быть больше чем половина от N)
		for (var i = 0; i < nums.Length - 1; i++)
		{
		}

		return result;
	}

	public IList<int> FindDisappearedNumbersJetAnotherOneBadIdea(int[] nums)
	{
		var result = new List<int>();
		
		// что если мы перебираем не элементы массива, а просто числа?
		for (var i = 0; i < nums.Length - 1; i++)
		{
		}

		return result;
	}

	public IList<int> FindDisappearedNumbersBadIdeaMaybe(int[] nums)
	{
		var result = new List<int>();
		var numsLength = nums.Length;
		var minPointerPos = 1;
		var maxPointerPos = numsLength;
		
		// minPointerValue и maxPointerValue похоже хранить нет смысла. А вот нужен ли numsLength?
		
		for(var i = 0; i < numsLength -1; i++)
		{
			// Если элемент следом за minPointer на единицу больше чем значение в minPointerValue
			// то можно весь массив сдвинуть вниз (при этом maxPointerPos уменьшить на 1 и numsLenght тоже уменьшить на 1)
			
			// если элемент перед maxPointer на единицу меньше чем значение в maxPointerValue
			// то можно
		}
		
		return result;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще где-то в жопе мира по скорости да и памяти (хуже пузырька по факту - N^2)

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