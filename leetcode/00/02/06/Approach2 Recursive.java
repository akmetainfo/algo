// 206. Reverse Linked List
// https://leetcode.com/problems/reverse-linked-list/

/*
    Time: O(n) Assume that n is the list's length, the time complexity is O(n).
    Space: O(n) The extra space comes from implicit stack space due to recursion. The recursion could go up to n levels deep.
*/
public class Solution {
    public ListNode reverseList(ListNode head) {
        if (head == null || head.next == null)
            return head;

        var node = reverseList(head.next);
        head.next.next = head;
        head.next = null;
        return node; // node is always last node of whole(original) list
    }
}

public class ListNode {
    int val;
    ListNode next;

    ListNode() {
    }

    ListNode(int val) {
        this.val = val;
    }

    ListNode(int val, ListNode next) {
        this.val = val;
        this.next = next;
    }
}
