<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 102. Binary Tree Level Order Traversal
// https://leetcode.com/problems/binary-tree-level-order-traversal/

/*
    Time: O(N) where N is the number of nodes in the tree. Every node will be visited exactly once.
    Space: O(N). Queue will store at most N/2 nodes, which is the last row of the tree.
*/
public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if(root == null)
            return result;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0)
        {
            var count = queue.Count;
            var row = new List<int>();
            for(int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                row.Add(node.val);
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
            }
            result.Add(row);
        }
        return result;
    }
}

// fair BFS without nesting loop
// https://leetcode.com/problems/binary-tree-level-order-traversal/discuss/594281/C-fair-BFS-without-nesting-loop
public class Solution1
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {        
        var result = new List<IList<int>>();
        if (root==null) return result;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var levelCounter = 0;
        var newLevelReached = true;
        var currentLevelLimit = 1;
        var nextLevelLimit = 0;
        
        while(queue.Count>0)
        {
            if (newLevelReached)
            {
                result.Add(new List<int>());
                newLevelReached = false;
            }
            
            var current = queue.Dequeue();
            result.Last().Add(current.val);            
            
            if(current.left != null)
            { 
                queue.Enqueue(current.left);
                nextLevelLimit++;
            }
            if(current.right != null)
            { 
                queue.Enqueue(current.right);
                nextLevelLimit++;
            }
            
            if(++levelCounter == currentLevelLimit)
            {
                newLevelReached = true;
                currentLevelLimit = nextLevelLimit;
                nextLevelLimit = 0;
                levelCounter=0;
            }
        }
        
        return result;
    }
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new List<IList<int>> {
            new List<int> { 1 },
            new List<int> { 2 },
        },
        new object[] { 1, null, 2 },
    };

    yield return new object[]
    {
        new List<IList<int>> {
            new List<int> { 3 },
            new List<int> { 9, 20 },
            new List<int> { 15, 17 },
        },
        new object[] { 3,9,20,null,null,15,17 },
    };
}

[Test]
[TestCaseSource(nameof(TestCases))]
// unfortunately, object[] can be only last param
public void SolutionTests(IList<IList<int>> expected, object[] data)
{
    var root = CreateTree(data);
    var actual = new Solution().LevelOrder(root);
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