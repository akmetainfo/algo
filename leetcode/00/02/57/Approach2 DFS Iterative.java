// 257. Binary Tree Paths
// https://leetcode.com/problems/binary-tree-paths/

/*
    Time: O(N)
    Space: O(N) for stacks and list
*/
public class Solution {
    public List<String> binaryTreePaths(TreeNode root) {
        List<String> result = new ArrayList<>();

        if (root == null)
            return result;

        var stack = new Stack<TreeNode>();
        var paths = new Stack<String>();
        stack.push(root);
        paths.push("");

        while (stack.size() != 0) {
            root = stack.pop();
            var path = paths.pop();

            path += root.val;

            if (root.left == null && root.right == null) {
                result.add(path);
                continue;
            }

            if (root.left != null) {
                stack.push(root.left);
                paths.push(path + "->");
            }

            if (root.right != null) {
                stack.push(root.right);
                paths.push(path + "->");
            }
        }

        return result;
    }
}