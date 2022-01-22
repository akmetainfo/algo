// 561. Array Partition I
// https://leetcode.com/problems/array-partition-i/


/*
    Time: O(n)
    Space: O(1), because hist length depends from constant, not from nums.Length
*/
public class Solution {
    public int arrayPairSum(int[] nums) {
        var min = Arrays.stream(nums).min().getAsInt();
        var max = Arrays.stream(nums).max().getAsInt();

        var hist = new short[Math.abs(min) + 1 + max];

        for (var num : nums)
            hist[num - min]++;

        var result = 0;
        var firstInPair = true;
        for (int i = 0; i < hist.length; i++) {
            while (hist[i] > 0) {
                if (firstInPair)
                    result += i + min;

                firstInPair = !firstInPair;
                hist[i]--;
            }
        }
        return result;
    }
}

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution1 {
    public int arrayPairSum(int[] nums) {
        var min = Arrays.stream(nums).min().getAsInt();
        var max = Arrays.stream(nums).max().getAsInt();

        var hist = new int[Math.abs(min) + 1 + max];
        for (var num : nums)
            hist[num - min]++;

        var result = 0;
        var firstInPair = true;

        for (var i = 0; i < hist.length; i++) {
            var count = hist[i];

            if (count == 0)
                continue;

            result += firstInPair
                    ? (i + min) * ((count + 1) / 2)
                    : (i + min) * (count / 2);

            firstInPair = firstInPair == (count % 2 == 0);
        }

        return result;
    }
}
