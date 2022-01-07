// 145. Binary Tree Postorder Traversal
// https://leetcode.com/problems/binary-tree-postorder-traversal/

/*
    Time: O(N), where n is node's count in the tree
    Space: O(H), where H - is height of the tree (worst case: O(N) for completely unbalanced tree, best case O(log N) for completely balaced)
*/
public class Solution {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> result = new ArrayList<>();

        if (root == null)
            return result;

        if (root.left != null)
            result.addAll(postorderTraversal(root.left));

        if (root.right != null)
            result.addAll(postorderTraversal(root.right));

        result.add(root.val);

        return result;
    }
}

/*
    Time: O(N), where n is node's count in the tree
    Space: O(H), where H - is height of the tree (worst case: O(N) for completely unbalanced tree, best case O(log N) for completely balaced)
*/
public class Solution1 {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> result = new ArrayList<>();
        postorderTraversal(root, result);
        return result;
    }

    private void postorderTraversal(TreeNode node, List<Integer> result) {
        if (node == null)
            return;

        if (node.left != null)
            postorderTraversal(node.left, result);

        if (node.right != null)
            postorderTraversal(node.right, result);

        result.add(node.val);
    }
}

