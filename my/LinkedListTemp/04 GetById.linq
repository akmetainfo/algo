<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
    var head1 = SampleList(new[] { 5, 6, 7 });
    GetById(head1, -1).Dump();
    GetById(head1, 0).Dump();
    GetById(head1, 1).Dump();
    GetById(head1, 2).Dump();
    GetById(head1, 3).Dump();

    SinglyListNode head2 = null;
    GetById(head2, 0).Dump();
    GetById(head2, 1).Dump();
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

public SinglyListNode SampleList(int[] arr)
{
    if (arr == null || arr.Length == 0)
        return null;

    var node = new SinglyListNode(arr[0]);
    var head = node;

    for (int i = 1; i < arr.Length; i++)
    {
        var next = new SinglyListNode(arr[i]);
        node.Next = next;
        node = next;
    }
    return head;
}

// You can define other methods, fields, classes and namespaces here

public int GetById(SinglyListNode head, int index)
{
    if(index < 0)
        return -1;
        
    var i = 0;
    
    while(head != null && i != index)
    {
        head = head.Next;
        i++;
    }
    
    if(i == index && head != null)
        return head.Data;
        
    return -1;
}
