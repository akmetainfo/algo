// 997. Find the Town Judge
// https://leetcode.com/problems/find-the-town-judge/

/*
    Time: O(N + M) where N is trust.Length, M is n
    Space: O(M)
    
    If person X trusts someone then array[X] will never be equal to N-1 (which is a requirement for the person who is the judge).
*/
public class Solution {
    public int findJudge(int n, int[][] trust) {
        var degree = new int[n + 1];

        for (var edge : trust) {
            degree[edge[0]]--;
            degree[edge[1]]++;
        }

        for (var i = 1; i <= n; i++) {
            if (degree[i] == n - 1)
                return i;
        }

        return -1;
    }
}

/*
    Time: O(N)
    Space: O(N)
    
    Same as above, but project numbers from 1..n to the 0-indexed array
*/
public class Solution1 {
    public int findJudge(int n, int[][] trust) {
        var degree = new int[n];

        for (var edge : trust) {
            degree[edge[0] - 1]--;
            degree[edge[1] - 1]++;
        }

        for (var i = 1; i <= n; i++) {
            if (degree[i - 1] == n - 1)
                return i;
        }

        return -1;
    }
}
