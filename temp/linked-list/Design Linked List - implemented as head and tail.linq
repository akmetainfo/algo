<Query Kind="Program" />

void Main()
{
	// Решение кстати имеет такую же скорость, как и моё решение со счётчиком!
	// Особенности такой реализации (head and tail, нет счётчика элементов):
	// Интересно, что часть кода (AddNext, AddBefore, RemoveMe) ушла в класс Node!
}

// Define other methods and classes here


public class MyLinkedList {

	private Node head = new Node(-1);
	private Node tail = new Node(-1);

	/** Initialize your data structure here. */
	public MyLinkedList()
	{
		head.next = tail;
		tail.prev = head;
	}

	/** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
	public int Get(int index)
	{

		Node n = this.head.next;
		while (n != this.tail && n.next != this.tail && index > 0)
		{
			n = n.next;
			index--;
		}

		if (index != 0) return -1;

		return n.Value;
	}

	/** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
	public void AddAtHead(int val)
	{
		this.head.AddNext(new Node(val));
	}

	/** Append a node of value val to the last element of the linked list. */
	public void AddAtTail(int val)
	{
		this.tail.AddBefore(new Node(val));
	}

	/** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
	public void AddAtIndex(int index, int val)
	{
		Node n = this.head.next;
		while (n != this.tail && n.next != this.tail && index > 0)
		{
			n = n.next;
			index--;
		}

		if (index == 0)
		{
			n.AddBefore(new Node(val));
		}
		else if (index == 1 && n.next == this.tail)
		{
			n.AddNext(new Node(val));
		}
	}

	/** Delete the index-th node in the linked list, if the index is valid. */
	public void DeleteAtIndex(int index)
	{
		Node n = this.head.next;
		while (n != this.tail && n.next != this.tail && index > 0)
		{
			n = n.next;
			index--;
		}

		if (index == 0)
		{
			n.RemoveMe();
		}
	}
}

public class Node
{
	public int Value { get; set; }
	public Node prev = null;
	public Node next = null;

	public Node(int v)
	{
		this.Value = v;
	}

	public void AddNext(Node n)
	{
		if (this.next == null)
		{
			this.next = n;
			n.prev = this;
			return;
		}

		Node t = this.next;
		this.next = n;
		n.prev = this;
		n.next = t;

		if (t != null) t.prev = n;
	}

	public void AddBefore(Node n)
	{
		Node t = this.prev;
		if (t == null)
		{
			n.next = this;
			this.prev = n;
			return;
		}

		t.next = n;
		n.prev = t;
		n.next = this;
		this.prev = n;
	}

	public void RemoveMe()
	{
		if (this.prev != null) this.prev.next = this.next;
		if (this.next != null) this.next.prev = this.prev;
	}
}