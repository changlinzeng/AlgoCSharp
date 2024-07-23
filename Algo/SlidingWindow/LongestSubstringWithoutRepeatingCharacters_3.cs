public class LongestSubstringWithoutRepeatingCharacters_3 {
    public int LengthOfLongestSubstring(string s) {
        var maxLen = 0;
        var count = new Dictionary<char, int>();
        int i = 0, j = 0;
        while (j < s.Length)
        {
          count.TryAdd(s[j], 0);
          count[s[j]]++;

          // move left boundary
          while (count.ContainsKey(s[j]) && count[s[j]] > 1)
          {
            count[s[i]]--;
            if (count[s[i]] == 0)
            {
              count.Remove(s[i]);
            }
            i++;
          }
          maxLen = Math.Max(maxLen, j - i + 1);
          j++;
        }
        return maxLen;
    }
}