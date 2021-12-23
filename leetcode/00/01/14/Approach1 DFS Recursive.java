// 114. Flatten Binary Tree to Linked List
// https://leetcode.com/problems/flatten-binary-tree-to-linked-list/

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution {
    public void flatten(TreeNode root) {
        if (root == null)
            return;

        flatten(root.right);
        flatten(root.left);

        if (root.left == null)
            return;

        var current = root.left;
        while (current.right != null)
            current = current.right;

        current.right = root.right;
        root.right = root.left;
        root.left = null;
    }
}