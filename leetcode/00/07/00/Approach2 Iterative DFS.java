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

        Stack<TreeNode> stack = new Stack<>();
        stack.push(root);
        while (stack.size() != 0) {
            root = stack.pop();
            if (root.val == val)
                return root;

            if (root.val > val && root.left != null)
                stack.push(root.left);

            if (root.val < val && root.right != null)
                stack.push(root.right);
        }

        return null;
    }
}

/*
    Time: O(H) height of the tree, so O(logN) in average and O(N) in worst case
    Space: O(1)
*/
public class Solution1 {
    public TreeNode searchBST(TreeNode root, int val) {
        while (root != null) {
            if (root.val == val)
                return root;

            if (root.val < val)
                root = root.right;
            else
                root = root.left;
        }

        return root;
    }
}
