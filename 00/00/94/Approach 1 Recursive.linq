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

        InorderTraversal(node.left, result);
        result.Add(node.val);
        InorderTraversal(node.right, result);
    }
}

[Test]
[TestCase(new object[] { 1, null, 2 }, new int[] { 1, 2 })]
public void SolutionTests(object[] data, int[] expected)
{
    var root = CreateRoot(data);
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

private TreeNode CreateRoot(object[] data)
{
    return new TreeNode(1, null, new TreeNode(2, null, null));
}

// TODO: https://www.geeksforgeeks.org/construct-complete-binary-tree-given-array/
//private TreeNode CreateRoot(object[] data)
//{
//    var root = new TreeNode();
//    root = InsertLevelOrder(data, root, 0);
//    return root;
//}
//
//public TreeNode InsertLevelOrder(int[] arr, TreeNode root, int i)
//{
//    if (i < arr.Length)
//    {
//        var temp = new TreeNode(arr[i]);
//        root = temp;
//
//        root.left = InsertLevelOrder(arr, root.left, 2 * i + 1);
//
//        root.right = InsertLevelOrder(arr, root.right, 2 * i + 2);
//    }
//    return root;
//}

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