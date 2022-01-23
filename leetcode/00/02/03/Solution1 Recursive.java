// 203. Remove Linked List Elements
// https://leetcode.com/problems/remove-linked-list-elements/

/*
    Time: O(n) where n is the number of ListNode.
    Space: O(n) for storing call stack
*/
public class Solution {
    public ListNode removeElements(ListNode head, int val) {
        if (head == null)
            return null;

        head.next = removeElements(head.next, val);

        if (head.val == val)
            return head.next;
        else
            return head;
    }
}

/*
    Time: O(n) where n is the number of ListNode.
    Space: O(n) for storing call stack
*/
public class Solution1 {
    public ListNode removeElements(ListNode head, int val) {
        if (head == null)
            return head;

        var node = removeElements(head.next, val);

        if (head.val == val) {
            return node;
        } else {
            head.next = node;
            return head;
        }
    }
}