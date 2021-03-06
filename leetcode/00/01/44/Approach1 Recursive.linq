<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 144. Binary Tree Preorder Traversal
// https://leetcode.com/problems/binary-tree-preorder-traversal/

/*
    Time: O(N) where N is the number of treenode in the tree. Every node will be visited exactly once.
    Space: O(N) for the call stack in worst case where the tree is a complete unbalanced tree.
*/
public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
            return result;

        result.Add(root.val);

        if (root.left != null)
            result.AddRange(PreorderTraversal(root.left));
            
        if (root.right != null)
            result.AddRange(PreorderTraversal(root.right));

        return result;
    }
}

public class Solution1
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        PreorderTraversal(root, result);
        return result;
    }

    private void PreorderTraversal(TreeNode node, List<int> result)
    {
        if (node == null)
            return;

        result.Add(node.val);
        
        if (node.left != null)
            PreorderTraversal(node.left, result);
            
        if (node.right != null)
            PreorderTraversal(node.right, result);
    }
}

public class Solution2
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        
        if(root != null)
            result = PreorderTraversalHelper(root).ToList();
            
        return result;
    }

    private static IEnumerable<int> PreorderTraversalHelper(TreeNode node)
    {
        yield return node.val;
        
        if (node.left != null)
            foreach (var nod in PreorderTraversalHelper(node.left))
                yield return nod;
                
        if (node.right != null)
            foreach (var nod in PreorderTraversalHelper(node.right))
                yield return nod;
    }
}

public class Solution3
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        var rightNodes = new Stack<TreeNode>();

        while (root != null)
        {
            result.Add(root.val);

            if (root.right != null)
                rightNodes.Push(root.right);

            root = root.left;

            if (root == null && rightNodes.Count > 0)
                root = rightNodes.Pop();
        }

        return result;
    }
}

[Test]
[TestCase(new object[] { 1, null, 2, 3 }, new int[] { 1, 2, 3 })]
[TestCase(new object[] { }, new int[] { })]
[TestCase(new object[] { 1 }, new int[] { 1 })]
[TestCase(new object[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
[TestCase(new object[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 4, 5, 3, 6, 7 })]
public void SolutionTests(object[] data, int[] expected)
{
    var root = CreateTree(data);
    var actual = new Solution().PreorderTraversal(root);
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
    if(data == null || data.Length == 0)
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