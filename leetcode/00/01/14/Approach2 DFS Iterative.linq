<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 114. Flatten Binary Tree to Linked List
// https://leetcode.com/problems/flatten-binary-tree-to-linked-list/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public void Flatten(TreeNode root)
    {
        if(root == null)
            return;
        
        var dummy = new TreeNode();
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Count != 0)
        {
            root = stack.Pop();
            
            dummy.left = null;
            dummy.right = root;
            dummy = dummy.right;
            
            if(root.right != null)
                stack.Push(root.right);
            if(root.left != null)
                stack.Push(root.left);
        }
    }
}

[Test]
[TestCase(new object[] { 1, 2, 5, 3, 4, null, 6 }, new object[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6 })]
[TestCase(new object[] { }, new object[] { })]
public void SolutionTests(object[] data, object[] expected)
{
    var root = CreateTree(data);
    new Solution().Flatten(root);
    var result = IsSameTree(root, CreateTree(expected));
    Assert.IsTrue(result);
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