<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
    SinglyListNode head = null;
    head = AddAtTail(head, 3);
    head = AddAtTail(head, 4);
    head = AddAtTail(head, 5);
    Traverse(head);
}

public class SinglyListNode
{
    public SinglyListNode(int data)
    {
        Data = data;
    }
    public int Data { get; set; }
    public SinglyListNode Next { get; set; }
}

public SinglyListNode AddAtTail(SinglyListNode head, int val)
{
    var newNode = new SinglyListNode(val);

    if (head == null)
        return newNode;

    var tail = head;

    while (tail.Next != null)
        tail = tail.Next;

    tail.Next = newNode;

    return head;
}

// You can define other methods, fields, classes and namespaces here

public void Traverse(SinglyListNode head)
{
    while (head != null)
    {
        Console.WriteLine(head.Data);

        head = head.Next;
    }
}