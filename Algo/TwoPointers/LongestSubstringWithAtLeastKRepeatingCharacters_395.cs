public class LongestSubstringwWithAtLeastKRepeatingCharacters_395 {
    /// <summary>
    /// Characters whose count < k should be excluded from the string
    /// So we can find the chars whose count < k and then split the string recursively
    /// </summary>
    public int LongestSubstring(string s, int k) {
        var count = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++)
        {
          if (!count.TryAdd(s[i], 1))
          {
            count[s[i]]++;
          }
        }

        // find the chars whose count < k
        var delimeter = count.Where(kv => kv.Value < k);
        if (!delimeter.Any())
        {
          return s.Length;
        }

        // split string
        var maxLen = 0;
        foreach (var sub in s.Split(delimeter.First().Key))
        {
          maxLen = Math.Max(maxLen, LongestSubstring(sub, k));
        }
        return maxLen;
    }
}