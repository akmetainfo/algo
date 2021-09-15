<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 700. Search in a Binary Search Tree
// https://leetcode.com/problems/search-in-a-binary-search-tree/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new object[] { 4, 2, 7, 1, 3 }, 2, new object[] { 2, 1, 3 })]
[TestCase(new object[] { 4, 2, 7, 1, 3 }, 5, new object[] { })]
public void SolutionTests(object[] data, int val, object[] expected)
{
    var root = CreateTree(data);
    var actual = new Solution().SearchBST(root, val);
    var result = IsSameTree(actual, CreateTree(expected));
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