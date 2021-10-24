namespace Leetcode0771
{
    // Naiv approach
    public class Solution02
    {
        /*
            Time: O(N*M) where n is the length of jewels string and m is the length of stones string
            Space: O(1)
        */
        public int NumJewelsInStones(string jewels, string stones)
        {
            var result = 0;

            foreach (var stone in stones)
            {
                if (jewels.Contains(stone))
                    result++;
            }

            return result;
        }
    }
}