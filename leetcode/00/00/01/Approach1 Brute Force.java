// 1. Two Sum
// https://leetcode.com/problems/two-sum/

/*
    Time: O(n^2) For each element, we try to find its complement by looping through the rest of array which takes O(n) time. Therefore, the time complexity is O(n^2).
    Space: O(1) No extra space required.
*/
public class Solution {
    public int[] twoSum(int[] nums, int target) {
        for (var i = 0; i < nums.length; i++) {
            for (var j = i + 1; j < nums.length; j++) {
                if (nums[i] + nums[j] == target)
                    return new int[]{i, j};
            }
        }

        return new int[]{-1, -1};
    }
}