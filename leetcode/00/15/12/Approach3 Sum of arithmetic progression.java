// 1512. Number of Good Pairs
// https://leetcode.com/problems/number-of-good-pairs/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public int numIdenticalPairs(int[] nums) {
        return IntStream.of(nums).boxed()
                .collect(Collectors.groupingBy(num -> num, Collectors.summingInt(num -> 1)))
                .values()
                .stream()
                .filter(n -> n > 1)
                .mapToInt(n -> n * (n - 1) / 2)
                .sum();
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1 {
    public int numIdenticalPairs(int[] nums) {
        var dict = new HashMap<Integer, Integer>();
        for (var num : nums) {
            dict.put(num, dict.getOrDefault(num, 0) + 1);
        }
        var result = 0;
        for (var n : dict.values())
            result += (n - 1) * n / 2;
        return result;
    }
}