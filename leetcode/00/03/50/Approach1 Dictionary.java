// 350. Intersection of Two Arrays II
// https://leetcode.com/problems/intersection-of-two-arrays-ii/

/*
    Time: O(N+M) where N is nums1.Length and M is nums2.Length
    Space: O(N)
*/
public class Solution {
    public int[] intersect(int[] nums1, int[] nums2) {
        if (nums1.length > nums2.length)
            return intersect(nums2, nums1);

        var dict1 = new HashMap<Integer, Integer>();
        for (var num : nums1) {
            dict1.put(num, dict1.getOrDefault(num, 0) + 1);
        }

        var result = new ArrayList<Integer>();

        for (var num : nums2) {
            if (dict1.getOrDefault(num, 0) != 0) {
                result.add(num);
                dict1.put(num, dict1.getOrDefault(num, 1) - 1);
            }
        }

        return result.stream().mapToInt(x -> x).toArray();
    }
}