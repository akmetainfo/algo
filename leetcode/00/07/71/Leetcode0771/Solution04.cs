using System.Collections.Generic;

namespace Leetcode0771
{
    // Hashset approach
    public class Solution04
    {
        /*
            Time: O(N+M) where n is the length of jewels string and m is the length of stones string
            Space: O(N)
        */
        public int NumJewelsInStones(string jewels, string stones)
        {
            var jewelsSet = new HashSet<char>(jewels);

            var result = 0;

            foreach (var stone in stones)
            {
                if (jewelsSet.Contains(stone))
                    result++;
            }

            return result;
        }
    }
}