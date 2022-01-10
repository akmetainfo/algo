// 53. Maximum Subarray
// https://leetcode.com/problems/maximum-subarray/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public int maxSubArray(int[] nums) {
        var sum = 0;
        var result = nums[0]; // or result = int.MinValue;
        for (var i = 0; i < nums.length; i++) {
            sum += nums[i];
            if (sum > result) result = sum;
            if (sum < 0) sum = 0;
        }
        return result;
    }
}