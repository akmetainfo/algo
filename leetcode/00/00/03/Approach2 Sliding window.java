// 3. Longest Substring Without Repeating Characters
// https://leetcode.com/problems/longest-substring-without-repeating-characters/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public int lengthOfLongestSubstring(String s) {
        int max = 0;
        int left = 0;
        int right = 0;
        HashSet<Character> exist = new HashSet<>();

        while (right < s.length()) {
            if (exist.add(s.charAt(right))) {
                max = Math.max(max, exist.size());
                right++;
            } else {
                exist.remove(s.charAt(left));
                left++;
            }
        }

        return max;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1 {
    public int lengthOfLongestSubstring(String s) {
        var left = 0;
        var right = 0;
        var max = 0;

        HashSet<Character> seen = new HashSet<>();

        while (right < s.length()) {
            if (seen.contains(s.charAt(right))) {
                seen.remove(s.charAt(left));
                left++;
            } else {
                seen.add(s.charAt(right));
                right++;
                max = Math.max(max, right - left);
            }
        }

        return max;
    }
}