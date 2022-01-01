// 257. Binary Tree Paths
// https://leetcode.com/problems/binary-tree-paths/

/*
    Time: O(N) where N is number of nodes
    Space: O(N) for storing queue, O(N) for storing result, O(N) for storing paths
*/
public class Solution {
    public List<String> binaryTreePaths(TreeNode root) {
        List<String> result = new ArrayList<>();

        if (root == null)
            return result;

        Queue<TreeNode> queue = new LinkedList<>();
        Queue<String> paths = new LinkedList<>();

        queue.offer(root);
        paths.offer("");

        while (queue.size() > 0) {
            root = queue.poll();
            var path = paths.poll();

            path += root.val;

            if (root.left == null && root.right == null) {
                result.add(path);
                continue;
            }

            if (root.right != null) {
                queue.offer(root.right);
                paths.offer(path + "->");
            }

            if (root.left != null) {
                queue.offer(root.left);
                paths.offer(path + "->");
            }
        }

        return result;
    }
}