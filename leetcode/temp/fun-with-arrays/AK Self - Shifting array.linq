<Query Kind="Program" />

void Main()
{
	//ShiftDownAndFillByZero(new int[] { 2, 1, 0, 3 }, 2, 3);
	//ShiftDownAndFillByZero(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 1, 2);
	ShiftDownAndFillByZero(new int[] { -1, 0, 0, 1, 2, 3, 4, 5 }, 1, 3);
}

// Define other methods and classes here

public void ShiftDownAndFillByZero(int[] arr, int index, int runner)
{
	$"index={index}, arr[index] = {arr[index]} -- runner={runner}, arr[runner] = {arr[runner]}".Dump();
	$"{arr.Length + runner - index}".Dump();
	arr.Dump();

	for (int i = index; i < arr.Length; i++)
	{
		$"== i={i}, arr[index] = {arr[i]} ::: {(i + runner - index)}".Dump();
		if (i < arr.Length  - (runner - index))
		//if (i + runner - 1 < arr.Length)
		{
			arr[i] = arr[i + runner - index];
		}
		else
		{
			arr[i] = 0;
		}
	}

	arr.Dump();
}