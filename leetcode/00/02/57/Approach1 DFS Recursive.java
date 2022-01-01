// 257. Binary Tree Paths
// https://leetcode.com/problems/binary-tree-paths/

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution {
    public List<String> binaryTreePaths(TreeNode root) {
        List<String> result = new ArrayList<>();

        if (root == null)
            return result;

        dfs(result, root, "");

        return result;
    }

    private final void dfs(List<String> result, TreeNode node, String path) {
        path += node.val;

        if (node.left == null && node.right == null) {
            result.add(path);
            return;
        }

        if (node.left != null)
            dfs(result, node.left, path + "->");

        if (node.right != null)
            dfs(result, node.right, path + "->");
    }
}