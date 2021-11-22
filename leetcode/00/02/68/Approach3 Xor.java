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