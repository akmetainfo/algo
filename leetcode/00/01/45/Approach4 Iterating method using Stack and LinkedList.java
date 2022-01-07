// 145. Binary Tree Postorder Traversal
// https://leetcode.com/problems/binary-tree-postorder-traversal/

/*
    Time: O(N^2) because insert requires linear time (you can use linked list instead of List)
    Space: O()
*/
// https://www.youtube.com/watch?v=sMI4RBEZyZ4
public class Solution {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> result = new ArrayList<>();
        if (root == null)
            return result;

        Stack<TreeNode> stack = new Stack<>();
        stack.push(root);
        while (stack.size() > 0) {
            root = stack.pop();

            result.add(0, root.val);

            if (root.left != null)
                stack.push(root.left);

            if (root.right != null)
                stack.push(root.right);
        }
        return result;
    }
}


/*
    Time: O(N), two pass solution, second pass is for converting linked list to list
    Space: O()
*/
public class Solution1 {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> result = new LinkedList<>();

        if (root == null)
            return result;

        Stack<TreeNode> stack = new Stack<>();
        stack.push(root);
        while (stack.size() > 0) {
            root = stack.pop();

            result.add(0, root.val);

            if (root.left != null)
                stack.push(root.left);

            if (root.right != null)
                stack.push(root.right);
        }
        return result;
    }
}