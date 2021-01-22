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
[TestCase(
	new string[] { "MyLinkedList", "addAtHead", "addAtTail", "addAtIndex", "get", "deleteAtIndex", "get" },
	new object[] { null, 1, 3, new int[] { 1, 2 }, 1, 1, 1 },
	new object[] { null, null, null, null, 2, null, 3 }
)]
[TestCase(
	new string[] { "MyLinkedList", "addAtIndex", "addAtIndex", "addAtIndex", "get" },
	new object[] { null, new int[] { 0, 10 }, new int[] { 0, 20 }, new int[] { 1, 30 }, 0 },
	new object[] { null, null, null, null, 20 }
)]
[TestCase(
	new string[] { "MyLinkedList", "addAtHead", "deleteAtIndex", "addAtHead", "addAtHead", "addAtHead", "addAtHead", "addAtHead", "addAtTail", "get", "deleteAtIndex", "deleteAtIndex" },
	new object[] { null, 2, 1, 2, 7, 3, 2, 5, 5, 5, 6, 4 },
	new object[] { null, null, null, null, null, null, null, null, null, 2, null, null,  }
)]
// my samples:
[TestCase(
	new string[] { "MyLinkedList", "addAtHead", "deleteAtIndex", "get" },
	new object[] { null, 2, 1, 2 },
	new object[] { null, null, null, -1 }
)]
public void SinglyListNodeTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
	AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
	var expectedResult = ConvertResult(expectedOutput);
	int?[] actualResult = new int?[actionsNames.Length];
	MyLinkedList testedObj = null;

	for (var i = 0; i < actionsNames.Length; i++)
	{
		switch (actionsNames[i].ToLower())
		{
			case "mylinkedlist":
				testedObj = new MyLinkedList();
				actualResult[i] = null;
				break;

			case "get":
				if (testedObj == null)
					throw new Exception("where is init?");
				actualResult[i] = testedObj.Get((int)actionsParams[i]);
				break;

			case "addathead":
				if (testedObj == null)
					throw new Exception("where is init?");
				testedObj.AddAtHead((int)actionsParams[i]);
				break;

			case "addattail":
				if (testedObj == null)
					throw new Exception("where is init?");
				testedObj.AddAtTail((int)actionsParams[i]);
				break;

			case "addatindex":
				if (testedObj == null)
					throw new Exception("where is init?");
				int[] parameters = (int[])actionsParams[i];
				testedObj.AddAtIndex(parameters[0], parameters[1]);
				break;

			case "deleteatindex":
				if (testedObj == null)
					throw new Exception("where is init?");
				testedObj.DeleteAtIndex((int)actionsParams[i]);
				break;

			default:
				throw new ArgumentOutOfRangeException($"unknown command: {actionsNames[i]}");
		}
		//testedObj.ToString().Dump();
	}
	//expectedResult.Dump();
	//actualResult.Dump();

	Assert.That(expectedResult, Is.EqualTo(actualResult));
}

#region unit-tests helpers

private void AssertInputIsCorrect(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
	if (actionsNames.Length != actionsParams.Length || actionsNames.Length != expectedOutput.Length)
		throw new ArgumentException($"actionsNames.Length={actionsNames.Length}, actionsParams.Length={actionsParams.Length}, expectedOutput.Length={expectedOutput.Length}.");
}

private int?[] ConvertResult(object[] expectedOutput)
{
	var result = new int?[expectedOutput.Length];

	for (var i = 0; i < expectedOutput.Length; i++)
	{
		if (expectedOutput[i] == null)
		{
			result[i] = null;
		}
		else
		{
			result[i] = (int)expectedOutput[i];
		}
	}

	return result;
}

#endregion

public class SinglyListNode
{
	public SinglyListNode(int data)
	{
		Data = data;
	}
	public int Data { get; set; }
	public SinglyListNode Next { get; set; }
}

public class MyLinkedList
{
	// for debug reason:
	public SinglyListNode head;
	public SinglyListNode tail;
	public int size;

	//private SinglyListNode head;
	//private SinglyListNode tail;
	//private int size;

	/** Initialize your data structure here. */
	public MyLinkedList()
	{
		this.head = null;
		this.tail = null;
		this.size = 0;
	}

