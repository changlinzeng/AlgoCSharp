public class PalindromicSubstrings_647 {
    /// <summary>
    /// Use DP to record the palindrome ends at index i.
    /// So we know all the starting indices of palindromes ends at i and then
    /// we try to see if we could make palindrome by adding i + 1.
    /// There are two ways we can make palindrome by appending i + 1.
    /// One is to add one char before and after string [start, i] and the other is to append i + 1 only
    /// </summary>
    public static int CountSubstrings(string s) {
        var dp = new Dictionary<int, ISet<int>>();  // {i -> starting indices of palindrome}
        dp.Add(0, new HashSet<int>(){0});
        var count = 1;
        for (var i = 1; i < s.Length; i++)
        {
          dp.Add(i, new HashSet<int>(){i});
          // check if we can make palindrome
          foreach (var start in dp[i - 1])
          {
            if (IsPalindrome(s, start, i))
            {
              dp[i].Add(start);
            }
            if (start > 0 && s[start - 1] == s[i])
            {
              dp[i].Add(start - 1);
            }
          }
          count += dp[i].Count;
        }
        return count;
    }

    private static bool IsPalindrome(string s, int start, int end)
    {
      for (int i = start, j = end; i < j; i++, j--)
      {
        if (s[i] != s[j])
        {
          return false;
        }
      }
      return true;
    }
}