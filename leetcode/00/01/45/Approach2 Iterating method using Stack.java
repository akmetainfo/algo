// 145. Binary Tree Postorder Traversal
// https://leetcode.com/problems/binary-tree-postorder-traversal/

/*
    Time: O(N) where n is nodes's count. Beause we visit all nodes in tree, only once
    Space: O(H) in worst case (completely unbalanced tree) it's O(N) and in best case O(logN) 'cause total elements in perfect tree is (2 ^ level) - 1
*/
// minor changes: https://www.youtube.com/watch?v=JVx83jhzy0U https://www.youtube.com/watch?v=Apgpt-99tI8
public class Solution {
    //
    //                      1          PostOrder: 5 -> 2 -> 3 -> 1
    //                    /   \        result =
    //                   2     3       stack  =
    //                  / \   / \      root   =
    //                 x  5  x   x     peek   =
    //                   / \           last   =
    //                  x   x
    //
    public List<Integer> postorderTraversal(TreeNode root) {
        Stack<TreeNode> stack = new Stack<>();
        List<Integer> result = new ArrayList<>();
        TreeNode lastNode = null;
        while (stack.size() > 0 || root != null) {
            if (root != null) // DFS: it's time to go deeper!
            {
                stack.push(root);
                root = root.left;
            } else {
                // at this point two situation are available:
                // peek node a) has right subtree or b) doesn't have right subtree
                var peek = stack.peek();
                // if right subtree exits so it also two possibilities: if we were at right direction or we weren't
                if (peek.right != null && lastNode != peek.right) {
                    root = peek.right;
                } else {
                    result.add(peek.val);
                    lastNode = stack.pop();
                }
            }
        }
        return result;
    }
}

public class Solution1 {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> result = new ArrayList<>();

        if (root == null)
            return result;

        Stack<TreeNode> stack = new Stack<>();

        stack.push(root);

        while (stack.size() > 0) {
            root = stack.pop();
            result.add(root.val);

            if (root.left != null) {
                stack.push(root.left);
            }

            if (root.right != null) {
                stack.push(root.right);
            }
        }

        Collections.reverse(result);

        return result;
    }
}