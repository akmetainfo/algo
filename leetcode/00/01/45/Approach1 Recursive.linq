<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 145. Binary Tree Postorder Traversal
// https://leetcode.com/problems/binary-tree-postorder-traversal/

/*
    Time: O(N), where n is node's count in the tree
    Space: O(H), where H - is height of the tree (worst case: O(N) for completely unbalanced tree, best case O(log N) for completely balaced)
*/
public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
            return result;

        if (root.left != null)
            result.AddRange(PostorderTraversal(root.left));

        if (root.right != null)
            result.AddRange(PostorderTraversal(root.right));

        result.Add(root.val);

        return result;
    }
}

/*
    Time: O(N), where n is node's count in the tree
    Space: O(H), where H - is height of the tree (worst case: O(N) for completely unbalanced tree, best case O(log N) for completely balaced)
*/
public class Solution1
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        PostorderTraversal(root, result);
        return result;
    }

    private void PostorderTraversal(TreeNode node, List<int> result)
    {
        if (node == null)
            return;

        if (node.left != null)
            PostorderTraversal(node.left, result);

        if (node.right != null)
            PostorderTraversal(node.right, result);
        
        result.Add(node.val);
    }
}

public class Solution2
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root != null)
            result = PostorderTraversalHelper(root).ToList();

        return result;
    }

    private static IEnumerable<int> PostorderTraversalHelper(TreeNode node)
    {
        if (node.left != null)
            foreach (var nod in PostorderTraversalHelper(node.left))
                yield return nod;

        if (node.right != null)
            foreach (var nod in PostorderTraversalHelper(node.right))
                yield return nod;

        yield return node.val;
    }
}

[Test]
[TestCase(new object[] { 1, null, 2, 3 }, new int[] { 3, 2, 1 })]
[TestCase(new object[] { }, new int[] { })]
[TestCase(new object[] { 1 }, new int[] { 1 })]
[TestCase(new object[] { 1, 2, 3 }, new int[] { 2, 3, 1 })]
[TestCase(new object[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 5, 2, 6, 7, 3, 1 })]
public void SolutionTests(object[] data, int[] expected)
{
    var root = CreateTree(data);
    var actual = new Solution().PostorderTraversal(root);
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