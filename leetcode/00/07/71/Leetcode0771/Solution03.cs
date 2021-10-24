using System.Collections.Generic;

namespace Leetcode0771
{
    // Hashset approach
    public class Solution03
    {
        /*
            Time: O(N+M) where n is the length of jewels string and m is the length of stones string
            Space: O(N)
        */
        public int NumJewelsInStones(string jewels, string stones)
        {
            var jewelsSet = new HashSet<char>();

            foreach (var jewel in jewels)
                jewelsSet.Add(jewel);

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