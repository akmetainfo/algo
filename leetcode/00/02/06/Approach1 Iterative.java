// 206. Reverse Linked List
// https://leetcode.com/problems/reverse-linked-list/

/*
    Time: O(n) Assume that n is the list's length, the time complexity is O(n).
    Space: O(1)
*/
public class Solution {
    public ListNode reverseList(ListNode head) {
        ListNode prev = null;
        var curr = head;
        while (curr != null) {
            var nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }
        return prev;
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