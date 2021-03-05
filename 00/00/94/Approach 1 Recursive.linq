<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 94. Binary Tree Inorder Traversal
// https://leetcode.com/problems/binary-tree-inorder-traversal/

/*
    Time: O(n) The time complexity is O(n) because the recursive function is T(n) = 2⋅T(n/2)+1.s
    Space: O(n) The worst case space required is O(n), and in the average case it's O(log n) where n is number of nodes.
*/
public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
            return result;

        if (root.left != null)
            result.AddRange(InorderTraversal(root.left));
            
        result.Add(root.val);
        
        if (root.right != null)
            result.AddRange(InorderTraversal(root.right));

        return result;
    }
}

public class Solution1
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        InorderTraversal(root, result);
        return result;
    }

    private void InorderTraversal(TreeNode node, List<int> result)
    {
        if (node == null)
            return;

        if (node.left != null)
            InorderTraversal(node.left, result);
            
        result.Add(node.val);

        if (node.right != null)
            InorderTraversal(node.right, result);
    }
}

public class Solution2
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root != null)
            result = InorderTraversalHelper(root).ToList();

        return result;
    }

    private static IEnumerable<int> InorderTraversalHelper(TreeNode node)
    {
        if (node.left != null)
            foreach (var nod in InorderTraversalHelper(node.left))
                yield return nod;

        yield return node.val;

        if (node.right != null)
            foreach (var nod in InorderTraversalHelper(node.right))
                yield return nod;
    }
}

[Test]
[TestCase(new object[] { 1, null, 2, 3 }, new int[] { 1, 3, 2 })]
[TestCase(new object[] { }, new int[] { })]
[TestCase(new object[] { 1 }, new int[] { 1 })]
[TestCase(new object[] { 1, 2, 3 }, new int[] { 2, 1, 3 })]
public void SolutionTests(object[] data, int[] expected)
{
    var root = CreateTree(data);
    var actual = new Solution().InorderTraversal(root);
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