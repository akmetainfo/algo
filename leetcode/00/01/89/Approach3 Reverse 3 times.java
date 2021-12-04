// 189. Rotate Array
// https://leetcode.com/problems/rotate-array/

/*
    Time: O(N) Each number will be moved twice, O(2n) = O(n).
    Space: O(1)
*/
public class Solution {
    public void rotate(int[] nums, int k) {
        k %= nums.length;

        if (k == 0 || nums.length < 2)
            return;

        reverse(nums, 0, nums.length - 1);
        reverse(nums, 0, k - 1);
        reverse(nums, k, nums.length - 1);
    }

    public void reverse(int[] nums, int left, int right) {
        while (left < right) {
            var temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;

            left++;
            right--;
        }
    }
}
