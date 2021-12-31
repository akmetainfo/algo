// 101. Symmetric Tree
// https://leetcode.com/problems/symmetric-tree/

/*
    Time: O(N) Because we traverse the entire input tree once, the total run time is O(n), where n is the total number of nodes in the tree.
    Space: O(H) There is additional space required for the stack. 
*/
public class Solution {
    public boolean isSymmetric(TreeNode root) {
        var stack = new Stack<TreeNode>();
        stack.push(root);
        stack.push(root);
        while (stack.size() > 0) {
            var a = stack.pop();
            var b = stack.pop();
            if (a == null && b == null)
                continue;
            if (a == null || b == null)
                return false;
            if (a.val != b.val)
                return false;
            stack.push(a.left);
            stack.push(b.right);
            stack.push(a.right);
            stack.push(b.left);
        }
        return true;
    }
}