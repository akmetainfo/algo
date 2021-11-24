// 83. Remove Duplicates from Sorted List
// https://leetcode.com/problems/remove-duplicates-from-sorted-list/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public ListNode deleteDuplicates(ListNode head) {
        if (head == null || head.next == null)
            return head;

        var curr = head;
        while (curr != null && curr.next != null) {
            if (curr.val == curr.next.val)
                curr.next = curr.next.next;
            else
                curr = curr.next;
        }

        return head;
    }
}


/*
    Time: O(N)
    Space: O(1)
*/
public class Solution1 {
    public ListNode deleteDuplicates(ListNode head) {
        var result = head;
        while (head != null) {
            var prev = head;
            while (head != null && head.val == prev.val)
                head = head.next;
            prev.next = head;
        }
        return result;
    }
}