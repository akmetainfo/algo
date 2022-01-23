// 203. Remove Linked List Elements
// https://leetcode.com/problems/remove-linked-list-elements/

/*
    Time: O(n) where n is the number of ListNode.
    Space: O(1)
*/
public class Solution {
    public ListNode removeElements(ListNode head, int val) {
        while (head != null && head.val == val)
            head = head.next;

        var node = head;

        while (node != null && node.next != null) {
            if (node.next.val == val)
                node.next = node.next.next;
            else
                node = node.next;
        }

        return head;
    }
}