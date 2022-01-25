// 83. Remove Duplicates from Sorted List
// https://leetcode.com/problems/remove-duplicates-from-sorted-list/

/*
    Time: O(N)
    Space: O(N) for call stack
*/
public class Solution {
    // Approach3 Recursive
    public ListNode deleteDuplicates(ListNode head) {
        if (head == null || head.next == null) return head;

        head.next = deleteDuplicates(head.next);

        if (head.val == head.next.val)
            return head.next;

        return head;
    }
}

/*
    Time: O(N)
    Space: O(N) for call stack
*/
public class Solution1 {
    public ListNode deleteDuplicates(ListNode head) {
        if (head == null || head.next == null) return head;
        if (head.val == head.next.val) {
            head = deleteDuplicates(head.next);
        }
        head.next = deleteDuplicates(head.next);
        return head;
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