	/** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
	public int Get(int index)
	{
		if (IsIndexInvalid(index))
			return -1;
			
		if(index == 0)
			return this.head.Data;

		if (index == this.size)
			return this.tail.Data;

		var pointer = 0;
		var current = this.head;

		while (pointer != index)
		{
			current = current.Next;
			pointer++;
		}

		return current.Data;
	}

	/** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
	public void AddAtHead(int val)
	{
		var inserted = new SinglyListNode(val);

		if (this.size == 0)
		{
			// empty linked list, let's init
			this.head = inserted;
			this.tail = inserted;
			this.size++;
		}
		else
		{
			// initialized list
			inserted.Next = this.head;
			this.head = inserted;
			this.size++;
		}
	}

	/** Append a node of value val to the last element of the linked list. */
	public void AddAtTail(int val)
	{
		if (this.size == 0)
		{
			this.AddAtHead(val);
			return;
		}

		var inserted = new SinglyListNode(val);
		this.tail.Next = inserted;
		this.tail = inserted;
		this.size++;
	}

	/** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
	public void AddAtIndex(int index, int val)
	{
		if (index == this.size)
		{
			this.AddAtTail(val);
			return;
		}

		if (index > this.size)
		{
			return;
		}

		if (index == 0)
		{
			this.AddAtHead(val);
			return;
		}

		// Note: val must be inserted BEFORE index'th!!

		var pointer = 0;
		var current = this.head;

		while (pointer < index - 1)
		{
			current = current.Next;
			pointer++;
		}

		var inserted = new SinglyListNode(val);
		inserted.Next = current.Next;
		current.Next = inserted;

		this.size++;
	}

	/** Delete the index-th node in the linked list, if the index is valid. */
	public void DeleteAtIndex(int index)
	{
		if (IsIndexInvalid(index))
			return;

		if (index == 0)
		{
			// Delete head
			this.head = this.head.Next;
			this.size--;
			return;
		}

		// delete somewhere in middle (or maybe at tail - no difference)
		var pointer = 0;
		var current = this.head;

		while (pointer < index - 1)
		{
			current = current.Next;
			pointer++;
		}

		// N.B. current is element before 'element we want to delete'
		if (current.Next == this.tail)
		{
			this.tail = current;
			this.size--;
		}
		else
		{
			var deleted = current.Next;
			var nextAfterDeleted = deleted.Next;
			current.Next = nextAfterDeleted;
			deleted.Next = null;
			this.size--;
		}
	}

	public override string ToString()
	{
		var strBuilder = new StringBuilder();
		var current = this.head;
		while (current != null)
		{
			strBuilder.Append(current.Data + " ");
			current = current.Next;
		}

		return strBuilder.ToString().TrimEnd();
	}

	private bool IsIndexInvalid(int index)
	{
		return index < 0 || index > this.size - 1;
	}
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */

// https://leetcode.com/explore/item/1290
#region Условие задачи
/*
Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
A node in a singly linked list should have two attributes: val and next. val is the value of the current node, and next is a pointer/reference to the next node.
If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list. Assume all nodes in the linked list are 0-indexed.

Implement the MyLinkedList class:

    MyLinkedList() Initializes the MyLinkedList object.
    int get(int index) Get the value of the indexth node in the linked list. If the index is invalid, return -1.
    void addAtHead(int val) Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
    void addAtTail(int val) Append a node of value val as the last element of the linked list.
    void addAtIndex(int index, int val) Add a node of value val before the indexth node in the linked list. If index equals the length of the linked list, the node will be appended to the end of the linked list. If index is greater than the length, the node will not be inserted.
    void deleteAtIndex(int index) Delete the indexth node in the linked list, if the index is valid.

 

Example 1:

Input
["MyLinkedList", "addAtHead", "addAtTail", "addAtIndex", "get", "deleteAtIndex", "get"]
[[], [1], [3], [1, 2], [1], [1], [1]]
Output
[null, null, null, null, 2, null, 3]

Explanation
MyLinkedList myLinkedList = new MyLinkedList();
myLinkedList.addAtHead(1);
myLinkedList.addAtTail(3);
myLinkedList.addAtIndex(1, 2);    // linked list becomes 1->2->3
myLinkedList.get(1);              // return 2
myLinkedList.deleteAtIndex(1);    // now the linked list is 1->3
myLinkedList.get(1);              // return 3

 

Constraints:

    0 <= index, val <= 1000
    Please do not use the built-in LinkedList library.
    At most 2000 calls will be made to get, addAtHead, addAtTail,  addAtIndex and deleteAtIndex.

*/

#endregion

public class Solution
{
	public void MoveZeroes(int[] nums)
	{
	}
}

#region Хорошие алгоритмы-победители

// Ну мой вообще где-то в жопе мира по скорости да и памяти (хуже пузырька по факту - N^2)

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