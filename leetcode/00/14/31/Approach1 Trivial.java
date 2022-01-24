// 1431. Kids With the Greatest Number of Candies
// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public List<Boolean> kidsWithCandies(int[] candies, int extraCandies) {
        var max = Arrays.stream(candies).max().getAsInt();

        return Arrays
                .stream(candies)
                .mapToObj(c -> (c + extraCandies >= max))
                .collect(Collectors.toList());
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1 {
    public List<Boolean> kidsWithCandies(int[] candies, int extraCandies) {
        var max = Arrays.stream(candies).max().getAsInt();

        var result = new ArrayList<Boolean>(candies.length);

        for (int i = 0; i < candies.length; i++)
            result.add(candies[i] + extraCandies >= max);

        return result;
    }
}