// 559. Maximum Depth of N-ary Tree
// https://leetcode.com/problems/maximum-depth-of-n-ary-tree/

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution {
    public int maxDepth(Node root) {
        var result = 0;
        if (root == null) return result;

        var nodes = new Stack<Node>();
        nodes.push(root);
        var depths = new Stack<Integer>();
        depths.push(1);

        while (nodes.size() != 0) {
            root = nodes.pop();
            var depth = depths.pop();

            result = Math.max(result, depth);

            for (var child : root.children) {
                nodes.push(child);
                depths.push(depth + 1);
            }
        }

        return result;
    }
}