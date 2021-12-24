// 1512. Number of Good Pairs
// https://leetcode.com/problems/number-of-good-pairs/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public int numIdenticalPairs(int[] nums) {
        var result = 0;

        var dict = new HashMap<Integer, Integer>();

        for (int i = 0; i < nums.length; i++) {
            if (!dict.containsKey(nums[i])) {
                dict.put(nums[i], 1);
            } else {
                result += dict.get(nums[i]);
                dict.put(nums[i], dict.get(nums[i]) + 1);
            }
        }

        return result;
    }
}