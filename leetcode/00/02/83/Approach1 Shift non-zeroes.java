// 283. Move Zeroes
// https://leetcode.com/problems/move-zeroes/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public void moveZeroes(int[] nums) {
        var j = 0;

        for (var i = 0; i < nums.length; i++) {
            if (nums[i] != 0) {
                nums[j] = nums[i];
                j++;
            }
        }

        for (var i = j; i < nums.length; i++)
            nums[i] = 0;
    }
}