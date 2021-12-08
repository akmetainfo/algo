// 21. Merge Two Sorted Lists
// https://leetcode.com/problems/merge-two-sorted-lists/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public ListNode mergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) return list2;

        if (list2 == null) return list1;

        var head = new ListNode(0);
        var tail = head;

        while (list1 != null && list2 != null) {
            if (list1.val < list2.val) {
                tail.next = list1;
                list1 = list1.next;
            } else {
                tail.next = list2;
                list2 = list2.next;
            }

            tail = tail.next;
        }

        // more quickly in csharp:
        //tail.next = list1 ?? list2;

        if (list1 != null) tail.next = list1;

        if (list2 != null) tail.next = list2;

        return head.next;
    }
}