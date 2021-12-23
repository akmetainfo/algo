// 114. Flatten Binary Tree to Linked List
// https://leetcode.com/problems/flatten-binary-tree-to-linked-list/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public void flatten(TreeNode root) {
        if (root == null)
            return;

        var dummy = new TreeNode();
        var stack = new Stack<TreeNode>();
        stack.push(root);
        while (stack.size() != 0) {
            root = stack.pop();

            dummy.left = null;
            dummy.right = root;
            dummy = dummy.right;

            if (root.right != null)
                stack.push(root.right);
            if (root.left != null)
                stack.push(root.left);
        }
    }
}