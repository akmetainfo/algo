// 897. Increasing Order Search Tree
// https://leetcode.com/problems/increasing-order-search-tree/

/*
    Time: O(N)
    Space: O(H) for call-stack and O(N) for creating a copy of tree in a new tree
*/
public class Solution {
    TreeNode result;

    public TreeNode increasingBST(TreeNode root) {
        var dummy = new TreeNode(-1);
        result = dummy;
        inOrder(root);
        return dummy.right;
    }

    private void inOrder(TreeNode root) {
        if (root.left != null)
            inOrder(root.left);

        result.right = new TreeNode(root.val);
        result = result.right;

        if (root.right != null)
            inOrder(root.right);
    }
}