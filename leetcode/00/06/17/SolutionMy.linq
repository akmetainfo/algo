<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 617. Merge Two Binary Trees
// https://leetcode.com/problems/merge-two-binary-trees/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if(root1 == null && root2 == null)
            return null;
            
        var result = new TreeNode(0);
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(result);
        queue.Enqueue(root1);
        queue.Enqueue(root2);
        
        while(queue.Count != 0)
        {
            var root0 = queue.Dequeue();
            root1 = queue.Dequeue();
            root2 = queue.Dequeue();
            
            if(root1 == null && root2 == null)
                continue;
                
            if(root0 == null)
                root0 = new TreeNode(0);
                
            root0.val = (root1?.val ?? 0) + (root2?.val ?? 0);
            
            if(root1?.left != null || root2?.left != null)
            {
                root0.left = new TreeNode(0);
                root0.left.val = (root1?.left?.val ?? 0) + (root2?.left?.val ?? 0);
                queue.Enqueue(root0.left);
                queue.Enqueue(root1?.left);
                queue.Enqueue(root2?.left);
            }
            
            if(root1?.right != null || root2?.right != null)
            {
                root0.right = new TreeNode(0);
                root0.right.val = (root1?.right?.val ?? 0) + (root2?.right?.val ?? 0);
                queue.Enqueue(root0.right);
                queue.Enqueue(root1?.right);
                queue.Enqueue(root2?.right);
            }
        }
        
        return result;
    }
}


[Test]
[TestCase(new object[] { 1,3,2,5 }, new object[] { 2,1,3,null,4,null,7 }, new object[] { 3,4,5,5,4,null,7 })]
[TestCase(new object[] { }, new object[] { }, new object[] { })]
[TestCase(new object[] { 1,2,null,3 }, new object[] { 1,null,2,null,3 }, new object[] { 2, 2, 2, 3, null, null, 3})]
public void SolutionTests(object[] data1, object[] data2, object[] expected)
{
    var root1 = CreateTree(data1);
    var root2 = CreateTree(data2);
    var actual = new Solution().MergeTrees(root1, root2);
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