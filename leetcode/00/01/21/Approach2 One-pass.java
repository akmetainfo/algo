// 121. Best Time to Buy and Sell Stock
// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public int maxProfit(int[] prices) {
        var result = 0;
        var minprice = prices[0];
        for (var i = 0; i < prices.length; i++) {
            if (prices[i] < minprice) minprice = prices[i];
            var diff = prices[i] - minprice;
            if (diff > result) result = diff;
        }
        return result;
    }
}
