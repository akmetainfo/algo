<Query Kind="Program" />

void Main()
{
    new Solution(1).Get().Take(10).Dump();
    new Solution(2).Get().Take(10).Dump();
}

// Define other methods and classes here

public class Solution
{
    private int _current;

    public Solution(int start)
    {
        _current = start;
    }
    
    public IEnumerable<int> Get()
    {
        while(true)
        {
            _current = SquareSum(_current);
            yield return _current;
        }
    }

    private static int SquareSum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int k = n % 10;
            sum = sum + k * k;
            n /= 10;
        }

        return sum;
    }
}

