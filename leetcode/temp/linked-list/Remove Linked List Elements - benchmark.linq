<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
</Query>

#LINQPad optimize+
void Main()
{
	var summary = BenchmarkRunner.Run<TwoSolution>();
}

// Define other methods and classes here

public class TwoSolution
{
	[Benchmark]
	[ArgumentsSource(nameof(Data))]	
	public void My1(ListNode head, int val)
	{
		var actual = new Solution1().RemoveElements(head, val);
	}

	[Benchmark]
	[ArgumentsSource(nameof(Data))]
	public void My2(ListNode head, int val)
	{
		var actual = new Solution2().RemoveElements(head, val);
	}

	public IEnumerable<object[]> Data()
	{
		yield return new object[] { ConstructLinkedList(new int[] { 1, 2, 6, 3, 4, 5, 6, 7 }), 6 };
	}

	private ListNode ConstructLinkedList(int[] values)
	{
		ListNode head = null;
		ListNode tail = null;

		for (int i = 0; i < values.Length; i++)
		{
			ListNode current = new ListNode(values[i]);
			if (head == null)
			{
				head = current;
				tail = current;
			}
			else
			{
				tail.next = current;
				tail = current;
			}
		}

		return head;
	}
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x)
	{
		val = x;
		next = null;
	}
}

public class Solution1
{
	public ListNode RemoveElements(ListNode head, int val)
	{
		var current = head;

		while (current != null)
		{
			if (head == current && current.val == val)
			{
				head = current.next;
				current = head;
			}
			else if (current.next != null && current.next.val == val)
			{
				current.next = current.next.next;
			}
			else
			{
				current = current.next;
			}
		}

		return head;
	}
}

public class Solution2
{
	public ListNode RemoveElements(ListNode head, int val)
	{
		if (head == null) return head;
		ListNode dummy = new ListNode(-1);
		dummy.next = head;
		ListNode current = head;
		ListNode prev = dummy;
		while (current != null)
		{
			if (current.val != val)
			{
				prev = current;
				current = current.next;
			}
			else
			{
				prev.next = current.next;
				current = current.next;
			}
		}
		return dummy.next;
	}
}
