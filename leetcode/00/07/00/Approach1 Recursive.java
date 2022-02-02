// 700. Search in a Binary Search Tree
// https://leetcode.com/problems/search-in-a-binary-search-tree/

/*
    Time: O(H) height of the tree, so O(logN) in average and O(N) in worst case
    Space: O(H)
*/
public class Solution {
    public TreeNode searchBST(TreeNode root, int val) {
        if (root == null)
            return root;

        if (root.val == val)
            return root;

        if (root.val > val)
            return searchBST(root.left, val);

        return searchBST(root.right, val);
    }
}