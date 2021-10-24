namespace Leetcode0771
{
    // Naiv approach
    public class Solution01
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
                foreach (var jewel in jewels)
                {
                    if (stone == jewel)
                        result++;
                }
            }

            return result;
        }
    }
}