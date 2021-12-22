// 136. Single Number
// https://leetcode.com/problems/single-number/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution {
    public int singleNumber(int[] nums) {
        var hash_table = new HashMap<Integer, Integer>();

        for (int i = 0; i < nums.length; i++) {
            if (hash_table.containsKey(nums[i]))
                hash_table.put(nums[i], hash_table.get(nums[i]) + 1);
            else
                hash_table.put(nums[i], 1);
        }

        for (int i = 0; i < nums.length; i++) {
            if (hash_table.get(nums[i]) == 1)
                return nums[i];
        }

        return -1; // invalid data
    }
}
