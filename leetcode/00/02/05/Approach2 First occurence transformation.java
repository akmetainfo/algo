// 205. Isomorphic Strings
// https://leetcode.com/problems/isomorphic-strings/

/*
    Time: O(n)
    Space: O(n)
*/
public class Solution
{
    // We apply string transformation to both strings:
    // if s and t are isomorphic modification's result must be the same
    // An example for string transformation:    
    // For each char in the given string, we replace it with the index of that char's first occurence.
    //
    //        abcdefg
    // egg -> 0000102 -> 122
    // add -> 1002000 -> 122
    public boolean isIsomorphic(String s, String t)
    {
        return transformString(s).equals(transformString(t));
    }
    
    private final String transformString(String s)
    {
        var indexMapping = new HashMap<Character, Integer>();
        var sb = new StringBuilder();
        
        for (int i = 0; i < s.length(); i++)
        {
            char c1 = s.charAt(i);
            
            if (!indexMapping.containsKey(c1))
            {
                indexMapping.put(c1, i);
            }
            
            sb.append(Integer.toString(indexMapping.get(c1)));
            sb.append(".");
        }
        return sb.toString();
    }
}
