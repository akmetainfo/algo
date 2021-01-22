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
[TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 5 })]
[TestCase(new int[] { 1 }, 1, new int[] { })]
[TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
public void SinglyListNodeTests(int[] values, int n, int[] expectedResult)
{
	var head = ConstructLinkedList(values);

	var actual = new Solution().RemoveNthFromEnd(head, n);

	var actualResult = ToArray(actual);

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
	// Вариант за один проход, используя два указателя
	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		ListNode dummy = new ListNode(0);
		dummy.next = head;
		ListNode first = dummy;
		ListNode second = dummy;
		// Advances first pointer so that the gap between first and second is n nodes apart
		for (int i = 1; i <= n + 1; i++)
		{
			first = first.next;
		}
		// Move first to the end, maintaining the gap
		while (first != null)
		{
			first = first.next;
			second = second.next;
		}
		second.next = second.next.next;
		return dummy.next;
	}

	// Вариант за два прохода
	public ListNode RemoveNthFromEnd1(ListNode head, int n)
	{
		ListNode dummy = new ListNode(0);
		dummy.next = head;
		int length = 0;
		ListNode first = head;
		while (first != null)
		{
			length++;
			first = first.next;
		}
		length -= n;
		first = dummy;
		while (length > 0)
		{
			length--;
			first = first.next;
		}
		first.next = first.next.next;
		return dummy.next;
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


// https://leetcode.com/explore/item/1296
#region Условие задачи
/*

Given the head of a linked list, remove the nth node from the end of the list and return its head.

Follow up: Could you do this in one pass?

 

Example 1:

Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]

Example 2:

Input: head = [1], n = 1
Output: []

Example 3:

Input: head = [1,2], n = 1
Output: [1]

 

Constraints:

    The number of nodes in the list is sz.
    1 <= sz <= 30
    0 <= Node.val <= 100
    1 <= n <= sz

Hint #1
Maintain two pointers and update one with a delay of n steps.

*/

#endregion

#region Хорошие алгоритмы-победители

// 

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