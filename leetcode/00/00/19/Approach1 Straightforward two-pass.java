// 19. Remove Nth Node From End of List
// https://leetcode.com/problems/remove-nth-node-from-end-of-list/

/*
    Time: O(N) two-pass
    Space: O(1)
*/
public class Solution {
    public ListNode removeNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode(0);
        dummy.next = head;

        var len = 0;
        while (head != null) {
            head = head.next;
            len++;
        }

        var prev = len - n;

        head = dummy;
        while (prev > 0) {
            head = head.next;
            prev--;
        }

        head.next = head.next.next;

        return dummy.next;
    }
}
