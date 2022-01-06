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

        setNextNode(root.left, root.right);

        return root;
    }

    private void setNextNode(Node left, Node right) {
        if (left == null)
            return;

        left.next = right;

        setNextNode(left.left, left.right);
        setNextNode(left.right, right.left);
        setNextNode(right.left, right.right);
    }
}

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution2 {
    public Node connect(Node root) {
        if (root == null)
            return null;

        if (root.left == null) // Leaf check in a perfect tree
            return root;

        if (root.next != null && root.right != null)
            root.right.next = root.next.left;

        root.left.next = root.right;

        if (root.left.right != null)
            root.left.right.next = root.left.next.left;

        root.left = connect(root.left);
        root.right = connect(root.right);

        return root;
    }
}

/*
    Time: O(N)
    Space: O(H)
*/
public class Solution1 {
    public Node connect(Node root) {
        if (root == null)
            return null;

        connectRecursive(root, null);

        return root;
    }

    private void connectRecursive(Node node, Node prev) {
        if (node.left == null) // Leaf check in a perfect tree
            return;

        node.left.next = node.right;

        if (prev != null)
            prev.right.next = node.left;

        connectRecursive(node.left, prev != null ? prev.right : null);

        connectRecursive(node.right, node.left);
    }
}
