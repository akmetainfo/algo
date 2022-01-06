// 116. Populating Next Right Pointers in Each Node
// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public Node connect(Node root) {
        if (root == null)
            return root;

        var result = root;
        Queue<Node> queue = new LinkedList<>();
        queue.offer(root);
        while (queue.size() != 0) {
            var size = queue.size();
            Node prev = null;
            for (int i = 0; i < size; i++) {
                root = queue.poll();

                if (i > 0)
                    prev.next = root;

                prev = root;

                if (root.left != null)
                    queue.offer(root.left);

                if (root.right != null)
                    queue.offer(root.right);
            }
        }
        return result;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution2 {
    // Approach3 BFS
    public Node connect(Node root) {
        if (root == null)
            return null;

        Queue<Node> queue = new LinkedList<>();
        queue.offer(root);
        var result = root;
        while (queue.size() != 0) {
            Node dummy = null;

            var size = queue.size();
            for (int i = 0; i < size; i++) {
                root = queue.poll();

                if (i == 0) {
                    dummy = root;
                } else {
                    dummy.next = root;
                    dummy = dummy.next;
                }


                if (root.left != null)
                    queue.offer(root.left);

                if (root.right != null)
                    queue.offer(root.right);
            }
        }
        return result;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1 {
    public Node connect(Node root) {
        if (root == null)
            return root;

        var result = root;
        Queue<Node> queue = new LinkedList<>();
        queue.offer(root);
        while (queue.size() != 0) {
            var size = queue.size();
            var dummy = new Node();
            for (int i = 0; i < size; i++) {
                root = queue.poll();
                dummy.next = root;
                dummy = dummy.next;

                if (root.left != null)
                    queue.offer(root.left);

                if (root.right != null)
                    queue.offer(root.right);
            }
        }
        return result;
    }
}
