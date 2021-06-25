<Query Kind="Program" />

void Main()
{
	// Решение немного лучше чем моё
}

// Define other methods and classes here



public class MyLinkedList
{

    /** Initialize your data structure here. */
    class node
    {
        public int data;
        public node next;
        public node(int val)
        {
            data = val;
            next = null;
        }
    };
    node head, tail;
    int size;
    public MyLinkedList()
    {
        head = null;
        tail = null;
        size = 0;
    }

    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index)
    {
        if (index >= size)
            return -1;
        int cnt = -1;
        node tmp = head;
        while (true)
        {
            cnt++;
            if (cnt == index)
            {
                return tmp.data;
            }
            tmp = tmp.next;
        }
    }

    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val)
    {
        node tmp = new node(val);
        size++;
        if (head == null)
        {
            head = tmp;
            tail = tmp;
        }
        else
        {
            tmp.next = head;
            head = tmp;
        }
    }

    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val)
    {
        node tmp = new node(val);
        size++;
        if (tail == null)
            head = tmp;
        else
        {
            tail.next = tmp;
            tail = tmp;
        }

    }

    /*  public void traverse()
      {
          node srt = head;
          while(true)
          {
              if(srt.next==null)
              {
                  Console.WriteLine(srt.data);
                  break;
              }
              else
              {
                  Console.Write(srt.data + " ");
                  srt = srt.next;
              }
          }
          Console.WriteLine("Size: "+size);

      }*/


    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val)
    {
        if (index > size) return;
        else if (index == 0)
            AddAtHead(val);
        else if (index == size)
			AddAtTail(val);
		else
		{
			int cnt = -1;
			node srt = head, tmp = srt;
			while (true)
			{
				cnt++;
				if (cnt == index)
				{
					node ptr = new node(val);
					ptr.next = tmp.next;
					tmp.next = ptr;
					break;
				}
				tmp = srt;
				srt = srt.next;
			}
			size++;
		}
	}

	/** Delete the index-th node in the linked list, if the index is valid. */
	public void DeleteAtIndex(int index)
	{
		if (index >= size)
			return;
		size--;
		int cnt = -1;
		node srt = head, tmp = srt;

		while (true)
		{
			cnt++;
			if (cnt == index)
			{
				if (srt == head)//first node delete
				{
					head = srt.next;
					break;
				}
				else if (srt == tail)//last node delete
				{
					tmp.next = null;
					tail = tmp;
					break;
				}
				else
				{
					tmp.next = srt.next;
					break;
				}

			}
			tmp = srt;
			srt = srt.next;
		}
	}
}
/*class Program
{
    static void Main(string[] args)
    {
        MyLinkedList obj = new MyLinkedList();
        obj.AddAtHead(10);
        obj.AddAtHead(11);
        obj.AddAtTail(20);
        obj.AddAtHead(13);
        obj.traverse();
        obj.AddAtIndex(3, 55);
        obj.traverse();
        obj.DeleteAtIndex(2);
        obj.traverse();
        Console.WriteLine(obj.Get(4));


    }
}*/

