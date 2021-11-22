// 268. Missing Number
// https://leetcode.com/problems/missing-number/

/*
    Time: O(N)
    Space: O(1)
*/
class Solution {
    public int missingNumber(int[] nums) {
        var result = 0;
        for (var num : nums)
            result ^= num;
        for (var i = 0; i <= nums.length; i++)
            result ^= i;
        return result;
    }
}