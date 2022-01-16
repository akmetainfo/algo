// 19. Remove Nth Node From End of List
// https://leetcode.com/problems/remove-nth-node-from-end-of-list/

/*
    Time: O(N) One-pass
    Space: O(1)
*/
public class Solution {
    public ListNode removeNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode(0);
        dummy.next = head;

        var runner1 = dummy;
        while (n >= 0) {
            runner1 = runner1.next;
            n--;
        }

        var runner2 = dummy;
        while (runner1 != null) {
            runner1 = runner1.next;
            runner2 = runner2.next;
        }

        runner2.next = runner2.next.next;

        return dummy.next;
    }
}
