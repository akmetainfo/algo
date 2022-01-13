// 102. Binary Tree Level Order Traversal
// https://leetcode.com/problems/binary-tree-level-order-traversal/

/*
    Time: O(N) where N is the number of nodes in the tree. Every node will be visited exactly once.
    Space: O(N). Queue will store at most N/2 nodes, which is the last row of the tree.
*/
public class Solution {
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> result = new ArrayList<>();
        if (root == null)
            return result;
        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);
        while (queue.size() > 0) {
            var count = queue.size();
            List<Integer> row = new ArrayList<>();
            for (int i = 0; i < count; i++) {
                var node = queue.poll();
                row.add(node.val);
                if (node.left != null)
                    queue.add(node.left);
                if (node.right != null)
                    queue.add(node.right);
            }
            result.add(row);
        }
        return result;
    }
}

// fair BFS without nesting loop
// https://leetcode.com/problems/binary-tree-level-order-traversal/discuss/594281/C-fair-BFS-without-nesting-loop
public class Solution1 {
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> result = new ArrayList<>();
        if (root == null)
            return result;
        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);
        var levelCounter = 0;
        var newLevelReached = true;
        var currentLevelLimit = 1;
        var nextLevelLimit = 0;

        while (queue.size() > 0) {
            if (newLevelReached) {
                result.add(new ArrayList<Integer>());
                newLevelReached = false;
            }

            var current = queue.poll();
            result.get(result.size() - 1).add(current.val);

            if (current.left != null) {
                queue.add(current.left);
                nextLevelLimit++;
            }
            if (current.right != null) {
                queue.add(current.right);
                nextLevelLimit++;
            }

            if (++levelCounter == currentLevelLimit) {
                newLevelReached = true;
                currentLevelLimit = nextLevelLimit;
                nextLevelLimit = 0;
                levelCounter = 0;
            }
        }

        return result;
    }
}