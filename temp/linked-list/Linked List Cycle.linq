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
[TestCase(new int[] { 3, 2, 0, -4 }, 1, true)]
[TestCase(new int[] { 3, 2, 0, -4 }, -1, false)]
[TestCase(new int[] { 1, 2 }, 0, true)]
[TestCase(new int[] { 1 }, -1, false)]
public void SinglyListNodeTests(int[] values, int pos, bool expectedResult)
{
	var head = ConstructCycledLinkedList(values, pos);
	
	var actual = new Solution().HasCycle(head);
	
	Assert.That(expectedResult, Is.EqualTo(actual));
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
	public bool HasCycle(ListNode head)
	{
		ListNode temp = new ListNode(0);
		ListNode first = head; /*first always points to head*/
		ListNode last = head;

		// current_length stores no of nodes between current position of first and last
		int current_length = 0;

		// current_length stores no of nodes between previous position of first and last
		int prev_length = -1;

		while (current_length > prev_length && last != null)
		{
			// set prev_length to current length then update the current length
			prev_length = current_length;
			// distance is calculated
			current_length = distance(first, last);
			// last node points the next node
			last = last.next;
		}

		if (last == null)
			return false;
		else
			return true;
	}
	//returns distance between first and last node every time last node moves forwars
	int distance(ListNode first, ListNode last)
	{
		/*counts no of nodes between first and last*/
		int counter = 0;

		ListNode curr = first;

		while (curr != last)
		{
			counter += 1;
			curr = curr.next;
		}

		return counter + 1;
	}

	public bool HasCycle3(ListNode head)
	{
		ListNode temp = new ListNode(0);
		while (head != null)
		{
			if (head.next == null)
			{
				return false;
			}

			if (head.next == temp)
			{
				return true;
			}

			ListNode nex = head.next;

			head.next = temp;

			head = nex;
		}

		return false;
	}


	// Это алгоритм на основе хеширования
	// https://www.geeksforgeeks.org/detect-loop-in-a-linked-list/
	public bool HasCycle2(ListNode head)
	{
		HashSet<ListNode> s = new HashSet<ListNode>();
		while (head != null)
		{
			if (s.Contains(head))
				return true;

			s.Add(head);

			head = head.next;
		}

		return false;
	}

	// это алгоритм поиска циклов Флойда (Алгоритм «черепахи и зайца»), см. википедию. (Есть ещё алгоритм Брента)
	// https://medium.com/swlh/using-the-two-pointer-technique-bf642ab05661
	// https://stackoverflow.com/q/2663115/5752652
	public bool HasCycle1(ListNode head)
	{

		ListNode fast = head;
		ListNode slow = head;

		while (fast != null && fast.next != null)
		{
			slow = slow.next;
			fast = fast.next.next;

			if (slow == fast)
				return true;
		}

		return false;
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


// https://leetcode.com/explore/item/1212
#region Условие задачи
/*

Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.
 

Example 1:

Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

Example 2:

Input: head = [1,2], pos = 0
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.

Example 3:

Input: head = [1], pos = -1
Output: false
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