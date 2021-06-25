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
[TestCase(new int[] { 4, 5, 1, 9 }, 5, new int[] { 4, 1, 9 })]
[TestCase(new int[] { 4, 5, 1, 9 }, 1, new int[] { 4, 5, 9 })]
public void SinglyListNodeTests(int[] values, int val, int[] expectedResult)
{
	var head = ConstructLinkedList(values);
	var node = GetNodeByVal(head, val);

	new Solution().DeleteNode(node);

	var actualResult = ToArray(head);

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

private ListNode GetNodeByVal(ListNode head, int val)
{
	while(head.val != val)
	{
		if(head.next != null)
		{
			head = head.next;
		}
		else
		{
			break;
		}
	}
	
	if(head.val == val)
		return head;
		
	throw new Exception("Bad data!");
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
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
	public void DeleteNode(ListNode node)
	{
		while (node.next != null)
		{
			node.val = node.next.val;

			if (node.next.next == null)
			{
				node.next = null;
			}
			else
			{
				node = node.next;
			}
		}
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


// https://leetcode.com/problems/delete-node-in-a-linked-list/
#region Условие задачи
/*

Write a function to delete a node in a singly-linked list. You will not be given access to the head of the list, instead you will be given access to the node to be deleted directly.

It is guaranteed that the node to be deleted is not a tail node in the list.

 

Example 1:

Input: head = [4,5,1,9], node = 5
Output: [4,1,9]
Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.

Example 2:

Input: head = [4,5,1,9], node = 1
Output: [4,5,9]
Explanation: You are given the third node with value 1, the linked list should become 4 -> 5 -> 9 after calling your function.

Example 3:

Input: head = [1,2,3,4], node = 3
Output: [1,2,4]

Example 4:

Input: head = [0,1], node = 0
Output: [1]

Example 5:

Input: head = [-3,5,-99], node = -3
Output: [5,-99]
 

Constraints:

    The number of the nodes in the given list is in the range [2, 1000].
    -1000 <= Node.val <= 1000
    The value of each node in the list is unique.
    The node to be deleted is in the list and is not a tail node

*/

#endregion

#region Solution

/*

Approach: Swap with Next Node [Accepted]

The usual way of deleting a node node from a linked list is to modify the next pointer of the node before it, to point to the node after it.

Since we do not have access to the node before the one we want to delete, we cannot modify the next pointer of that node in any way. Instead, we have to replace the value of the node we want to delete with the value in the node after it, and then delete the node after it.

Because we know that the node we want to delete is not the tail of the list, we can guarantee that this approach is possible.

Java

public void deleteNode(ListNode node) {
    node.val = node.next.val;
    node.next = node.next.next;
}

Complexity Analysis

Time and space complexity are both O(1).

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