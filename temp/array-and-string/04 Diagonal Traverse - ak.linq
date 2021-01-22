<Query Kind="Program" />

void Main()
{
	var matrix1 = new int[][]
	{
		new int[] { 1, 2, 3 },
		new int[] { 4, 5, 6 },
		new int[] { 7, 8, 9 },
	};

	printMatrixDiagonal(matrix1).Dump();

	var matrix2 = new int[][]
	{
		new int[] {  1,  2,  3,  4 },
		new int[] {  5,  6,  7,  8 },
		new int[] {  9, 10, 11, 12 },
		new int[] { 13, 14, 15, 16 },
	};

	printMatrixDiagonal(matrix2).Dump();

	var matrix3 = new int[][]
	{
		new int[] { 1,  2,  3,  4 },
		new int[] { 5,  6,  7,  8 },
		new int[] { 9, 10, 11, 12 },
	};
	//matrix3.Dump();

	printMatrixDiagonal(matrix3).Dump();
}


static int[] printMatrixDiagonal(int[][] matrix)
{
	if(matrix.Length == 0)
		return new int[0];

	var iMax = matrix.Length;
	var jMax = matrix[0].Length;
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

// See also: http://metod.vt.tpu.ru/edu/df/ti/pri/lab2c/index.html

// https://www.geeksforgeeks.org/print-matrix-diagonal-pattern/?ref=rp
static int[] printMatrixDiagonal1(int[][] matrix)
{
	var max = matrix.Length * matrix.Length;
	var result = new int[max];
	var i = 0;
	var j = 0;

	var isUp = true;

	for (int k = 0; k < max;)
	{
		if (isUp)
		{
			for (; i >= 0 && j < matrix.Length; j++, i--)
			{
				result[k] = matrix[i][j];
				k++;
			}

			if (i < 0 && j <= matrix.Length - 1)
				i = 0;
				
			if (j == matrix.Length)
			{
				i = i + 2;
				j--;
			}
		}
		else
		{
			for (; j >= 0 && i < matrix.Length; i++, j--)
			{
				result[k] = matrix[i][j];
				k++;
			}

			if (j < 0 && i <= matrix.Length - 1)
				j = 0;
				
			if (i == matrix.Length)
			{
				j = j + 2;
				i--;
			}
		}

		isUp = !isUp;
	}
	
	return result;
}
