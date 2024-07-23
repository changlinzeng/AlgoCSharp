public class MaximumNumberOfOccurrencesOfASubstring_1297 {
    public static int MaxFreq(string s, int maxLetters, int minSize, int maxSize) {
        var count = new Dictionary<char, int>();
        var substr = new Dictionary<string, int>();
        int i = 0, j = 0;
        while (j < s.Length)
        {
          count.TryAdd(s[j], 0);
          count[s[j]]++;

          if (count.Count <= maxLetters && j - i + 1 <= maxSize && j - i + 1 >= minSize)
          {
            var str = s.Substring(i, j - i + 1);
            substr.TryAdd(str, 0);
            substr[str]++;
          }

          while (i < j && j - i + 1 > minSize)
          {
            count[s[i]]--;
            if (count[s[i]] == 0)
            {
              count.Remove(s[i]);
            }
            i++;
            if (count.Count <= maxLetters)
            {
              substr.TryAdd(s.Substring(i, j - i + 1), 0);
              substr[s.Substring(i, j - i + 1)]++;
            }
          }
          j++;
        }
        return substr.Count == 0 ? 0 : substr.Values.Max();
    }
}