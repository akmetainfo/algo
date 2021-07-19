<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 104. Maximum Depth of Binary Tree
// https://leetcode.com/problems/maximum-depth-of-binary-tree/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        var result = 0;
        
        if(root == null)
            return result;
            
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count()>0)
        {
            result++;
            var size = queue.Count();
            for(var i = 0; i < size; i++)
            {
                root = queue.Dequeue();
                
                if(root.left != null)
                    queue.Enqueue(root.left);
                    
                if(root.right != null)
                    queue.Enqueue(root.right);
            }
        }
        
        return result;
    }
}

// BFS solution with two list
public class Solution1
{
    public int MaxDepth (TreeNode root)
    {
        var result = 0;
        var curr = new List<TreeNode> ();
        var next = new List<TreeNode> ();
        curr.Add(root);
        while (curr.Count() != 0) {
            next.Clear();
            var hasValue = false;
            foreach (var node in curr)
            {
                if (node != null)
                {
                    hasValue = true;
                    next.Add (node.left);
                    next.Add (node.right);
                }
            }
            if (hasValue)
                result++;
            curr.Clear ();
            curr.AddRange(next);
        }
        return result;
    }
}

[Test]
[TestCase(new object[] { 3,9,20,null,null,15,7 }, 3)]
[TestCase(new object[] { 1,null,2 }, 2)]
[TestCase(new object[] { }, 0)]
[TestCase(new object[] { 0 }, 1)]
public void SolutionTests(object[] data, int expected)
{
    var root = CreateTree(data);
    var actual = new Solution().MaxDepth(root);
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