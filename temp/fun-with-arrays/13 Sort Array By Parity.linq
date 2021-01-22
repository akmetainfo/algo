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
//[TestCase(new int[] { 2, 1 }, new int[] { 2, 1 })]
//[TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
//[TestCase(new int[] { 1, 2,3,4 }, new int[] { 4, 2, 3, 1 })]
//[TestCase(new int[] { 1, 2,5,3,4 }, new int[] { 4, 2, 5, 3, 1 })]
public void RemoveElement(int[] nums, int[] expectedArr)
{
	var actual = new Solution().SortArrayByParity(nums);
	actual.Dump();
	Assert.That(expectedArr, Is.EqualTo(actual));
}

// https://leetcode.com/explore/item/3260
#region Условие задачи
/*

Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.

You may return any answer array that satisfies this condition.
 

Example 1:

Input: [3,1,2,4]
Output: [2,4,3,1]
The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
 

Note:

    1 <= A.length <= 5000
    0 <= A[i] <= 5000


*/

#endregion

public class Solution
{
	public int[] SortArrayByParity(int[] A)
	{
		if(A == null || A.Length < 2)
			return A;
			
		var lo = 0;
		var hi = A.Length - 1;
		
		while(lo < hi)
		{
			if(A[lo] % 2 == 0)
			{
				lo++;
				continue;
			}
			
			if(A[hi] % 2 == 1)
			{
				hi--;
				continue;
			}
			
			var swap = A[lo];
			A[lo] = A[hi];
			A[hi] = swap;
		}
		
		return A;
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще чуть хуже вершины нормали

// Решение из моей группы:

    public int[] SortArrayByParity1(int[] A) {
        int length = A.Length;
        if (length == 0)
            return null;
        if (length == 1)
            return A;
        int L = 0;
        int R = length - 1;
        while(L < R)
        {
            if((A[L] % 2) > (A[R] % 2))
            {
                int temp = A[L];
                A[L] = A[R];
                A[R] = temp; 
              //  L++;
              //  R--;
            }
            if(A[R] % 2 == 1) 
                R--;
            if(A[L] % 2 == 0)
                L++;
                       
        }
        return A;
    }
	
// Решение на самой вершине нормального распределения
    public int[] SortArrayByParity2(int[] A) {
        var evenPointer = 0;
        var oddPointer = A.Length - 1;
        
        var i = 0; 
        while (i < A.Length - 1 && evenPointer < oddPointer)
        {
            if (A[i] % 2 == 0 )
            {
                if (i != evenPointer)
                {
                    var temp = A[evenPointer];
                    A[evenPointer] = A[i];
                    A[i] = temp;
                }
                else
                {
                    i++;
                }
                evenPointer++;
            } 
            
            else if (A[i] % 2 != 0 )
            {
                if (i != oddPointer)
                {
                    var temp = A[oddPointer];
                    A[oddPointer] = A[i];
                    A[i] = temp;
                }
                else
                {
                    i++;
                }
                oddPointer--;
            }
            
        }
        return A;
    }	
	
    public int[] SortArrayByParity3(int[] A) {
        int current = 0;
        int idx = A.Length - 1;
        int temp;
        while(current < idx){
            if(A[current] % 2 == 0 && A[idx] % 2 == 1){
                current++;
                idx--;
            }
            else if(A[current] % 2 == 0 && A[idx] % 2 == 0){
                current++;
            }
            else if(A[current] % 2 == 1 && A[idx] % 2 == 1){
                idx--;
            }else{
                temp = A[current];
                A[current] = A[idx];
                A[idx] = temp;
            }
        }
        return A;
    }
	
	
    public int[] SortArrayByParity4(int[] A) {
        
        int [] temp= new int [A.Length];
        int cnt=0;
        for(int i = 0 ; i < A.Length ; i++)
        {
            if(A[i]%2==0)
            {
                temp[cnt]=A[i];
                cnt++;
            }
        }
        
        for(int i = 0 ; i < A.Length ; i++)
        {
            if(A[i]%2==1)
            {
                temp[cnt]=A[i];
                cnt++;
            }
        }
        
        A=temp;
        return A;
    }
	
    public int[] SortArrayByParity5(int[] A) {
        int validIndex=0;
        if(A.Length==0) return A;
        for(int i=0;i<A.Length;i++)
        {
            if(A[i]%2==0)
            {
                int temp=A[validIndex];
                A[validIndex]=A[i];
                A[i]=temp;
                validIndex++;
            }
        }
        return A;
    }
	
    public int[] SortArrayByParity6(int[] A) {
        if(A.Length == 1)
            return A;
        int i = 0;
        int j = A.Length -1;
        while(i < j){
            if(A[i] % 2 == 0){
                i++;
            }
            else if (A[j] % 2 == 0){
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
                i++;
                j--;
            }
            else
                j--;
        }
        return A;        
    }	


    public int[] SortArrayByParity7(int[] arr) {
        int n = arr.Length;
        int f = 0;
        for(int i = 0; i < n; i++)
        {
            int temp = arr[f];
            if(arr[i] % 2 == 0)
            {
                arr[f] = arr[i];
                arr[i] = temp;
                f++;
            }
        }
        return arr;
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