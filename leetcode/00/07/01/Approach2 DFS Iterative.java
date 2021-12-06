// 701. Insert into a Binary Search Tree
// https://leetcode.com/problems/insert-into-a-binary-search-tree/

/*
    Time: O(log N)
    Space: O(1)
*/
public class Solution {
    public TreeNode insertIntoBST(TreeNode root, int val) {
        if (root == null)
            return new TreeNode(val);

        var prev = root;
        var curr = root;

        while (curr != null) {
            prev = curr;
            curr = val > curr.val ? curr.right : curr.left;
        }

        var insertedNode = new TreeNode(val);

        if (val > prev.val)
            prev.right = insertedNode;
        else
            prev.left = insertedNode;

        return root;
    }
}