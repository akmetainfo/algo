<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 257. Binary Tree Paths
// https://leetcode.com/problems/binary-tree-paths/

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
    	var result = new List<string>();
        
		if (root == null)
			return result;
            
    	DFS(result, root);
        
    	return result;
    }

    private static void DFS(IList<string> result, TreeNode node, string path = "")
    {
        path += node.val;
        
		if (node.left == null && node.right == null)
        {
			result.Add(path);
            return;
        }
        
        if(node.left != null)
		    DFS(result, node.left, path + "->");
        
        if(node.right != null)
		    DFS(result, node.right, path + "->");
    }
}

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution4
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();
        DFS(root, new List<string>(), result);
        return result;
    }

    private void DFS(TreeNode root, IList<string> oneResult, IList<string> result)
    {
        if (root == null)
            return;
        oneResult.Add($"{root.val}");
        if (root.left == null && root.right == null)
        {
            // leaf
            result.Add(string.Join("->", oneResult));
        } else {
            DFS(root.left, oneResult, result);
            DFS(root.right, oneResult, result);
        }
        oneResult.RemoveAt(oneResult.Count - 1);
    }
}

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution3
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
    	var result = new List<string>();
    	DFS(result, root);
    	return result;
    }

    void DFS(IList<string> result, TreeNode node, string path = "")
    {
		if (node == null)
			return;
		if (node.left == null && node.right == null)
			result.Add($"{path}{node.val}");
		else
		{
			DFS(result, node.left, $"{path}{node.val}->");
			DFS(result, node.right, $"{path}{node.val}->");
		}
    }
}

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution2
{
	public IList<string> BinaryTreePaths(TreeNode root)
    {
		var list = new List<string>();
		Add(root, string.Empty, list);  
		return list;
	}

	private void Add(TreeNode root, string s, IList<string> list)
    {
		if (root == null)
            return;

		if (root.left == null && root.right == null)
        {
			s += root.val.ToString();
			list.Add(s);
		}
		else 
		{
			s += root.val + "->";
			Add(root.left, s, list);
			Add(root.right, s, list);
		}
	}
}

public class Solution1
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var list = new List<string>();
        Traverse(root,"", list);
        return list;
    }

    private void Traverse(TreeNode root,string path, IList<string> list)
    {
        if(root == null)
            return;       
        if(root.left == null && root.right == null)
            list.Add(path+root.val);
        Traverse(root.left,path+root.val+"->",list);
        Traverse(root.right,path+root.val+"->",list);
    }
}

[Test]
[TestCase(new object[] { 1,2,3,null,5 }, new string[] { "1->2->5","1->3" })]
public void SolutionTests(object[] data, string[] expected)
{
    var root = CreateTree(data);
    var actual = new Solution().BinaryTreePaths(root);
    Assert.That(actual, Is.EquivalentTo(expected));
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