// 203. Remove Linked List Elements
// https://leetcode.com/problems/remove-linked-list-elements/

/*
    Time: O(n) where n is the number of ListNode.
    Space: O(1)
*/
public class Solution {
    public ListNode removeElements(ListNode head, int val) {
        var dummy = new ListNode(-1);
        dummy.next = head;
        var curr = dummy;

        while (curr.next != null) {
            if (curr.next.val == val)
                curr.next = curr.next.next;
            else
                curr = curr.next;
        }

        return dummy.next;
    }
}
