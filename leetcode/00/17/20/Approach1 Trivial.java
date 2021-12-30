// 1720. Decode XORed Array
// https://leetcode.com/problems/decode-xored-array/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution {
    public int[] decode(int[] encoded, int first) {
        var result = new int[encoded.length + 1];
        result[0] = first;
        for (var i = 1; i < encoded.length + 1; i++) {
            result[i] = encoded[i - 1] ^ result[i - 1];
        }
        return result;
    }
}