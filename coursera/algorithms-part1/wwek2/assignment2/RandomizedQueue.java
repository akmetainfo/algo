/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.StdRandom;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class RandomizedQueue<Item> implements Iterable<Item> {
    private Item[] s;
    private int n;

    // construct an empty randomized queue
    public RandomizedQueue() {
        s = (Item[]) new Object[1];
        n = 0;
    }

    // is the randomized queue empty?
    public boolean isEmpty() {
        return n == 0;
    }

    // return the number of items on the randomized queue
    public int size() {
        return n;
    }

    // add the item
    public void enqueue(Item item) {
        if (n == s.length) resize(2 * s.length);
        s[n++] = item;
    }

    // remove and return a random item
    public Item dequeue() {
        if (n == 0)
            throw new UnsupportedOperationException();

        if (n <= s.length / 4)
            resize(s.length / 2);

        int index = StdRandom.uniform(n);

        Item item = s[index];
        s[index] = s[--n];
        s[n] = null;
        return item;
    }

    // return a random item (but do not remove it)
    public Item sample() {
        int index = StdRandom.uniform(n);
        return s[index];
    }

    private void resize(int capacity) {
        Item[] copy = (Item[]) new Object[capacity];
        for (int i = 0; i < n; i++) copy[i] = s[i];
        s = copy;
    }

    // return an independent iterator over items in random order
    public Iterator<Item> iterator() {
        return new ShuffledArrayIterator();
    }

    private class ShuffledArrayIterator implements Iterator<Item> {
        private final Item[] shuffledArray;
        private int current;

        public ShuffledArrayIterator() {
            shuffledArray = s.clone();
            shuffle(shuffledArray);
            current = 0;
        }

        public boolean hasNext() {
            return current < s.length;
        }

        public void remove() {
            throw new UnsupportedOperationException();
        }

        public Item next() {
            if (!hasNext())
                throw new NoSuchElementException();

            return shuffledArray[current++];
        }

        public void shuffle(Item[] array) {
            for (int i = 0; i < array.length; i++) {
                int r = i + (int) (Math.random() * (array.length - i));
                Item swap = array[r];
                array[r] = array[i];
                array[i] = swap;
            }
        }
    }

    // unit testing (required)
    public static void main(String[] args) {
        RandomizedQueue<Integer> rq = new RandomizedQueue<>();
        for (int i = 0; i < 10; ++i)
            rq.enqueue(i);
    }
}
