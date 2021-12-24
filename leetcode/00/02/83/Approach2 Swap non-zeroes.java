// 283. Move Zeroes
// https://leetcode.com/problems/move-zeroes/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public void moveZeroes(int[] nums)
    {
        var j = 0;
        for (var i = 0; i < nums.length; i++)
        {
            if (nums[i] != 0)
            {
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                j++;
            }
        }
    }
}