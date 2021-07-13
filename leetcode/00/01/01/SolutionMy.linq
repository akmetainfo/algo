<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 101. Symmetric Tree
// https://leetcode.com/problems/symmetric-tree/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsSymmetric(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count() > 0)
        {
            var size = queue.Count();
            var nextLevelNodes = new List<TreeNode>();
            for(var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                if(node == null)
                    continue;
                queue.Enqueue(node.left);
                nextLevelNodes.Add(node.left);
                queue.Enqueue(node.right);
                nextLevelNodes.Add(node.right);
            }
            if(!IsListSymmetric(nextLevelNodes))
                return false;
        }
        return true;
    }
    
    private static bool IsListSymmetric(List<TreeNode> list)
    {
        if(list.Count < 2)
            return true;
            
        var left = 0;
        var right = list.Count() - 1;
        while(left<right)
        {
            if(!IsNodesSymmetric(list[left], list[right]))
                return false;
            left++;
            right--;
        }
        
        return true;
    }
    
    private static bool IsNodesSymmetric(TreeNode a, TreeNode b)
    {
        if(a != null && b != null && a.val != b.val)
            return false;
        if(a == null && b != null)
            return false;
        if(a != null && b == null)
            return false;
            
        return true;
    }
}

[Test]
[TestCase(new object[] { 1,2,2,3,4,4,3 }, true)]
[TestCase(new object[] { 1,2,2,null,3,null,3 }, false)]
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