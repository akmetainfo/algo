// 189. Rotate Array
// https://leetcode.com/problems/rotate-array/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public void rotate(int[] nums, int k) {
        if (k == 0 || nums.length < 2)
            return;

        var tmp = new int[nums.length];

        for (int i = 0; i < nums.length; i++)
            tmp[(i + k) % nums.length] = nums[i];

        for (int i = 0; i < nums.length; i++)
            nums[i] = tmp[i];
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1 {
    public void rotate(int[] nums, int k) {
        k %= nums.length;

        var result = nums.clone();

        for (int i = 0; i < nums.length; i++) {
            //var newPos = i - k >= 0 ? i - k : i - k + result.length;
            var newPos = (i - k + result.length) % result.length;
            nums[i] = result[newPos];
        }
    }
}