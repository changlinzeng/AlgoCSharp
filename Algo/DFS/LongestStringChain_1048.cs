class LongestStringChain_1048 {
    public static int longestStrChain(string[] words) {
        var wordLen = new Dictionary<int, IList<string>>();
        foreach (var w in words)
        {
          wordLen.TryAdd(w.Length, []);
          wordLen[w.Length].Add(w);
        }

        var memo = new Dictionary<string, int>();  // longest chain starting with word
        var maxLen = 0;
        for (var i = 0; i < words.Length; i++)
        {
          maxLen = Math.Max(maxLen, Dfs(wordLen, words[i], memo));
        }
        return maxLen + 1;
    }

    private static int Dfs(in Dictionary<int, IList<string>> words, string word, Dictionary<string, int> memo)
    {
      if (!words.ContainsKey(word.Length - 1))
      {
        return 0;
      }

      if (memo.ContainsKey(word))
      {
        return memo[word];
      }

      var maxLen = 0;
      foreach (var w in words[word.Length - 1])
      {
        // check if we can make predecessor.
        // if words[i].Length != word.Length - 1, then we can return
        if (TryMakePredecessor(word, w))
        {
          maxLen = Math.Max(maxLen, 1 + Dfs(words, w, memo));
        }
      }
      memo[word] = maxLen;
      return maxLen;
    }

    private static bool TryMakePredecessor(string word, string pred)
    {
      if (word.Length != pred.Length + 1)
      {
        return false;
      }
      int i = 0, j = 0;
      int diff = 0;
      while (i < word.Length && j < pred.Length)
      {
        if (diff > 1)
        {
          return false;
        }
        if (word[i] == pred[j])
        {
          i++;
          j++;
        }
        else
        {
          diff++;
          i++;
        }
      }
      // either the different char is in the middle or in the end
      return j == pred.Length && (i == word.Length || diff == 0 && i == word.Length - 1);
    }
}