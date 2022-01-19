// 136. Single Number
// https://leetcode.com/problems/single-number/

// Это решение не работает - и уже закрыли в платный доступ задачу, допилить самому

/*
    Time: O(n^2) We iterate through nums, taking O(n) time. We search the whole list to find whether there is duplicate number, taking O(n) time. Because search is in the for loop, so we have to multiply both time complexities which is O(n^2).
    Space: O(n) We need a list of size n to contain elements in nums.
*/
public class Solution {
    public int singleNumber(int[] nums) {
        List<Integer> no_duplicate_list = new ArrayList<Integer>();

        for (int i = 0; i < nums.length; i++) {
            if (!no_duplicate_list.contains(nums[i]))
                no_duplicate_list.add(nums[i]);
            else
                no_duplicate_list.remove(nums[i]);
        }

        return no_duplicate_list.get(0);
    }
}
