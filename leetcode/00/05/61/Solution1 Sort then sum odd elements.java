// 561. Array Partition I
// https://leetcode.com/problems/array-partition-i/

/*
    Time: O(n log n) because of using sorting
    Space: O(1)
*/
/*
Proof：
If the array only has two elements, return the minimum。
Else, there are any two groups (ap, bp)，(aq, bq) that satisfies ap <= bp and aq <= bq.
Now we assume that aq < bp, apparently (ap, aq) (bp, bq) are more appropriate than (ap, bp) (aq, bq) because ap+bp > ap + aq.
So we conclude that ap <= bp <= aq <= bq, which requires that the array is in order.
At last we get the elements indexed even and calculate the summary of them.
*/
public class Solution {
    public int arrayPairSum(int[] nums) {
        Arrays.sort(nums);

        var result = 0;

        for (var i = 0; i < nums.length; i += 2)
            result += nums[i];

        return result;
    }
}