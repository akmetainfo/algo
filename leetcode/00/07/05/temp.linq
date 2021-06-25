<Query Kind="Program" />

void Main()
{
    
}

// Define other methods and classes here

public class MyHashSet
{
    private int[] buckets;
    private Slot[] slots;

    public MyHashSet()
        : this(0)
    {
    }

    public MyHashSet(int capacity)
    {
    }

    private void Initialize(int capacity)
    {
        int size = GetPrime(capacity);
        buckets = new int[size];
        slots = new Slot[size];
    }

    private static readonly int[] primes = {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369 };

    private int GetPrime(int min)
    {
        if (min < 0)
            throw new ArgumentOutOfRangeException(nameof(min));

        for (int i = 0; i < primes.Length; i++)
        {
            int prime = primes[i];
            if (prime >= min)
                return prime;
        }

        throw new ArgumentOutOfRangeException(nameof(min), "HashSet is too large, not supported yet.");
    }

    internal struct Slot
    {
        internal int hashCode;      // Lower 31 bits of hash code, -1 if unused
        internal int next;          // Index of next entry, -1 if last
        internal int value;
    }

    // O(1)
    public void Add(int key)
    {
        if (Contains(key)
            return;

        int hashCode = HashCode(key);
        int bucket = hashCode % buckets.Length;

        int index; // index = m_lastIndex ???

        slots[index].hashCode = hashCode;
        slots[index].value = key;
        slots[index].next = buckets[bucket] - 1;
    }

    // O(1)
    public void Remove(int key)
    {
        throw new NotImplementedException();
    }

    // O(1)
    public bool Contains(int key)
    {
        int hashCode = HashCode(key);

        for (int i = buckets[hashCode % buckets.Length] - 1; i >= 0; i = slots[i].next)
        {
            if (slots[i].hashCode == hashCode && slots[i].value == key)
                return true;
        }

        return false;
    }

    private int HashCode(int key)
    {
        // for int we can just use its value
        return key;
    }
}