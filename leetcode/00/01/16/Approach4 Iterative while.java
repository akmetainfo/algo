// 116. Populating Next Right Pointers in Each Node
// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

/*
    Time: O()
    Space: O()
*/
public class Solution {
    public Node connect(Node root) {
        if (root == null)
            return null;

        var leftMost = root;

        while (leftMost.left != null) {
            var curr = leftMost;
            while (curr != null) // tell me why we can omit && leftNode.left != null
            {
                curr.left.next = curr.right;

                if (curr.next != null)
                    curr.right.next = curr.next.left;

                curr = curr.next;
            }

            leftMost = leftMost.left;
        }

        return root;
    }
}

/*
    Time: O()
    Space: O()
*/
public class Solution1 {
    public Node connect(Node root) {
        if (root == null)
            return null;

        var leftNode = root;

        while (leftNode != null && leftNode.left != null) {
            populateChildLevel(leftNode);
            leftNode = leftNode.left;
        }

        return root;
    }

    private void populateChildLevel(Node startNode) {
        var current = startNode;
        while (current != null) {
            current.left.next = current.right;

            if (current.next != null)
                current.right.next = current.next.left;

            current = current.next;
        }
    }
}