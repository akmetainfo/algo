// 1512. Number of Good Pairs
// https://leetcode.com/problems/number-of-good-pairs/

/*
    Time: O(N^2)
    Space: O(1)
*/
public class Solution {
    public int numIdenticalPairs(int[] nums) {
        var result = 0;

        for (int i = 0; i < nums.length; i++) {
            for (int j = i + 1; j < nums.length; j++) {
                if (nums[i] == nums[j])
                    result++;
            }
        }

        return result;
    }
}