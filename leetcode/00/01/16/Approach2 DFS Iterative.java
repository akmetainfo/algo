// 116. Populating Next Right Pointers in Each Node
// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution {
    public Node connect(Node root) {
        if (root == null)
            return null;

        Stack<Node> stack = new Stack<>();
        stack.push(root);

        while (stack.size() != 0) {
            var node = stack.pop();

            if (node.left != null) {
                node.left.next = node.right;
                stack.push(node.left);
            }

            if (node.right != null) {
                if (node.next != null)
                    node.right.next = node.next.left;

                stack.push(node.right);
            }
        }

        return root;
    }
}

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution1 {
    // Approach2 DFS Iterative
    public Node connect(Node root) {
        if (root == null)
            return null;

        Stack<Node> stack = new Stack<>();

        stack.push(root);

        while (stack.size() != 0) {
            var node = stack.pop();

            if (node.left != null)
                node.left.next = node.right;

            if (node.right != null)
                node.right.next = node.next == null ? null : node.next.left;

            if (node.left != null)
                stack.push(node.left);

            if (node.right != null)
                stack.push(node.right);
        }

        return root;
    }
}
