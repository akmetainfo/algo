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
[TestCase(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
[TestCase(new int[] { 0, 0, 1 }, new int[] { 1, 0, 0 })]
[TestCase(new int[] { 2, 1 }, new int[] { 2, 1 })]
[TestCase(new int[] { 2, 1, 0 }, new int[] { 2, 1, 0 })]
[TestCase(new int[] { 2, 1, 0, 0 }, new int[] { 2, 1, 0, 0 })]
[TestCase(new int[] { 2, 1, 0, 3 }, new int[] { 2, 1, 3, 0 })]
[TestCase(new int[] { 1, 0, 1 }, new int[] { 1, 1, 0 })]
public void RemoveElement(int[] nums, int[] expectedArr)
{
	new Solution().MoveZeroes(nums);
	//nums.Dump();
	Assert.That(expectedArr, Is.EqualTo(nums));
}

// https://leetcode.com/explore/item/3157
#region Условие задачи
/*
Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Example:

Input: [0,1,0,3,12]
Output: [1,3,12,0,0]

Note:

    You must do this in-place without making a copy of the array.
    Minimize the total number of operations.

Hint #1
In-place means we should not be allocating any space for extra array. But we are allowed to modify the existing array. However, as a first step, try coming up with a solution that makes use of additional space. For this problem as well, first apply the idea discussed using an additional array and the in-place solution will pop up eventually.

Hint #2
A two-pointer approach could be helpful here. The idea would be to have one pointer for iterating the array and another pointer that just works on the non-zero elements of the array.

*/

#endregion

public class Solution
{
	public void MoveZeroes(int[] nums)
	{
		for (var index = 0; index < nums.Length; index++)
		{
			if (nums[index] == 0)
			{
				var runner = index;

				do {} while (nums[runner] == 0 && ++runner < nums.Length);

				if (runner == nums.Length && nums[runner - 1] == 0)
					return;

				for (int i = index; i < nums.Length; i++)
				{
					if (i < nums.Length - (runner - index))
						nums[i] = nums[i + runner - index];
					else
						nums[i] = 0;
				}
			}
		}
	}
	
	public void MoveZeroesWorkingNonOptimized(int[] nums)
	{
		$"nums length = {nums.Length}".Dump();
		nums.Dump();
		
		for(var index = 0; index < nums.Length; index++)
		{
			// Обойти весь массив
			$"index={index}, nums[index]={nums[index]}".Dump();
			if(nums[index] != 0)
			{
				// Если элемент не ноль, то можно просто идти дальше
				$"not zero".Dump();
			}
			else
			{
				$"zero".Dump();
				// Если элемент ноль, то возможны варианты:
				// А) Самый очевидный вариант - после нуля стоит не ноль (нужно сделать shift массива вниз на единицу и освободившуюся ячейку занулить)
				// Б) Другой очевидный вариант - после нуля стоит серия нулей (если нулей N, то нужно сделать shift массива вниз N раз (или один раз на N) и освободившиеся N ячеек в конце занулить)

				// В принципе, я так понимаю, можно объединить эти две ветки алгоритма в одну:
				// начиная в цикле от текущего элемента (который мы уже знаем что ноль) идём вверх пока элементы равны нулю и инкрементируем счётчик нулей
				
				var runner = index;

				do
				{
					$"===runner={runner}, nums[runner]={nums[runner]}".Dump();
					
				}
				while ( nums[runner] == 0 && ++runner < nums.Length );

				// Мы вышли из цикла либо потому что а) дошли до конца, т.е. runner = nums.Length
				//                                   б) попался положительный элемент
				
				// Тут есть тонкость: можно добежать до конца и там ноль, а можно добежать до конца и там не ноль. Выход должен быть, только если всё ноль (и достаточно просто проверить последний)
				if(runner == nums.Length && nums[runner-1] == 0)
				{
					$"runner добежал до конца".Dump();
					return;
				}

				// Здесь мы оказываемся в случае если не добежав до конца нашли ненулевой элемент
				$"Wow: runner={runner}, nums[runner]={nums[runner]}".Dump();

				// Типовой случай: ноль, затем не ноль тогда index будет равен допустим 42, а runner 42+1
				// Типовой случай: два нуля, затем не ноль тогда index будет равен допустим 42, а runner 42+1+1
				// Т.е. index указывает на нулевой элемент (возможно, он единственный, но в любом случае первый если серия)
				// А runner указывает на первый не нулевой элемент

				// Наша задача - устроить сдвиг: элементы начиная с runner вписать на место index и так далее (оставшиеся элементы заполнить нулями
				
				$"index={index}, arr[index] = {nums[index]} -- runner={runner}, arr[runner] = {nums[runner]}".Dump();

				nums.Dump();
				for (int i = index; i < nums.Length; i++)
				{
					if (i < nums.Length - (runner - index))
					{
						nums[i] = nums[i + runner - index];
					}
					else
					{
						nums[i] = 0;
					}
				}
				nums.Dump();

				// Вопрос который больше всего будет интересовать: вполне возможно, что мы уже дошли до какого-то места в конце массива в котором остались одни нули
				// поэтому важно аккуратно написать условие выхода/обхода этого места
				
			}
		}
	}

	public void MoveZeroes1(int[] nums)
	{
		var pointer = nums.Length;

		var index = 0;
		while (true)
		{
			//$"{index}, before".Dump();
			//nums.Dump();

			var runner = index;

			if (nums[index] != 0)
			{
				index++;

				if (index == nums.Length)
					break;
			}


			bool foundZero = false;
			while (nums[runner] == 0 && runner < nums.Length - 1)
			{
				foundZero = true;
				runner++;
			}

			if (!foundZero)
				break;

			if (nums[runner] == 0 && runner < nums.Length - 1)
				break;

			if (runner == index)
			{
				// check if need to stop while
				if (index == nums.Length - 1)
					break;

				if (nums[runner + 1] == 0)
					break;

				// continue
				index++;
			}

			var jj = 0;
			while (runner + jj < nums.Length)
			{
				nums[index + jj] = nums[runner + jj];
				jj++;
			}

			nums[runner + jj - 1] = 0;
			//$"{index}, after".Dump();
			//nums.Dump();
			index++;
		}
	}

	public void MoveZeroesNonWorking(int[] nums)
	{
		var pointer = nums.Length;

		for (var i = 0; i < pointer - 1; i++)
		{
			if (nums[i] != 0)
				continue;

			pointer--;

			for (var j = i; j < pointer; j++)
			{
				nums[j] = nums[j + 1];
			}

			nums[pointer] = 0;
		}
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще где-то в жопе мира по скорости да и памяти (хуже пузырька по факту - N^2)

// Лучше моего
public void MoveZeroes1(int[] nums)
{
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] == 0)
		{
			for (int j = i; j < nums.Length; j++)
			{
				if (nums[j] != 0)
				{
					int temp = nums[i];
					nums[i] = nums[j];
					nums[j] = temp;
					j = nums.Length;
				}
			}
		}
	}
}

// чуть лучше
public void MoveZeroes2(int[] nums)
{

	int i = 0;
	int j = 0;

	while (j < nums.Length)
	{
		if (nums[j] != 0)
		{
			nums[i++] = nums[j];
		}

		j++;
	}

	while (i < nums.Length)
	{
		nums[i++] = 0;
	}
}

// дошли до пика нормального, чуть хуже
public void MoveZeroes3(int[] nums)
{

	var index = 0;

	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != 0)
		{
			nums[index] = nums[i];
			if (i != index)
			{
				nums[i] = 0;
			}

			index++;
		}
	}
}

