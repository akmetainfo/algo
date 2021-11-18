<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 653. Two Sum IV - Input is a BST
// https://leetcode.com/problems/two-sum-iv-input-is-a-bst/

/*
    Time: O(nh) where n is number of nodes in tree, h is the height of the tree (which is logn at best case, and n at worst case)
    Space: O(h)
    
    Intuition: use binary search on tree
    https://leetcode.com/problems/two-sum-iv-input-is-a-bst/discuss/106059/JavaC%2B%2B-Three-simple-methods-choose-one-you-like
*/
public class Solution
{
    public bool FindTarget(TreeNode root, int k)
    {
        return DFS(root, root, k);
    }

    public bool DFS(TreeNode root, TreeNode current, int k)
    {
        if (current == null) return false;
        return Search(root, current, k - current.val) || DFS(root, current.left, k) || DFS(root, current.right, k);
    }

    public bool Search(TreeNode root, TreeNode current, int value)
    {
        if (root == null) return false;
        return (root.val == value) && (root != current)
            || (root.val < value) && Search(root.right, current, value)
            || (root.val > value) && Search(root.left, current, value);
    }
}

[Test]
[TestCase(new object[] { 5, 3, 6, 2, 4, null, 7 }, 9, true)]
[TestCase(new object[] { 5, 3, 6, 2, 4, null, 7 }, 28, false)]
[TestCase(new object[] { 2, 1, 3 }, 4, true)]
[TestCase(new object[] { 2, 1, 3 }, 1, false)]
public void SolutionTests(object[] data, int k, bool expected)
{
    var root = CreateTree(data);
    var actual = new Solution().FindTarget(root, k);
    Assert.That(actual, Is.EqualTo(expected));
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