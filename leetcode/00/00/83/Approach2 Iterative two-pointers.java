// 83. Remove Duplicates from Sorted List
// https://leetcode.com/problems/remove-duplicates-from-sorted-list/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public ListNode deleteDuplicates(ListNode head) {
        if (head == null || head.next == null) return head;

        var prev = head;
        var curr = head.next;

        while (curr != null) {
            if (curr.val == prev.val)
                prev.next = curr.next;
            else
                prev = curr;

            curr = curr.next;
        }

        return head;
    }
}