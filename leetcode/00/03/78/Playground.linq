<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 378. Kth Smallest Element in a Sorted Matrix
// https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/

public class Solution
{
    private class Heap<T>
    {
        private readonly IList<T> _data;
        private readonly IComparer<T> _comparer;

        public int Count => _data.Count;
        public T Top => _data[0];

        public Heap(IList<T> inputs, IComparer<T> comparer = null)
        {
            _comparer = comparer ?? Comparer<T>.Default;
            _data = inputs;
            for (int i = Count / 2; i >= 0; i--)
            {
                ShiftDown(i);
            }
        }

        public Heap(IEnumerable<T> inputs, IComparer<T> comparer = null) : this(inputs.ToList(), comparer)
        {
        }

        private void Swap(int i, int j)
        {
            var tmp = _data[i];
            _data[i] = _data[j];
            _data[j] = tmp;
        }

        private void ShiftDown(int i)
        {
            while (2 * i + 1 < _data.Count)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int j = left;

                if (right < _data.Count && _comparer.Compare(_data[right], _data[left]) < 0)
                {
                    j = right;
                }

                if (_comparer.Compare(_data[i], _data[j]) <= 0)
                {
                    break;
                }

                Swap(i, j);
                i = j;
            }
        }

        private void ShiftUp(int i)
        {
            while (_comparer.Compare(_data[i], _data[(i - 1) / 2]) < 0)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        public T ExtractTop()
        {
            T top = Top;
            _data[0] = _data.Last();
            _data.RemoveAt(Count - 1);
            ShiftDown(0);
            return top;
        }

        public void Add(T value)
        {
            _data.Add(value);
            ShiftUp(Count - 1);
        }
    }

    private class IndicesComparer : IComparer<(int, int)>
    {
        private readonly int[][] _matrix;

        public IndicesComparer(int[][] matrix)
        {
            _matrix = matrix;
        }

        public int Compare((int, int) x, (int, int) y) =>
            _matrix[x.Item1][x.Item2].CompareTo(_matrix[y.Item1][y.Item2]);
    }

    public int KthSmallest(int[][] matrix, int k)
    {
        var inputs = new List<(int, int)>(matrix.Length);
        for (int i = 0; i < matrix.Length; i++)
        {
            inputs.Add((0, i));
        }
        var heap = new Heap<(int, int)>(inputs, new IndicesComparer(matrix));
        int result = 0;

        while (k != 0)
        {
            var curr = heap.ExtractTop();
            result = matrix[curr.Item1][curr.Item2];
            if (curr.Item1 < matrix.Length - 1)
            {
                heap.Add((curr.Item1 + 1, curr.Item2));
            }

            k--;
        }

        return result;
    }
}

public class Solution4
{
    public int KthSmallest(int[][] matrix, int k)
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            return -1;

        int m = matrix.Length, n = matrix[0].Length;
        int left = matrix[0][0], right = matrix[m - 1][n - 1];

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (getCountLessThanOrEqualToTarget(matrix, mid) < k)
                left = mid + 1; //we have not met our quota k so expand our search space
            else
                right = mid;
        }

        return left;
    }

    private int getCountLessThanOrEqualToTarget(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int count = 0;
        int j = n - 1;
        for (int i = 0; i < m; i++)
        {
            while (j >= 0 && matrix[i][j] > target)
                j--;
            count += j + 1;
        }

        return count;
    }
}

public class Solution3
{
    public int KthSmallest(int[][] matrix, int k)
    {
        return matrix.SelectMany(x => x)
                     .OrderBy(x => x)
                     .Skip(k - 1)
                     .FirstOrDefault();
    }
}


public class Solution2
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var result = 0;

        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var s = new SortedList<int, Tuple<int, int>>(new DuplicateKeyComparer<int>());

        for (int col = 0; col < cols; col++)
        {
            s.Add(matrix[col][0], new Tuple<int, int>(col, 0));
        }

        while (k > 0)
        {
            result = s.First().Key;
            int x = s.First().Value.Item1;
            var y = s.First().Value.Item2;

            s.RemoveAt(0);

            if (y < cols - 1)
            {
                // go to next column 
                s.Add(matrix[x][y + 1], new Tuple<int, int>(x, y + 1));
            }

            k--;
        }

        return result;
    }
    
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);
            return result == 0 ? 1 : result;
        }
    }
}

public class Solution1
{
    public int KthSmallest(int[][] M, int k)
    {
        var result = 0;
        
        if (M.Length == 0)
            return result;
            
        var rows = M.Length;
        var cols = M[0].Length;
        
        var set = new SortedSet<(int val, int row, int col)>();
        
        for (int i = 0; i < rows; i++)
            set.Add((M[i][0], i, 0)); // add each row first col

        while (k > 0)
        {
            var min = set.Min; // Min Heap if you Max it will be Max Heap ... C# PQ ->SortedSet with Tuple.
            var key = min.val;
            var row = min.row;
            var col = min.col;
            result = key;
            set.Remove(min);
            if (col < cols - 1)
                set.Add((M[row][col + 1], row, col + 1)); // next col;                    
            k--;
        }
        return result;
    }
}

/*
    Time: O()
    Space: O()
*/
public class Solution0
{
    public int KthSmallest(int[][] matrix, int k)
    {
        throw new NotImplementedException();
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new int[][] {
            new int[] {1,5,9},
            new int[] {10,11,13},
            new int[] {12,13,15},
        },
        8,
        13,
    };
    yield return new object[]
    {
        new int[][] {
            new int[] {-5},
        },
        1,
        -5,
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(int[][] matrix, int k, int expected)
{
    var actual = new Solution().KthSmallest(matrix, k);
    Assert.That(actual, Is.EqualTo(expected));
}

#region unit tests runner

void Main()
{
    var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

    var args = new string[]
    {
         "-noheader",
         $"--work={workDir}",
    };

    RunUnitTests(args);
}

void RunUnitTests(string[] args, Assembly assembly = null)
{
    Console.SetOut(new NoDisposeTextWriter(Console.Out));
    Console.SetError(new NoDisposeTextWriter(Console.Error));
    new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
    private readonly TextWriter writer;
    public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

    public override Encoding Encoding => writer.Encoding;
    public override IFormatProvider FormatProvider => writer.FormatProvider;
    public override void Write(char value) => writer.Write(value);
    public override void Flush() => writer.Flush();
    // forward all other overrides as necessary

    protected override void Dispose(bool disposing)
    {
        // no nothing
    }
}

#endregion