// 53. Maximum Subarray
// https://leetcode.com/problems/maximum-subarray/

/*
    Time: O(N^2)
    Space: O(N)
    
    Time Limit Exceeded
*/
public class Solution {
    public int maxSubArray(int[] nums) {
        var pref = new int[nums.length + 1];
        for (var i = 0; i < nums.length; i++)
            pref[i + 1] = pref[i] + nums[i];

        var result = Integer.MIN_VALUE;
        for (var i = 0; i < nums.length; i++) {
            for (var j = i; j < nums.length; j++) {
                var sum = pref[j + 1] - pref[i];
                result = Math.max(result, sum);
            }
        }
        return result;
    }
}