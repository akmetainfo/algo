// 438. Find All Anagrams in a String
// https://leetcode.com/problems/find-all-anagrams-in-a-string/

/*
    Time: O(N + M) where N is the length of string s, M is the length of string p
    Space: O(N) for storing the list, because in worst case s = "xxxxx", p = "x" and result = 0,1,2,3,4 (where 'x' means 'any char')
*/
public class Solution {
    public List<Integer> findAnagrams(String s, String p) {
        List<Integer> result = new ArrayList<>();

        if (s.length() < p.length())
            return result;

        var sFreq = new int[256];
        var pFreq = new int[256];

        for (int i = 0; i < p.length(); i++) pFreq[p.charAt(i)]++;

        for (int i = 0; i < s.length(); i++) {
            sFreq[s.charAt(i)]++;

            if (i >= p.length())
                sFreq[s.charAt(i - p.length())]--;

            if (Arrays.equals(sFreq, pFreq))
                result.add(i - p.length() + 1);
        }

        return result;
    }
}