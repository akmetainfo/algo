// 567. Permutation in String
// https://leetcode.com/problems/permutation-in-string/

/*
    Time: O(N log N + M log M) where N = s1.Length, M = s2.Length
    Space: O(N)
    
    Time Limit Exceeded
*/
public class Solution {
    public boolean checkInclusion(String s1, String s2) {
        s1 = sort(s1);
        for (int i = 0; i <= s2.length() - s1.length(); i++) {
            if (s1.equals(sort(s2.substring(i, i + s1.length()))))
                return true;
        }
        return false;
    }

    public String sort(String s) {
        char[] t = s.toCharArray();
        Arrays.sort(t);
        return new String(t);
    }
}