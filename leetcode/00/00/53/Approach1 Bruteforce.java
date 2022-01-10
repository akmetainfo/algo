// 53. Maximum Subarray
// https://leetcode.com/problems/maximum-subarray/

/*
    Time: O(N^3)
    Space: O(1)
    
    Time Limit Exceeded
*/
public class Solution {
    public int maxSubArray(int[] nums) {
        var result = Integer.MIN_VALUE;

        for (var i = 0; i < nums.length; i++) {
            for (var j = 0; j < nums.length; j++) {
                var sum = nums[i];
                for (var k = i + 1; k <= j; k++) sum += nums[k];
                result = Math.max(result, sum);
            }
        }

        return result;
    }
}