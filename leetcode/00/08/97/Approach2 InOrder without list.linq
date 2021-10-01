<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 897. Increasing Order Search Tree
// https://leetcode.com/problems/increasing-order-search-tree/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    TreeNode cur;
    
    public TreeNode IncreasingBST(TreeNode root)
    {
        TreeNode ans = new TreeNode(0);
        cur = ans;
        InOrder(root);
        return ans.right;
    }

    public void InOrder(TreeNode node)
    {
        if (node == null)
            return;
            
        InOrder(node.left);
        
        node.left = null;
        
        cur.right = node;
        
        cur = node;
        
        InOrder(node.right);
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public TreeNode IncreasingBST(TreeNode root)
    {
        var dummy = new TreeNode(-1);
        var result = dummy;
        InOrder(root, ref dummy);
        return result.right;
    }

    public void InOrder(TreeNode root, ref TreeNode result)
    {
        if (root.left != null)
            InOrder(root.left, ref result);

        result.right = new TreeNode(root.val);

        result = result.right;

        if (root.right != null)
            InOrder(root.right, ref result);
    }
}

[Test]
[TestCase(new object[] { 5, 3, 6, 2, 4, null, 8, 1, null, null, null, 7, 9 }, new object[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6, null, 7, null, 8, null, 9 })]
[TestCase(new object[] { 5, 1, 7 }, new object[] { 1, null, 5, null, 7 })]
[TestCase(new object[] { 5, null, 7 }, new object[] { 5, null, 7 })]
public void SolutionTests(object[] data, object[] expectedData)
{
    var root1 = CreateTree(data);
    var actual = new Solution().IncreasingBST(root1);
    var expected = CreateTree(expectedData);
    Assert.IsTrue(IsSameTree(actual, expected));
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

private bool IsSameTree(TreeNode p, TreeNode q)
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