<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 108. Convert Sorted Array to Binary Search Tree
// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/

/*
    Time: O(N)
    Space: O(log N) for storing call stack
*/
public class Solution
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return DFS(nums, 0, nums.Length - 1);
    }

    TreeNode DFS(int[] nums, int left, int right)
    {
        if (left > right) return null;
        var mid = left + (right - left) / 2;
        var result = new TreeNode(nums[mid]);
        result.left = DFS(nums, left, mid - 1);
        result.right = DFS(nums, mid + 1, right);
        return result;
    }
}

private static IEnumerable<SolutionTestCase[]> TestCases()
{
    yield return new SolutionTestCase[]
    {
        new SolutionTestCase
        {
            Nums = new int[] { 1, 3 },
            PossibleAnswers = new List<object[]>()
            {
                new object[] { 1, null, 3 },
                new object[] { 3, 1 },
            },
        }
    };
    yield return new SolutionTestCase[]
    {
        new SolutionTestCase
        {
            Nums = new int[] { -10, -3, 0, 5, 9 },
            PossibleAnswers = new List<object[]>()
            {
                new object[] { 0, -3, 9, -10, null, 5 },
                new object[] { 0, -10, 5, null, -3, null, 9 },
            },
        }
    };
}

public class SolutionTestCase
{
    public int[] Nums { get; set; }
    public List<object[]> PossibleAnswers { get; set; }
}

[Test]
[TestCaseSource(nameof(TestCases))]
public void SolutionTests(SolutionTestCase testCase)
{
    var actual = new Solution().SortedArrayToBST(testCase.Nums);
    var expected = testCase.PossibleAnswers.Select(x => CreateTree(x));
    Assert.IsTrue(expected.Any(x => IsSameTree(actual, x)));
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

#region unit-tests helpers

// https://ru.stackoverflow.com/q/1247517/213987
private TreeNode CreateTree(object[] data)
{
    if (data == null || data.Length == 0)
        return null;

    TreeNode[] nodes = data.Select(x => x == null ? null : new TreeNode((int)x, null, null)).ToArray();

    int current = 0;
    bool left = true;

    for (int i = 1; i < nodes.Length; i++)
    {
        if (left)
        {
            nodes[current].left = nodes[i];
            left = false;
        }
        else
        {
            nodes[current].right = nodes[i];
            left = true;

            current++;
            while (current < nodes.Length && nodes[current] == null)
                current++;
        }
    }

    return nodes[0];
}

public bool IsSameTree(TreeNode p, TreeNode q)
{
    if (p == null && q == null)
        return true;

    if (q == null || p == null)
        return false;

    if (p.val != q.val)
        return false;

    return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
}


#endregion

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