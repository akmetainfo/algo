<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 145. Binary Tree Postorder Traversal
// https://leetcode.com/problems/binary-tree-postorder-traversal/

/*
    Time: O(N) where n is nodes's count. Beause we visit all nodes in tree, only once
    Space: O(H) in worst case (completely unbalanced tree) it's O(N) and in best case O(logN) 'cause total elements in perfect tree is (2 ^ level) - 1
*/
// minor changes: https://www.youtube.com/watch?v=JVx83jhzy0U https://www.youtube.com/watch?v=Apgpt-99tI8
public class Solution
{
    //
    //                      1          PostOrder: 5 -> 2 -> 3 -> 1
    //                    /   \        result =
    //                   2     3       stack  =
    //                  / \   / \      root   =
    //                 x  5  x   x     peek   =
    //                   / \           last   =
    //                  x   x
    //
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        var result = new List<int>();
        TreeNode lastNode = null;
        while (stack.Count > 0 || root != null)
        {
            if (root != null) // DFS: it's time to go deeper!
            {
                stack.Push(root);
                root = root.left;
            }
            else
            {
                // at this point two situation are available:
                // peek node a) has right subtree or b) doesn't have right subtree
                var peek = stack.Peek();
                // if right subtree exits so it also two possibilities: if we were at right direction or we weren't
                if(peek.right != null && lastNode != peek.right)
                {
                    root = peek.right;
                }
                else
                {
                    result.Add(peek.val);
                    lastNode = stack.Pop();
                }
            }
        }
        return result;
    }
}

public class Solution1
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
            return result;

        var stack = new Stack<TreeNode>();
        
        stack.Push(root);

        while (stack.Count > 0)
        {
            root = stack.Pop();
            result.Add(root.val);

            if (root.left != null) {
                stack.Push(root.left);
            }

            if (root.right != null) {
                stack.Push(root.right);
            }
        }

        result.Reverse();

        return result;
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

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
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