<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 965. Univalued Binary Tree
// https://leetcode.com/problems/univalued-binary-tree/

/*
    Time: O(n), where n is number of nodes in tree
    Space: O(n)
*/
public class Solution
{
    public bool IsUnivalTree(TreeNode root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        while(stack.Count() > 0 || root != null)
        {
            if(root !=null)
            {
                result.Add(root.val);
                stack.Push(root);
                root = root.left;
            }
            else
            {
                root = stack.Pop();
                root = root.right;
            }
        }
        var first = result[0];
        foreach(var item in result)
        {
            if(item != first)
                return false;
        }
        return true;
    }
}


/*
    Time: O(n), where n is number of nodes in tree
    Space: O(n)
*/
public class Solution1
{
    public bool IsUnivalTree(TreeNode root)
    {
        var target = root.val;
            
        var stack = new Stack<TreeNode>();
        while(stack.Count() > 0 || root != null)
        {
            if(root !=null)
            {
                if(root.val != target)
                    return false;
                stack.Push(root);
                root = root.left;
            }
            else
            {
                root = stack.Pop();
                root = root.right;
            }
        }
        return true;
    }
}


/*
    Time: O(n), where n is number of nodes in tree
    Space: O(?)
*/
public class Solution2
{
    public bool IsUnivalTree(TreeNode root)
    {
        return IsUnivalTree(root, root.val);
    }
    
    public bool IsUnivalTree(TreeNode root, int val)
    {
        if(root.left != null)
        {
            if(root.left.val != val)
                return false;
            var leftResult = IsUnivalTree(root.left, root.val);
            if(leftResult == false)
                return false;
        }
        if(root.right != null)
        {
            if(root.right.val != val)
                return false;
            var rightResult = IsUnivalTree(root.right, root.val);
            if(rightResult == false)
                return false;
        }
            
        
        return true;
    }
}

[Test]
[TestCase(new object[] { 1,1,1,1,1,null,1 }, true)]
[TestCase(new object[] { 2,2,2,5,2 }, false)]
public void SolutionTests(object[] data, bool expected)
{
    var root = CreateTree(data);
    var actual = new Solution().IsUnivalTree(root);
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