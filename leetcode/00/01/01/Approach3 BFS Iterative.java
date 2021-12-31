// 101. Symmetric Tree
// https://leetcode.com/problems/symmetric-tree/

/*
    Time: O(N) Because we traverse the entire input tree once, the total run time is O(n), where n is the total number of nodes in the tree.
    Space: O(N) There is additional space required for the search queue. In the worst case, we have to insert n/2 nodes in the queue. Therefore, space complexity is O(n).
*/
public class Solution {
    public boolean isSymmetric(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList<>();
        queue.offer(root);
        queue.offer(root);
        while (queue.size() > 0) {
            var a = queue.poll();
            var b = queue.poll();
            if (a == null && b == null)
                continue;
            if (a == null || b == null)
                return false;
            if (a.val != b.val)
                return false;
            queue.offer(a.left);
            queue.offer(b.right);
            queue.offer(a.right);
            queue.offer(b.left);
        }
        return true;
    }
}