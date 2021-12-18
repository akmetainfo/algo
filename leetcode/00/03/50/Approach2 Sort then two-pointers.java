// 350. Intersection of Two Arrays II
// https://leetcode.com/problems/intersection-of-two-arrays-ii/

/*
    Time: O(N log N + M log M) where N is nums1.Length and M is nums2.Length
    Space: O(1)
*/
public class Solution {
    public int[] intersect(int[] nums1, int[] nums2) {
        if (nums1.length > nums2.length)
            return intersect(nums2, nums1);
        Arrays.sort(nums1);
        Arrays.sort(nums2);
        var result = new ArrayList<Integer>();
        var i1 = 0;
        var i2 = 0;
        while (i1 < nums1.length && i2 < nums2.length) {
            if (nums1[i1] == nums2[i2]) {
                result.add(nums1[i1]);
                i1++;
                i2++;
            } else if (nums1[i1] < nums2[i2])
                i1++;
            else
                i2++;
        }

        return result.stream().mapToInt(Integer::intValue).toArray();
    }
}