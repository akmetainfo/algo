// 1480. Running Sum of 1d Array
// https://leetcode.com/problems/running-sum-of-1d-array/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public int[] runningSum(int[] nums) {
        for (var i = 1; i < nums.length; i++)
            nums[i] = nums[i - 1] + nums[i];
        return nums;
    }
}