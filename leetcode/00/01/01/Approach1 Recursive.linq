<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 101. Symmetric Tree
// https://leetcode.com/problems/symmetric-tree/

/*
    Time: O(N) Because we traverse the entire input tree once, the total run time is O(n), where n is the total number of nodes in the tree.
    Space: O(H) The number of recursive calls is bound by the height of the tree. In the worst case, the tree is linear and the height is in O(n). Therefore, space complexity due to recursive calls on the stack is O(n) in the worst case. 
*/
public class Solution
{
    public bool IsSymmetric(TreeNode root)
    {
        return IsMirror(root, root);
    }

    public bool IsMirror(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null)
            return true;
            
        if (t1 == null || t2 == null)
            return false;
            
        return (t1.val == t2.val)
            && IsMirror(t1.right, t2.left)
            && IsMirror(t1.left, t2.right);
    }
}

[Test]
[TestCase(new object[] { 1,2,2,3,4,4,3 }, true)]
[TestCase(new object[] { 1,2,2,null,3,null,3 }, false)]
[TestCase(new object[] { 1,2,2,null,3,3 }, true)]
public void SolutionTests(object[] data, bool expected)
{
    var root = CreateTree(data);
    var actual = new Solution().IsSymmetric(root);
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