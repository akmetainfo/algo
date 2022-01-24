// 387. First Unique Character in a String
// https://leetcode.com/problems/first-unique-character-in-a-string/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public int firstUniqChar(String s) {
        var charAndCount = new int[26];

        for (var c : s.toCharArray()) {
            charAndCount[c - 'a']++;
        }

        for (int i = 0; i < s.length(); i++) {
            if (charAndCount[s.charAt(i) - 'a'] == 1) {
                return i;
            }
        }

        return -1;
    }

    // can be optimized as new int[26]
    public int firstUniqChar(String s) {
        var charAndCount = new int[256];

        for (var c : s.toCharArray()) {
            charAndCount[c]++;
        }

        for (int i = 0; i < s.length(); i++) {
            if (charAndCount[s.charAt(i)] == 1) {
                return i;
            }
        }

        return -1;
    }
}
