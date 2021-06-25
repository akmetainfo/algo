<Query Kind="Program" />

void Main()
{
	// Типа самый winner
}

// Define other methods and classes here


public class Node {
    public Node(int value)
    {
        Value = value;
    }
    public Node next;
    public int Value {get;set;}
}

public class MyLinkedList {
    Node _tail;
    Node _head;
    public int Count {get;set;}
    /** Initialize your data structure here. */
    public MyLinkedList() {
        
    }
    
    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index) {
        Node current = _head;
        if (current == null)
        {
            return -1;
        }
        int count = 0;
        while (current != null && count < index)
        {
            count++;            
            current = current.next;
        }
        if (current == null)
            return -1;
        else
            return current.Value;
    }
    
    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val) {
        Node node = new Node(val);
        Node temp = _head;
        
        _head = node;
        _head.next = temp;
        
        if(Count == 0)
        {
            _tail = _head;
        }
        
        Count++;
    }
    
    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val) {
        Node node = new Node(val);
        if (_head == null)
        {
            _head = _tail = node;
        }
        else
        {
            _tail.next = node; 
            _tail = node;
        }
        Count++;
    }
    
    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val) {
        Node node = new Node(val);
        Node current = _head;
        Node previous = null;
        if (current == null)
        {
            AddAtHead(val);
            return;
        }
        if (index == Count)
        {
            AddAtTail(val);
            return;
        }
        if (index > Count)
        {
            return;
        }
        
        int count = 0;
        while (current != null && count < index)
        {
            count++;
            previous = current;
            current = current.next;
        }
        Node temp = current;
        if (current == _head)
                _head = node;
        current = node;
        if (previous != null)
                previous.next = current;
        current.next = temp;   
        Count++;
    }
    
    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index) {
        Node previous = null;
        Node current = _head;
        int count = 0;
        while (current != null)
        {
            if(count == index)
            {
                if (previous != null)
                {
                    previous.next = current.next;
                    if (current.next == null)
                    {
                        _tail = previous;
                    }
                }
                else
                {
                    _head = _head.next;
                    if(_head==null)
                    {
                        _tail = null;
                    }
                }
                Count--;
                return;
            }
            previous = current;
            current = current.next;
            count++;
        }
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

