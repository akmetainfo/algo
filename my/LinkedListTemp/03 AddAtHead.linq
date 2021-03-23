<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
    SinglyListNode head = null;
    head = AddAtHead(head, 7);
    head = AddAtHead(head, 6);
    head = AddAtHead(head, 5);
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

public SinglyListNode AddAtHead(SinglyListNode head, int val)
{
    var newNode = new SinglyListNode(val);

    if (head == null)
        return newNode;
        
    newNode.Next = head;

    return newNode;
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