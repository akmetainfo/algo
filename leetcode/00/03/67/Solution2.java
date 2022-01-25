// 367. Valid Perfect Square
// https://leetcode.com/problems/valid-perfect-square/

/*
    The sum of the first n odd integers is n^2

    1:  1
    4:  1 + 3
    9:  1 + 3 + 5
    16: 1 + 3 + 5 + 7
    25: 1 + 3 + 5 + 7 + 9
    
    Time: O(sqrt(num))
          num = 1 + 2 + 3 + ... + n = n*(n+1)/2 => n = O(sqrt(num))
    Space: O(1)
    
    Note: O(logn) is more efficient than O(sqrt(n)), so binary search is more efficient!
*/
// https://leetcode.com/problems/valid-perfect-square/discuss/623417/C-solutions-(Binary-Search-and-Math)
public class Solution {
    public boolean isPerfectSquare(int num) {
        {
            int i = 1;

            while (num > 0) {
                num = num - i;
                i = i + 2;
            }

            return num == 0;
        }
    }
}