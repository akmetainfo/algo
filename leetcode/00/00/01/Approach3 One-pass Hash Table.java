// 1. Two Sum
// https://leetcode.com/problems/two-sum/

/*
    Time: O(n) We traverse the list containing nnn elements only once. Each look up in the table costs only O(1) time.
    Space: O(n) The extra space required depends on the number of items stored in the hash table, which stores at most n elements.
*/
public class Solution {
    public int[] twoSum(int[] nums, int target) {
        int[] result = new int[2];
        Map<Integer, Integer> map = new HashMap<>();

        for (int i = 0; i < nums.length; i++) {
            if (map.containsKey(nums[i])) {
                result[0] = i;
                result[1] = map.get(nums[i]);
            } else {
                map.put(target - nums[i], i);
            }
        }

        return result;
    }
}