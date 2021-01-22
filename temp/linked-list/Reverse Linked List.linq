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
[TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
public void SinglyListNodeTests(int[] values, int[] expectedResult)
{
	var head = ConstructLinkedList(values);

	var actual = new Solution().ReverseList(head);

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
	public ListNode ReverseListRecursive(ListNode head)
	{
		if (head == null || head.next == null)
			return head;

		// Reverse the rest list and put the first element at the end
		ListNode rest = ReverseList(head.next);
		head.next.next = head;

		// Tricky step — see the diagram
		head.next = null;

		// Fix the head pointer
		return rest;
	}

	public ListNode ReverseList(ListNode head)
	{
		ListNode prev = null;
		ListNode current = head;
		ListNode next = null;
		
		while (current != null)
		{
			next = current.next;
			current.next = prev;
			prev = current;
			current = next;
		}
		
		head = prev;
		
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


// https://leetcode.com/explore/item/1205
#region Условие задачи
/*

see here before: https://leetcode.com/explore/learn/card/linked-list/219/classic-problems/1204/

Reverse a singly linked list.

Example:

Input: 1->2->3->4->5->NULL
Output: 5->4->3->2->1->NULL

Follow up:

A linked list can be reversed either iteratively or recursively. Could you implement both?


*/

#endregion

#region Хорошие алгоритмы-победители

// Решение когда хватило двух указателей а не трёх
public ListNode ReverseList1(ListNode head)
{
	ListNode prev = null;
	ListNode cur = head;

	while (cur != null)
	{
		ListNode nextNode = cur.next;
		cur.next = prev;
		prev = cur;
		cur = nextNode;
	}

	return prev;
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