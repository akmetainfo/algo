// 771. Jewels and Stones
// https://leetcode.com/problems/jewels-and-stones/

/*
    Time: O(N+M) where N is the length of J (Jewels string) and M is the length of S (Stones string)
    Space: O(N)
*/
class Solution {
    public int numJewelsInStones(String jewels, String stones) {
        var data = new HashSet<Character>();

        for (var jewel : jewels.toCharArray()) data.add(jewel);

        var result = 0;

        for (var stone : stones.toCharArray()) {
            if (data.contains(stone))
                result++;
        }

        return result;
    }
}

class Solution0 {
    public int numJewelsInStones(String jewels, String stones) {
        var data = new HashSet<Character>();

        for (int i = 0; i < jewels.length(); i++) data.add(jewels.charAt(i));

        var result = 0;

        for (int i = 0; i < stones.length(); i++) {
            if (data.contains(stones.charAt(i)))
                result++;
        }

        return result;
    }
}
