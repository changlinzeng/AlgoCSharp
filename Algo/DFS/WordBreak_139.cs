public class WordBreak_139 {
    public bool WordBreak(string s, IList<string> wordDict) {
        return Dfs(s, 0, wordDict, new int[s.Length]);
    }

    private bool Dfs(string s, int index, IList<string> wordDict, int[] memo)
    {
      if (index >= s.Length)
      {
        return true;
      }
      if (memo[index] != 0)
      {
        return memo[index] == 1;
      }
      foreach (var word in wordDict)
      {
        if (s.IndexOf(word, index) == index)
        {
          if (Dfs(s, index + word.Length, wordDict, memo)) {
            memo[index] = 1;
            break;
          }
        }
        memo[index] = -1;
      }
      return memo[index] == 1;
    }
}