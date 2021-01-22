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
//[TestCase(new int[] { 3, 2, 0, -4 }, 0, 3)]
[TestCase(new int[] { 3, 2, 0, -4 }, 1, 2)]
//[TestCase(new int[] { 3, 2, 0, -4 }, 2, 0)]
//[TestCase(new int[] { 3, 2, 0, -4 }, 3, -4)]
//[TestCase(new int[] { 1, 2 }, 0, 1)]
//[TestCase(new int[] { 1 }, -1, null)]
public void SinglyListNodeTests(int[] values, int pos, int? expectedResult)
{
	var head = ConstructCycledLinkedList(values, pos);
	
	var actual = new Solution().DetectCycle(head);
	
	if(expectedResult == null)
	{
		Assert.That(actual, Is.EqualTo(expectedResult));
	}
	else
	{
		Assert.That(actual.val, Is.EqualTo(expectedResult));
	}
}

private ListNode ConstructCycledLinkedList(int[] values, int pos)
{
	ListNode head = null;
	ListNode tail = null;
	ListNode target = null;

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
		if(i == pos)
		{
			target = current;
		}
	}
	
	if(pos != -1)
	{
		tail.next = target;
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
	public ListNode DetectCycle(ListNode head)
	{
		HashSet<ListNode> s = new HashSet<ListNode>();
		while (head != null)
		{
			if (s.Contains(head))
				return head;

			s.Add(head);

			head = head.next;
		}

		return null;
	}

	// это алгоритм поиска циклов Флойда (Алгоритм «черепахи и зайца»), см. википедию.
	// https://stackoverflow.com/q/2663115/5752652
	// https://cs.stackexchange.com/q/10360/130375
	public ListNode DetectCycle1(ListNode head)
	{
		ListNode fast = head;
		ListNode slow = head;

		while (fast != null && fast.next != null)
		{
			slow = slow.next;
			fast = fast.next.next;

			if (fast == slow)
			{
				slow = head;
				while (slow != fast)
				{
					slow = slow.next;
					fast = fast.next;
				}
				return slow;
			}
		}

		return null;
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


// https://leetcode.com/explore/item/1214
#region Условие задачи
/*

Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Notice that you should not modify the linked list.

 

Example 1:

Input: head = [3,2,0,-4], pos = 1
Output: tail connects to node index 1
Explanation: There is a cycle in the linked list, where tail connects to the second node.

Example 2:

Input: head = [1,2], pos = 0
Output: tail connects to node index 0
Explanation: There is a cycle in the linked list, where tail connects to the first node.

Example 3:

Input: head = [1], pos = -1
Output: no cycle
Explanation: There is no cycle in the linked list.

Constraints:

    The number of the nodes in the list is in the range [0, 104].
    -105 <= Node.val <= 105
    pos is -1 or a valid index in the linked-list.

 

Follow up: Can you solve it using O(1) (i.e. constant) memory?

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