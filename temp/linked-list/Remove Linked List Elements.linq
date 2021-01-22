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
[TestCase(new int[] { 1, 2, 6, 3, 4, 5, 6, 7 }, 6, new int[] { 1, 2, 3, 4, 5, 7 })]
[TestCase(new int[] { 6 }, 6, new int[] { })]
[TestCase(new int[] { 6, 6 }, 6, new int[] { })]
[TestCase(new int[] { 6, 6, 6 }, 6, new int[] { })]
[TestCase(new int[] { 6, 6, 6, 1, 2, 3 }, 6, new int[] { 1, 2, 3 })]
[TestCase(new int[] { 1, 2 }, 2, new int[] { 1 })]
public void SinglyListNodeTests(int[] values, int val, int[] expectedResult)
{
	var head = ConstructLinkedList(values);

	var actual = new Solution().RemoveElements(head, val);

	var actualResult = ToArray(actual);
	//actualResult.Dump();

	Assert.That(expectedResult, Is.EqualTo(actualResult));
}

private int[] ToArray(ListNode head)
{
	var result = new List<int>();
	var tmp = head;
	while(tmp != null)
	{
		result.Add(tmp.val);
		tmp = tmp.next;
	}
	return result.ToArray();
}

private ListNode ConstructLinkedList(int[] values)
{
	ListNode head = null;
	ListNode tail = null;

	for (int i = 0; i < values.Length; i++)
	{
		ListNode current = new ListNode(values[i]);
		if(head == null)
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

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
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


// https://leetcode.com/explore/item/1207
#region Условие задачи
/*

Remove all elements from a linked list of integers that have value val.

Example:

Input:  1->2->6->3->4->5->6, val = 6
Output: 1->2->3->4->5

*/

#endregion

#region Хорошие алгоритмы-победители

//
public ListNode RemoveElements1(ListNode head, int val)
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

//
public ListNode RemoveElements2(ListNode head, int val)
{
	var current = head;
	ListNode xhead = null;
	ListNode prev = null;
	while (current != null)
	{
		if (current.val == val)
		{
			if (prev != null)
			{
				prev.next = current.next;
			}
		}
		else
		{
			if (xhead == null) xhead = current;
			prev = current;
		}
		current = current.next;
	}
	return xhead;
}

//
public ListNode RemoveElements3(ListNode head, int val)
{
	ListNode prev = head;
	ListNode cur = head;

	while (cur != null)
	{
		if (cur.val == val)
		{
			if (cur == head)
			{
				head = cur.next;
			}
			else
				prev.next = cur.next;
		}
		else
			prev = cur;

		cur = cur.next;

	}



	return head;
}

//
public ListNode RemoveElements4(ListNode head, int val)
{

	if (head == null)
		return head;


	ListNode dummyHead = head;
	ListNode prev = null;


	while (head != null)
	{
		if (head.val == val)
		{

			if (prev != null)
				prev.next = head.next;
			else
				dummyHead = head.next;



		}
		else
			prev = head;
		head = head.next;

	}

	return dummyHead;


}

//
//Brute force, prepare queue with all int than val and then rebuild list again.
public ListNode RemoveElements5(ListNode head, int val)
{
	if (head == null) return null;

	ListNode rhead = null;
	ListNode rtail = null;

	while (head != null)
	{
		if (val == head.val)
		{
			head = head.next;
			if (rtail != null)
				rtail.next = null;
			continue;
		}

		if (rhead == null)
		{
			rhead = rtail = head;
		}
		else
		{
			rtail.next = head;
			rtail = head;
		}

		head = head.next;
	}

	return rhead;

}

// Типа победитель
public ListNode RemoveElements6(ListNode head, int val)
{
	if (head == null)
	{
		return null;
	}

	while (head != null && head.val == val)
		head = head.next;

	if (head == null)
	{
		return null;
	}

	ListNode first = head.next;
	ListNode second = head;




	while (first != null)
	{
		if (first.val == val)
		{
			second.next = first.next;
			first = first.next;

		}
		else
		{
			first = first.next;
			second = second.next;
		}
	}

	return head;
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