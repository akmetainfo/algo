// 189. Rotate Array
// https://leetcode.com/problems/rotate-array/

/*
    Time: O(N) where N is nums.Length * (k % nums.Length)
    Space: O(1)
    
    Time Limit Exceeded
*/
public class Solution {
    public void rotate(int[] nums, int k) {
        k %= nums.length;

        if (k == 0 || nums.length < 2)
            return;

        for (var i = 0; i < k; i++) {
            var temp = nums[nums.length - 1];

            for (var j = nums.length - 1; j > 0; j--)
                nums[j] = nums[j - 1];

            nums[0] = temp;
        }
    }
}