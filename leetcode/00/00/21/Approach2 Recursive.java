// 21. Merge Two Sorted Lists
// https://leetcode.com/problems/merge-two-sorted-lists/

/*
    Time: O(N)
    Space: O(N) for storing call stack
*/
public class Solution {
    public ListNode mergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) return list2;

        if (list2 == null) return list1;

        if (list2.val > list1.val) {
            list1.next = mergeTwoLists(list1.next, list2);
            return list1;
        }

        list2.next = mergeTwoLists(list1, list2.next);
        return list2;
    }
}