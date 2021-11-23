// 1470. Shuffle the Array
// https://leetcode.com/problems/shuffle-the-array/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public int[] shuffle(int[] nums, int n) {
        var result = new int[nums.length];
        for (int i = 0; i < n; i++) {
            result[2 * i] = nums[i];
            result[2 * i + 1] = nums[n + i];
        }
        return result;
    }
}
