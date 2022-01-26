// 67. Add Binary
// https://leetcode.com/problems/add-binary/

/*
    Time: O(log n) where n is Math.Max(a.Length, b.Length)
    Space: O(log n)
*/
public class Solution {
    public String addBinary(String a, String b) {
        var sb = new StringBuilder();

        var carry = 0;

        var iA = a.length() - 1;
        var iB = b.length() - 1;

        while (iA >= 0 || iB >= 0) {
            var bA = iA < 0 ? 0 : a.charAt(iA) - '0';
            var bB = iB < 0 ? 0 : b.charAt(iB) - '0';

            sb.insert(0, (bA + bB + carry) % 2);

            carry = (bA + bB + carry) / 2;

            iA--;
            iB--;
        }

        if (carry == 0)
            return sb.toString();

        sb.insert(0, '1');
        return sb.toString();
    }
}

/*
    Time: O(log n) where n is Math.Max(a.Length, b.Length)
    Space: O(log n)
*/
public class Solution1 {
    public String addBinary(String a, String b) {

        var sb = new StringBuilder();

        var carry = 0;

        var iA = a.length() - 1;
        var iB = b.length() - 1;

        while (iA >= 0 || iB >= 0 || carry > 0) {
            var bA = iA < 0 ? 0 : a.charAt(iA) - '0';
            var bB = iB < 0 ? 0 : b.charAt(iB) - '0';

            sb.insert(0, (bA + bB + carry) % 2);

            carry = (bA + bB + carry) / 2;

            iA--;
            iB--;
        }

        return sb.toString();
    }
}