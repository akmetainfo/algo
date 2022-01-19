// 136. Single Number
// https://leetcode.com/problems/single-number/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution {
    public int singleNumber(int[] nums) {
        var sumOfSet = 0;
        var sumOfNums = 0;
        HashSet<Integer> set = new HashSet<>();

        for (var num : nums) {
            if (!set.contains(num)) {
                set.add(num);
                sumOfSet += num;
            }
            sumOfNums += num;
        }

        return 2 * sumOfSet - sumOfNums;
    }
}
