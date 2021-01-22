<Query Kind="Program" />

void Main()
{
	var t1 = new TreeNode(3, null, null);
	var t2 = new TreeNode(2, t1, null);
	var t3 = new TreeNode(1, null, t2);

	new Solution1().PreorderTraversal(t3).Dump();
	new Solution2().InorderTraversal(t3).Dump();
	new Solution3().PostorderTraversal(t3).Dump();
}

// Define other methods and classes here
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

public class Solution3
{
	public IList<int> PostorderTraversal(TreeNode root)
	{
		var list = new List<int>();

		if (root == null)
			return list;

		return Traverse(root, list);
	}

	// In pre order left=>right=>root
	private static IList<int> Traverse(TreeNode root, IList<int> list)
	{
		if (root == null)
			return list;

		if (root.left != null)
			Traverse(root.left, list);

		if (root.right != null)
			Traverse(root.right, list);

		list.Add(root.val);
		
		return list;
	}
}

public class Solution2
{
	public IList<int> InorderTraversal(TreeNode root)
	{
		var list = new List<int>();

		if (root == null)
			return list;

		return Traverse(root, list);
	}

	// In pre order left=>root=>right
	private static IList<int> Traverse(TreeNode root, IList<int> list)
	{
		if (root == null)
			return list;

		if (root.left != null)
			Traverse(root.left, list);

		list.Add(root.val);

		if (root.right != null)
			Traverse(root.right, list);

		return list;
	}
}

public class Solution1
{
	public IList<int> PreorderTraversal(TreeNode root)
	{
		var list = new List<int>();

		if (root == null)
			return list;

		return Traverse(root, list);
	}

	// In pre order root=>left=>right
	private static IList<int> Traverse(TreeNode root, IList<int> list)
	{
		if (root == null)
			return list;

		list.Add(root.val);

		if (root.left != null)
			Traverse(root.left, list);

		if (root.right != null)
			Traverse(root.right, list);

		return list;
	}
}