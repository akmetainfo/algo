// 1732. Find the Highest Altitude
// https://leetcode.com/problems/find-the-highest-altitude/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public int largestAltitude(int[] gain) {
        var result = 0;
        var currentHeight = 0;
        for (var g : gain) {
            currentHeight += g;
            result = Math.max(result, currentHeight);
        }
        return result;
    }
}