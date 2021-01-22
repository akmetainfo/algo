<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

void Main()
{
	var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

	var args = new string[]
	{
		 "-noheader",
		 $"--work={workDir}",
	};

	RunUnitTests(args);
}

// Define other methods and classes here

[Test]
[TestCase("anagram", "nagaram", true)]
[TestCase("rat", "car", false)]
public void Implement_strStr(string s, string t, bool expected)
{
	var actual = new Solution().IsAnagram(s, t);
	Assert.That(actual, Is.EqualTo(expected));
}

// https://leetcode.com/explore/item/882
#region Условие задачи
/*

Given two strings s and t , write a function to determine if t is an anagram of s.

Example 1:

Input: s = "anagram", t = "nagaram"
Output: true

Example 2:

Input: s = "rat", t = "car"
Output: false

Note:
You may assume the string contains only lowercase alphabets.

Follow up:
What if the inputs contain unicode characters? How would you adapt your solution to such case?


*/

#endregion

public class Solution
{
	public bool IsAnagram(string s, string t)
	{
		var storage = new Dictionary<char, int>();

		foreach (var element in s)
		{
			if (storage.ContainsKey(element))
			{
				storage[element] = storage[element] + 1;
			}
			else
			{
				storage[element] = 1;
			}
		}

		foreach (var element in t)
		{
			if (!storage.ContainsKey(element))
				return false;

			storage[element] = storage[element] - 1;
		}

		foreach (var element in storage)
		{
			if (element.Value != 0)
				return false;
		}

		return true;
	}
}

#region Solution described

/*

Approach #1 (Sorting) [Accepted]

Algorithm

An anagram is produced by rearranging the letters of sss into ttt. Therefore, if ttt is an anagram of sss, sorting both strings will result in two identical strings. Furthermore, if sss and ttt have different lengths, ttt must not be an anagram of sss and we can return early.

public boolean isAnagram(String s, String t) {
    if (s.length() != t.length()) {
        return false;
    }
    char[] str1 = s.toCharArray();
    char[] str2 = t.toCharArray();
    Arrays.sort(str1);
    Arrays.sort(str2);
    return Arrays.equals(str1, str2);
}

Complexity analysis

    Time complexity : O(nlog⁡n). Assume that nnn is the length of sss, sorting costs O(nlog⁡n) and comparing two strings costs O(n). Sorting time dominates and the overall time complexity is O(nlog⁡n).

    Space complexity : O(1). Space depends on the sorting implementation which, usually, costs O(1) auxiliary space if heapsort is used. Note that in Java, toCharArray() makes a copy of the string so it costs O(n) extra space, but we ignore this for complexity analysis because:
        It is a language dependent detail.
        It depends on how the function is designed. For example, the function parameter types can be changed to char[].

Approach #2 (Hash Table) [Accepted]

Algorithm

To examine if ttt is a rearrangement of sss, we can count occurrences of each letter in the two strings and compare them. Since both sss and ttt contain only letters from a−za-za−z, a simple counter table of size 26 is suffice.

Do we need two counter tables for comparison? Actually no, because we could increment the counter for each letter in sss and decrement the counter for each letter in ttt, then check if the counter reaches back to zero.

public boolean isAnagram(String s, String t) {
    if (s.length() != t.length()) {
        return false;
    }
    int[] counter = new int[26];
    for (int i = 0; i < s.length(); i++) {
        counter[s.charAt(i) - 'a']++;
        counter[t.charAt(i) - 'a']--;
    }
    for (int count : counter) {
        if (count != 0) {
            return false;
        }
    }
    return true;
}

Or we could first increment the counter for sss, then decrement the counter for ttt. If at any point the counter drops below zero, we know that ttt contains an extra letter not in sss and return false immediately.

public boolean isAnagram(String s, String t) {
    if (s.length() != t.length()) {
        return false;
    }
    int[] table = new int[26];
    for (int i = 0; i < s.length(); i++) {
        table[s.charAt(i) - 'a']++;
    }
    for (int i = 0; i < t.length(); i++) {
        table[t.charAt(i) - 'a']--;
        if (table[t.charAt(i) - 'a'] < 0) {
            return false;
        }
    }
    return true;
}

Complexity analysis

    Time complexity : O(n). Time complexity is O(n) because accessing the counter table is a constant time operation.

    Space complexity : O(1). Although we do use extra space, the space complexity is O(1) because the table's size stays constant no matter how large nnn is.

Follow up

What if the inputs contain unicode characters? How would you adapt your solution to such case?

Answer

Use a hash table instead of a fixed size counter. Imagine allocating a large size array to fit the entire range of unicode characters, which could go up to more than 1 million. A hash table is a more generic solution and could adapt to any range of characters.

*/

#endregion

#region Хорошие алгоритмы-победители

// Ну мой вообще где-то посередине находится

// Решение хуже моего, но тривиальный алгоритм
public bool IsAnagram1(string s, string t)
{
	if (s.Length != t.Length)
		return false;

	char[] first = s.ToCharArray();
	char[] second = t.ToCharArray();
	Array.Sort(first);
	Array.Sort(second);

	return first.SequenceEqual(second);
}

