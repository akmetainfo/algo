// 387. First Unique Character in a String
// https://leetcode.com/problems/first-unique-character-in-a-string/

/*
    Time: O(n^2)
    Space: O(1)

    // time limit
*/
public class Solution {
    public int firstUniqChar(String s) {
        for (var i = 0; i < s.length(); i++) {
            var found = false;
            for (var j = 0; j < s.length(); j++) {
                if (s.charAt(j) == s.charAt(i) && i != j)
                    found = true;
            }
            if (!found)
                return i;
        }
        return -1;
    }
}
