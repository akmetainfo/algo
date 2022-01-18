// 897. Increasing Order Search Tree
// https://leetcode.com/problems/increasing-order-search-tree/

/*
    Time: O(N)
    Space: O(H) for call-stack and O(N) for creating a copy of tree in a new tree
*/
public class Solution {
	public TreeNode increasingBST(TreeNode root) {
        var result = new TreeNode(0);
        var current = result;
		Stack<TreeNode> stack = new Stack<>();
        while (stack.size() != 0 || root != null) {
            if (root != null) {
                stack.push(root);
                root = root.left;
            } else {
                root = stack.pop();

                current.left = null;
                current.right = new TreeNode(root.val);
                current = current.right;

                root = root.right;
            }
        }
        return result.right;
    }
}