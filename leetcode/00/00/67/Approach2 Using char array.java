// 67. Add Binary
// https://leetcode.com/problems/add-binary/

/*
    Time: O(log n) where n is Math.Max(a.Length, b.Length)
    Space: O(log n)
*/
public class Solution {
    public String addBinary(String a, String b) {
        var result = new char[Math.max(a.length(), b.length()) + 1];

        var carry = 0;

        var iA = a.length() - 1;
        var iB = b.length() - 1;
        var position = result.length - 1;

        while (iA >= 0 || iB >= 0) {
            var bA = iA < 0 ? 0 : a.charAt(iA) - '0';
            var bB = iB < 0 ? 0 : b.charAt(iB) - '0';

            result[position] = (bA + bB + carry) % 2 == 1 ? '1' : '0';

            carry = (bA + bB + carry) / 2;

            iA--;
            iB--;
            position--;
        }

        if (carry == 0)
            return new String(result, 1, result.length - 1);

        result[0] = '1';
        return new String(result);
    }
}