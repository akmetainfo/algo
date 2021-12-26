// 3. Longest Substring Without Repeating Characters
// https://leetcode.com/problems/longest-substring-without-repeating-characters/

/*
    Time: O(N^3)
    Space: O(N)
    
    Optimized bruteforce: max len cannot be more than distinct chars
*/
public class Solution {
    public int lengthOfLongestSubstring(String s) {
        if (s.length() == 0)
            return 0;

        var curMax = 0;

        for (var len = 1; len <= s.chars().distinct().count(); len++) {
            for (var i = 0; i < s.length() - len + 1; i++) {
                HashSet<Character> seen = new HashSet<>();
                var stringContainsRepeatingChars = false;
                for (int k = 0; k < len; k++) {
                    if (seen.contains(s.charAt(i + k))) {
                        stringContainsRepeatingChars = true;
                        break;
                    } else {
                        seen.add(s.charAt(i + k));
                    }
                }
                if (stringContainsRepeatingChars == false && len > curMax) {
                    curMax = len;
                    break;
                }
            }
        }

        return curMax;
    }
}

/*
    Time: O(N^3)
    Space: O(N)
    
    Time limit exceed
*/
public class Solution1 {
    public int lengthOfLongestSubstring(String s) {
        if (s.length() == 0)
            return 0;

        var curMax = 0;

        for (var len = 1; len <= s.length(); len++) {
            for (var i = 0; i < s.length() - len + 1; i++) {
                HashSet<Character> seen = new HashSet<>();
                var stringContainsRepeatingChars = false;
                for (int k = 0; k < len; k++) {
                    if (seen.contains(s.charAt(i + k))) {
                        stringContainsRepeatingChars = true;
                        break;
                    } else {
                        seen.add(s.charAt(i + k));
                    }
                }
                if (stringContainsRepeatingChars == false && len > curMax) {
                    curMax = len;
                    break;
                }
            }
        }

        return curMax;
    }
}