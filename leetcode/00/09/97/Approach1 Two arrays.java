// 997. Find the Town Judge
// https://leetcode.com/problems/find-the-town-judge/

/*
    Time: O(N + M) where N is trust.Length, M is n
    Space: O(M)
*/
public class Solution {
    public int findJudge(int n, int[][] trust) {
        var outDegree = new int[n + 1];
        var inDegree = new int[n + 1];

        for (int[] edge : trust) {
            outDegree[edge[0]]++;
            inDegree[edge[1]]++;
        }

        for (var i = 1; i <= n; i++) {
            if (outDegree[i] == 0 && inDegree[i] == n - 1)
                return i;
        }

        return -1;
    }
}

/*
    Time: O(N + M) where N is trust.Length, M is n
    Space: O(M)
*/
public class Solution1 {
    public int findJudge(int n, int[][] trust) {
        var outDegree = new int[n];
        var inDegree = new int[n];

        for (var edge : trust) {
            outDegree[edge[0] - 1]++;
            inDegree[edge[1] - 1]++;
        }

        for (var i = 0; i < n; i++) {
            if (outDegree[i] == 0 && inDegree[i] == n - 1)
                return i + 1;
        }

        return -1;
    }
}
