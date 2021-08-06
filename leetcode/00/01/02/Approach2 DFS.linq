<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 102. Binary Tree Level Order Traversal
// https://leetcode.com/problems/binary-tree-level-order-traversal/

/*
    Time: O(N) where n - nodes in tree
    Space: O(H) where h - height of tree and O(N) for storing lists
*/
public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        
        DFS(root, result, 0);
        
        return result;
    }
    
    private static void DFS(TreeNode root, IList<IList<int>> result, int level)
    {
        if(root == null)
            return;
            
        if(result.Count == level)
            result.Add(new List<int>());
        
        result[level].Add(root.val);

        level++;

        DFS(root.left, result, level);
        DFS(root.right, result, level);
    }  
}

private static IEnumerable<object[]> TestCases()
{
    yield return new object[]
    {
        new List<IList<int>> {
        },
        new object[] { },
    };

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