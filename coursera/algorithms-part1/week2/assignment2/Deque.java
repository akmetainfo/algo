/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.StdOut;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class Deque<Item> implements Iterable<Item> {
    private Node head;
    private Node tail;
    private Integer size;

    private class Node {
        private Item item;
        private Node next;
        private Node prev;
    }

    // construct an empty deque
    public Deque() {
        head = null;
        tail = null;
        size = 0;
    }

    // is the deque empty?
    public boolean isEmpty() {
        return head == null;
    }

    // return the number of items on the deque
    public int size() {
        return size;
    }

    // add the item to the front
    public void addFirst(Item item) {
        if (item == null)
            throw new IllegalArgumentException();

        Node node = new Node();
        node.item = item;
        node.next = head;
        if (head != null) head.prev = node;
        head = node;
        if (tail == null) tail = head;
        size++;
    }

    // add the item to the back
    public void addLast(Item item) {
        if (item == null)
            throw new IllegalArgumentException();

        Node node = new Node();
        node.item = item;
        if (tail != null) {
            tail.next = node;
            node.prev = tail;
        }
        tail = node;
        if (head == null) {
            head = tail;
        }
        size++;
    }

    // remove and return the item from the front
    public Item removeFirst() {
        if (size == 0)
            throw new NoSuchElementException();

        Item result = head.item;
        if (size == 1) {
            head = null;
            tail = null;
        }
        else {
            head = head.next;
        }
        size--;
        return result;
    }

    // remove and return the item from the back
    public Item removeLast() {
        if (size == 0)
            throw new NoSuchElementException();

        Item result = tail.item;
        if (size == 1) {
            head = null;
            tail = null;
        }
        else {
            tail = tail.prev;
        }
        size--;
        return result;
    }

    // return an iterator over items in order from front to back
    public Iterator<Item> iterator() {
        return new ListIterator();
    }

    private class ListIterator implements Iterator<Item> {
        private Node current = head;

        public boolean hasNext() {
            return current != null;
        }

        public void remove() {
            throw new UnsupportedOperationException();
        }

        public Item next() {
            if (!hasNext())
                throw new NoSuchElementException();

            Item item = current.item;

            current = current.next;
            return item;
        }
    }

    // unit testing (required)
    public static void main(String[] args) {
        Deque<Integer> deque = new Deque<Integer>();
        StdOut.println("isEmpty is : " + deque.isEmpty());
        deque.addFirst(42);
        deque.addLast(43);
        Integer first = deque.removeFirst();
        StdOut.println("first is : " + first);
        Integer last = deque.removeLast();
        StdOut.println("last is : " + last);
        deque.addFirst(2);
        deque.addFirst(1);
        for (Integer d : deque)
            StdOut.println("d is : " + d);
    }
}
