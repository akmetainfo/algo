<Query Kind="Program" />

void Main()
{
	// Особенности такой реализации (head-only, нет даже счётчика элементов):
}

// Define other methods and classes here


public class MyLinkedList {

    /** Initialize your data structure here. */
    public Node Head;
    public MyLinkedList() {
    }
    
    public class Node{
        public int Value;
        public Node Next;
        public Node(int v){
            Value=v;
            Next=null;
        }
    }
    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index) {
        Node currentNode= Head;
        int i=0;
        while(currentNode!=null){
            if(i==index)
                return currentNode.Value;
            i++;
            currentNode=currentNode.Next;
        }
        return -1;
    }
    
    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val) {
        Node newNode=new Node(val);
        if(Head==null)
            Head=newNode;
        else
        {
            newNode.Next=Head;
            Head=newNode;
        }
    }
    
    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val) {
        Node newNode=new Node(val);
        if(Head==null)
            Head=newNode;
        else
        {
            Node current=Head;
            while(current.Next!=null)
                current=current.Next;
            current.Next=newNode;
        }
    }
    
    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val) {
        Node newNode=new Node(val);
        if(Head==null && index>0)
            return;
        else if(index==0)
        {
            Head=newNode;
            return;
        }
        int i=0;
        Node current=Head;
        while(current!=null && i<index-1){
            current=current.Next;
            i++;
        }
        if(i==index-1 && current!=null){
            Node temp=current.Next;
            current.Next=newNode;
            newNode.Next= temp;
        }
    }
    
    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index) {
        Node current=Head;
        if(index==0 && Head.Next!=null){
            Head=Head.Next;            
        }
        int i=0;
        while(current!=null && i<index-1){
            current=current.Next;
            i++;
        }
        if(i==index-1 && current!=null && current.Next!=null){
            current.Next=current.Next.Next;
        }
    }
}