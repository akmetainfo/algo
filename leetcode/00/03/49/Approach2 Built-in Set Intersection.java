// 349. Intersection of Two Arrays
// https://leetcode.com/problems/intersection-of-two-arrays/

/*
    Time: O(n + m)  where n and m are arrays' lengths.
    Space: O(n + m) in the worst case when all elements in the arrays are different. 
*/
class Solution {
    public int[] intersection(int[] nums1, int[] nums2) {
        var set1 = new HashSet<Integer>();
        for (Integer n : nums1) set1.add(n);
        var set2 = new HashSet<Integer>();
        for (Integer n : nums2) set2.add(n);

        set1.retainAll(set2);

        int[] result = new int[set1.size()];
        int idx = 0;
        for (int s : set1) result[idx++] = s;
        return result;
    }
}