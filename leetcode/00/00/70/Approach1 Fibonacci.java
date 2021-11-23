// 70. Climbing Stairs
// https://leetcode.com/problems/climbing-stairs/

/*
    Time: O()
    Space: O()
*/
public class Solution {
    public int climbStairs(int n) {
        var fib1 = 0;
        var fib2 = 1;
        var fib = 0;
        for (var i = 0; i < n; i++) {
            fib = fib1 + fib2;
            fib1 = fib2;
            fib2 = fib;
        }
        return fib;
    }
}
