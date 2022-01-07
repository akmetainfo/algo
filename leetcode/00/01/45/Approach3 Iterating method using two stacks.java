// 145. Binary Tree Postorder Traversal
// https://leetcode.com/problems/binary-tree-postorder-traversal/

/*
    Time: O()
    Space: O()
*/
// https://codestandard.net/articles/binary-tree-postorder-traversal/
public class Solution {
    public List<Integer> postorderTraversal(TreeNode root) {
        if (root == null)
            return new ArrayList<Integer>();

        Stack<Integer> result = new Stack<>();
        Stack<TreeNode> stack = new Stack<>();

        stack.push(root);

        while (stack.size() != 0) {
            TreeNode node = stack.pop();
            result.push(node.val);

            if (node.left != null) {
                stack.push(node.left);
            }

            if (node.right != null) {
                stack.push(node.right);
            }
        }
        Collections.reverse(result);
        return new ArrayList(result);
    }
}