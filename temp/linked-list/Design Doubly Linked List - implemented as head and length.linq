<Query Kind="Program" />

void Main()
{
	// Особенности такой реализации двусвязного списка (head and length):
}

// Define other methods and classes here

public class MyLinkedList
{
	private Node _head;
	private int _length;

	private class Node
	{
		public int Val { get; set; }
		public Node Next { get; set; }
		public Node Prev { get; set; }

		public Node(int val)
		{
			Val = val;
		}
	}

	/** Initialize your data structure here. */
	public MyLinkedList()
	{

	}

	/** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
	public int Get(int index)
	{
		if (index > _length - 1) return -1;

		var node = GetNodeAtIndex(index);
		if (node is null) return -1;
		return node.Val;
	}

	/** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
	public void AddAtHead(int val)
	{
		var node = new Node(val)
		{
			Next = _head
		};

		if (_head is object)
		{
			_head.Prev = node;
		}
		_head = node;
		_length++;
	}

	/** Append a node of value val to the last element of the linked list. */
	public void AddAtTail(int val)
	{
		var node = new Node(val);
		if (_head is null)
		{
			_head = node;
			_length++;
			return;
		}
		var p = _head;
		while (p.Next is object)
		{
			p = p.Next;
		}

		p.Next = node;
		node.Prev = p;
		_length++;
	}

	/** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
	public void AddAtIndex(int index, int val)
	{
		if (index < 0) return;
		if (index > _length) return;

		if (index == 0)
		{
			AddAtHead(val);
			return;
		};

		if (index == _length)
		{
			AddAtTail(val);
			return;
		}

		var prevNode = GetNodeAtIndex(index);
		var node = new Node(val);

		var prev = prevNode.Prev;
		if (prev != null)
		{
			prev.Next = node;
		}
		node.Prev = prev;
		node.Next = prevNode;
		prevNode.Prev = node;
		_length++;
	}

	/** Delete the index-th node in the linked list, if the index is valid. */
	public void DeleteAtIndex(int index)
	{
		if (index == 0)
		{
			if (_head is object)
			{
				_head = _head.Next;
				if (_head != null)
				{
					_head.Prev = null;
				}
				_length--;
			}
			return;
		}
		var nodeToDelete = GetNodeAtIndex(index);
		if (nodeToDelete is null) return;
		nodeToDelete.Prev.Next = nodeToDelete.Next;
		if (nodeToDelete.Next != null)
		{
			nodeToDelete.Next.Prev = nodeToDelete.Prev;
		}
		_length--;
	}

	private Node GetNodeAtIndex(int index)
	{
		if (index < 0) return null;
		var p = _head;
		for (var i = 0; i < index; i++)
		{
			if (p is null) return null;
			p = p.Next;
		}
		return p;
	}
}
