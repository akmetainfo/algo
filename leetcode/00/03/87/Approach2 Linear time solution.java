// 387. First Unique Character in a String
// https://leetcode.com/problems/first-unique-character-in-a-string/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public int firstUniqChar(String s) {
        HashMap<Character, Integer> dict = new HashMap<>();

        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            dict.put(c, dict.getOrDefault(c, 0) + 1);
        }

        for (int i = 0; i < s.length(); i++) {
            if (dict.get(s.charAt(i)) == 1)
                return i;
        }

        return -1;
    }
}