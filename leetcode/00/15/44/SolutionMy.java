// 1544. Make The String Great
// https://leetcode.com/problems/make-the-string-great/

/*
    Time: O(N) because we travers all chars in string
    Space: O(N) for storing characters on stack
*/
public class Solution {
    public String makeGood(String s) {
        Stack<Character> stack = new Stack<>();
        for (var i = s.length() - 1; i >= 0; i--) {
            var peek = stack.isEmpty() ? '#' : stack.peek();
            if (isSameCharButDifferentCase(s.charAt(i), peek)) {
                stack.pop();
            } else {
                stack.push(s.charAt(i));
            }
        }
        StringBuilder sb = new StringBuilder(stack.size());
        while (!stack.isEmpty()) sb.append(stack.pop());
        return sb.toString();
    }

    private boolean isSameCharButDifferentCase(char a, char b) {
        if (Character.toLowerCase(a) != Character.toLowerCase(b))
            return false;

        return !(a == b);
    }
}