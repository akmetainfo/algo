<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 100. Same Tree
// https://leetcode.com/problems/same-tree/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if(p == null && q == null)
            return true;
            
        var pArr = PreorderTraversal(p);
        var qArr = PreorderTraversal(q);
        
        if(pArr.Length != qArr.Length)
            return false;
        
        for(var i = 0; i < pArr.Length; i++)
        {
            if((pArr[i] == null && qArr[i] != null) ||
               (pArr[i] != null && qArr[i] == null) ||
               (pArr[i] != null && qArr[i] != null &&  pArr[i].val != qArr[i].val)
               )
                return false;
            
        }
        return true;
    }
    
    private static TreeNode[] PreorderTraversal(TreeNode root)
    {
        var result = new List<TreeNode>();

        if (root == null)
        {
            result.Add(root);
            return result.ToArray();
        }

        result.Add(root);

        result.AddRange(PreorderTraversal(root.left));
            
        result.AddRange(PreorderTraversal(root.right));

        return result.ToArray();
    }
}

[Test]
[TestCase(new object[] { 1,2,3 }, new object[] { 1,2,3 }, true)]
[TestCase(new object[] { 1,2 }, new object[] { 1,null,2 }, false)]
[TestCase(new object[] { 1,2,1 }, new object[] { 1,1,2 }, false)]
public void SolutionTests(object[] root1, object[] root2, bool expected)
{
    var p = CreateTree(root1);
    var q = CreateTree(root2);
    var actual = new Solution().IsSameTree(p, q);
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