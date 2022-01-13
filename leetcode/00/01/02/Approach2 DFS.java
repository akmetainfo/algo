// 102. Binary Tree Level Order Traversal
// https://leetcode.com/problems/binary-tree-level-order-traversal/

/*
    Time: O(N) where n - nodes in tree
    Space: O(H) where h - height of tree and O(N) for storing lists
*/
public class Solution {
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> result = new ArrayList<>();
        dfs(root, result, 0);
        return result;
    }

    private static void dfs(TreeNode root, List<List<Integer>> result, int level) {
        if (root == null)
            return;
        if (result.size() == level)
            result.add(new ArrayList<Integer>());
        result.get(level).add(root.val);
        level++;
        dfs(root.left, result, level);
        dfs(root.right, result, level);
    }
}