// Самый пик нормали
public void MoveZeroes4(int[] nums)
{
	int j = -1;
	for (int i = 0; i < nums.Length; i++)
	{

		if (nums[i] != 0)
		{
			j++;
			int temp = nums[j];
			nums[j] = nums[i];
			nums[i] = temp;
		}
	}

}

// Начались лидеры
public void MoveZeroes5(int[] nums)
{
	int validIndex = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != 0)
		{
			nums[validIndex] = nums[i];
			validIndex++;
		}
	}
	while (validIndex < nums.Length)
	{
		nums[validIndex] = 0;
		validIndex++;
	}

}

public void MoveZeroes6(int[] nums)
{
	int numOfZeros = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != 0)
			nums[i - numOfZeros] = nums[i];
		else
			numOfZeros++;
	}

	for (int i = nums.Length - numOfZeros; i < nums.Length; i++)
	{
		nums[i] = 0;
	}
}

public void MoveZeroes7(int[] nums)
{
	if (nums == null || nums.Length == 0)
		return;

	int zeroPointer = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != 0)
		{
			int temp = nums[i];
			nums[i] = nums[zeroPointer];
			nums[zeroPointer] = temp;
			zeroPointer++;
		}
	}
}

public void MoveZeroes8(int[] nums)
{
	int index = 0, t;
	for (int i = 0; i < nums.Length; i++)
		if (nums[i] != 0)
		{
			t = nums[i];
			nums[i] = 0;
			nums[index++] = t;
		}

}

// Типа лидер
public void MoveZeroes9(int[] nums)
{
	int idx = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != 0)
			nums[idx++] = nums[i];
	}

	for (int i = idx; i < nums.Length; i++)
		nums[i] = 0;
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