<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
    var head = SampleList();
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

public SinglyListNode SampleList()
{
    var node1 = new SinglyListNode(5);
    var node2 = new SinglyListNode(6);
    var node3 = new SinglyListNode(7);

    node1.Next = node2;
    node2.Next = node3;

    return node1;
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