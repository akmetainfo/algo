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
[TestCase(8, new int[] { 4, 1, 8, 4, 5 }, new int[] { 5, 6, 1, 8, 4, 5 }, 2, 3)]
[TestCase(2, new int[] { 1, 9, 1, 2, 4 }, new int[] { 3, 2, 4 }, 3, 1)]
[TestCase(null, new int[] { 2,6,4 }, new int[] { 1,5 }, 3, 2)]
public void SinglyListNodeTests(int? intersectVal , int[] listA, int[] listB, int skipA, int skipB)
{
	var headA = ConstructPlainLinkedList(listA);
	var headB = ConstructPlainLinkedList(listB);
	headB = ConstructLinkedListIntersection(headA,  headB, skipA, skipB);

	//headA.Dump();
	//headB.Dump();

	var actual = new Solution().GetIntersectionNode(headA, headB);

	if (intersectVal == null)
	{
		Assert.IsNull(actual);
	}
	else
	{
		Assert.That(actual.val, Is.EqualTo(intersectVal));
	}
}

private ListNode ConstructPlainLinkedList(int[] values)
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

private ListNode ConstructLinkedListIntersection(ListNode headA, ListNode headB, int skipA, int skipB)
{
	var pA = headA;
	
	for (int i = 0; i < skipA-1; i++)
	{
		pA = pA.next;
	}
	
	if(pA.next == null)
		return headB;
		
	pA = pA.next;

	var pB = headB;

	for (int i = 0; i < skipB -1; i++)
	{
		pB = pB.next;
	}

	pB.next = pA;

	return headB;
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
	public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
	{
		ListNode pA = headA;
		ListNode pB = headB;

		while (pA != pB)
		{
			pA = pA == null ? headB : pA.next;
			pB = pB == null ? headA : pB.next;
		}
		
		return pA;
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


// https://leetcode.com/explore/item/1215
#region Условие задачи
/*

Write a program to find the node at which the intersection of two singly linked lists begins.

For example, the following two linked lists:

begin to intersect at node c1.

 

Example 1:

Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
Output: Reference of the node with value = 8
Input Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect). From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.

 

Example 2:

Input: intersectVal = 2, listA = [1,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
Output: Reference of the node with value = 2
Input Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect). From the head of A, it reads as [1,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.

 

Example 3:

Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
Output: null
Input Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
Explanation: The two lists do not intersect, so return null.

 

Notes:

    If the two linked lists have no intersection at all, return null.
    The linked lists must retain their original structure after the function returns.
    You may assume there are no cycles anywhere in the entire linked structure.
    Each value on each linked list is in the range [1, 10^9].
    Your code should preferably run in O(n) time and use only O(1) memory.



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