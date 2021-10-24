using System.Linq;

namespace Leetcode0771
{
    // Linq approach
    public class Solution05
    {
        /*
            Time: O(N*M) where n is the length of jewels string and m is the length of stones string
            Space: O(1)
        */
        public int NumJewelsInStones(string jewels, string stones)
        {
            return stones.Count(stone => jewels.Contains(stone));
        }
    }
}