// Решение хуже моего, но тривиальный алгоритм
public bool IsAnagram2(string s, string t)
{


	if (s.Length != t.Length)
		return false;

	bool ans = true;

	var sArray = s.ToCharArray();
	var tArray = t.ToCharArray();

	Array.Sort(sArray);
	Array.Sort(tArray);

	for (int i = 0; i < s.Length; i++)
	{
		var sChar = sArray[i];
		var tChar = tArray[i];

		if (tChar != sChar)
			return false;
	}


	return ans;

}

// Решение хуже моего, но по идее должно быть точно таким же
public bool IsAnagram3(string s, string t)
{
	Dictionary<char, int> dict = new Dictionary<char, int>();
	foreach (var c in s)
	{
		if (dict.ContainsKey(c))
			dict[c]++;
		else
			dict[c] = 1;
	}
	foreach (var c in t)
	{
		if (dict.ContainsKey(c))
			dict[c]--;
		else
			return false;
	}
	foreach (var pair in dict)
	{
		if (pair.Value != 0)
			return false;
	}

	return true;
}

// Решение из моей группы
public bool IsAnagram4(string s, string t)
{
	if (s.Length != t.Length)
	{
		return false;
	}

	Dictionary<char, int> dictionary = new Dictionary<char, int>();
	char[] sArray = s.ToCharArray();
	char[] tArray = t.ToCharArray();
	char sTemp;
	char tTemp;
	for (int i = 0; i < sArray.Length; i++)
	{
		sTemp = sArray[i];
		tTemp = tArray[i];
		if (!dictionary.ContainsKey(sTemp))
		{
			dictionary.Add(sTemp, 0);
		}
		if (!dictionary.ContainsKey(tTemp))
		{
			dictionary.Add(tTemp, 0);
		}
		dictionary[sTemp]++;
		dictionary[tTemp]--;
	}

	foreach (var pair in dictionary)
	{
		if (pair.Value != 0)
		{
			return false;
		}
	}

	return true;
}

// Решение чуть лучше
public bool IsAnagram5(string s, string t)
{
	int[] letterArray = new int[26];
	foreach (var ch in s.ToCharArray())
	{
		letterArray[ch - 'a']++;
	}
	foreach (var ch in t.ToCharArray())
	{
		letterArray[ch - 'a']--;
	}
	foreach (var counter in letterArray)
	{
		if (counter != 0)
		{
			return false;
		}
	}
	return true;
}

// ещё лучше
public bool IsAnagram6(string s, string t)
{
	if (s.Length != t.Length)
	{
		return false;
	}

	int[] charCount = new int[26];

	for (int i = 0; i < s.Length; i++)
	{
		charCount[s[i] - 'a']++;
		charCount[t[i] - 'a']--;
	}

	foreach (int num in charCount)
	{
		if (num != 0)
		{
			return false;
		}

	}

	return true;
}

// Ещё
public bool IsAnagram7(string s, string t)
{
	int[] hash = new int[26];
	for (int i = 0; i < s.Length; i++)
	{
		hash[s[i] - 'a']++;
	}
	for (int i = 0; i < t.Length; i++)
	{
		hash[t[i] - 'a']--;
	}
	return hash.Count(x => x != 0) > 0 ? false : true;
}

// Ещё
public bool IsAnagram8(string s, string t)
{

	if (s.Length != t.Length)
	{
		return false;
	}

	var countAry = new int[26];

	for (int i = 0; i < s.Length; i++)
	{
		countAry[s[i] - 'a'] += 1;
		countAry[t[i] - 'a'] -= 1;
	}


	for (int i = 0; i < countAry.Length; i++)
	{
		if (countAry[i] != 0)
			return false;
	}

	return true;

}

//
public bool IsAnagram9(string s, string t)
{
	if (s.Length != t.Length)
		return false;

	var counters = new int[26];

	foreach (var letter in s)
	{
		counters[letter - 'a']++;
	}

	foreach (var letter in t)
	{
		counters[letter - 'a']--;
		if (counters[letter - 'a'] < 0)
			return false;
	}

	return true;
}

// победитель
public bool IsAnagram10(string s, string t)
{
	if (s.Length != t.Length)
		return false;

	var counters = new int[26];

	foreach (var letter in s)
	{
		counters[letter - 'a']++;
	}

	foreach (var letter in t)
	{
		counters[letter - 'a']--;
		if (counters[letter - 'a'] < 0)
			return false;
	}

	return true;
}

#endregion

#region unit tests runner

void RunUnitTests(string[] args, Assembly assembly = null)
{
	Console.SetOut(new NoDisposeTextWriter(Console.Out));
	Console.SetError(new NoDisposeTextWriter(Console.Error));
	new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
	private readonly TextWriter writer;
	public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

	public override Encoding Encoding => writer.Encoding;
	public override IFormatProvider FormatProvider => writer.FormatProvider;
	public override void Write(char value) => writer.Write(value);
	public override void Flush() => writer.Flush();
	// forward all other overrides as necessary

	protected override void Dispose(bool disposing)
	{
		// no nothing
	}
}

#endregion