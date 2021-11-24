// 559. Maximum Depth of N-ary Tree
// https://leetcode.com/problems/maximum-depth-of-n-ary-tree/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public int maxDepth(Node root) {
        var result = 0;
        if (root == null) return result;
        Queue<Node> queue = new LinkedList<Node>();
        queue.add(root);
        while (queue.size() > 0) {
            var size = queue.size();
            for (int i = 0; i < size; i++) {
                root = queue.poll();
                for (var child : root.children) {
                    queue.add(child);
                }
            }
            result++;
        }
        return result;
    }
}