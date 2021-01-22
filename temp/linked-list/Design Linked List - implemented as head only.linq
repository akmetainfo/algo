<Query Kind="Program" />

void Main()
{
	// Особенности такой реализации (head-only, нет даже счётчика элементов):
	// GetLength реализуем так, что приходится обходить весь список - всё же проще потратиться на счётчик размера
	// Операции GetNodeByIndex (а GetNodeByIndex используется почти везде и по нескольку раз) использует GetLength что ухудшает время (думаю, что в принципе можно просто проходить до конца списка, чтобы выдавать сообщение -1 но это только хуже даже будет)
	// Помимо int Get(int index) удобно сделать private ListNode GetNodeByIndex(int index) - себе же будет удобнее работать (в этой реализации "head only" особенно, но и в других тоже чуть экономить на поиске - не перебирать до tail, а просто взять его)
}

// Define other methods and classes here

// Этот класс я восстановил сам, его leetcode не показывает:
public class ListNode
{
	public ListNode(int data)
	{
		val = data;
	}
	public int val;
	public ListNode next;
}

public class MyLinkedList
{
	private ListNode headNode;
	/** Initialize your data structure here. */

	public MyLinkedList()
	{
		headNode = null;
	}

	public MyLinkedList(ListNode headNode)
	{
		this.headNode = headNode;
	}

	/** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
	public int Get(int index)
	{
		var node = GetNodeByIndex(index);
		if (node != null)
			return node.val;
		return -1;
	}

	/** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
	public void AddAtHead(int val)
	{
		var newNode = new ListNode(val);
		newNode.next = headNode;
		headNode = newNode;
	}

	/** Append a node of value val to the last element of the linked list. */
	public void AddAtTail(int val)
	{
		var lastNode = GetLastNode();
		if (lastNode == null)
		{
			headNode = new ListNode(val);
			return;
		}

		lastNode.next = new ListNode(val);
	}

	/** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
	public void AddAtIndex(int index, int val)
	{
		var listLength = GetLength();
		if (index > listLength)
			return;
		if (listLength == index)
		{
			AddAtTail(val);
			return;
		}

		var prevNode = GetNodeByIndex(index - 1);
		var nodeByIndex = GetNodeByIndex(index);
		var newNode = new ListNode(val);
		if (prevNode == null)
		{
			newNode.next = nodeByIndex;
			headNode = newNode;
			return;
		}
		newNode.next = prevNode.next;
		prevNode.next = newNode;
	}

	/** Delete the index-th node in the linked list, if the index is valid. */
	public void DeleteAtIndex(int index)
	{
		var nodeByIndex = GetNodeByIndex(index);
		if (nodeByIndex == null)
			return;
		var prevNode = GetNodeByIndex(index - 1);
		if (prevNode == null)
		{
			headNode = nodeByIndex.next;
			return;
		}

		prevNode.next = nodeByIndex.next;
	}

	private ListNode GetNodeByIndex(int index)
	{
		if (index < 0 || index >= GetLength())
			return null;
		var counter = 0;
		var currentNode = headNode;
		while (currentNode != null)
		{
			var value = currentNode.val;
			if (counter >= index)
				return currentNode;
			currentNode = currentNode.next;
			counter++;
		}

		return null;
	}

	private ListNode GetLastNode()
	{
		if (headNode == null)
			return null;
		var currentNode = headNode;
		while (currentNode.next != null)
		{
			currentNode = currentNode.next;
		}
		return currentNode;
	}

	public int GetLength()
	{
		var counter = 0;
		var currentNode = headNode;
		while (currentNode != null)
		{
			counter++;
			currentNode = currentNode.next;
		}
		return counter;
	}

	public override string ToString()
	{
		var strBuilder = new StringBuilder();
		var current = headNode;
		while (current != null)
		{
			strBuilder.Append(current.val + " ");
			current = current.next;
		}

		return strBuilder.ToString().TrimEnd();
	}
}