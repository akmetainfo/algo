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

        result++;

        for (var child : root.children) {
            var depth = 1 + maxDepth(child);
            result = Math.max(result, depth);
        }

        return result;
    }
}