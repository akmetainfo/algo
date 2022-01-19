// 136. Single Number
// https://leetcode.com/problems/single-number/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution {
    public int singleNumber(int[] nums) {
        int a = 0;

        for (var i : nums)
            a ^= i;

        return a;
    }
}