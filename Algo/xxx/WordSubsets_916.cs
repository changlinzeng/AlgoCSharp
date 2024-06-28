public class WordSubsets_916 {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        var count = new int[26];
        foreach (var w in words2)
        {
          var charCount = new int[26];
          foreach (var c in w)
          {
            charCount[c - 'a']++;
          }
          // maintain the max count of chars for all word in words2
          // word in word1 is universal only if char count greater than the max chars
          for (var i = 0; i < count.Length; i++)
          {
            count[i] = Math.Max(count[i], charCount[i]);
          }
        }

        var universal = new List<string>();
        foreach (var w in words1)
        {
          var charCount = new int[26];
          foreach (var c in w)
          {
            charCount[c - 'a']++;
          }

          var isSubset = true;
          for (var i = 0; i < charCount.Length; i++)
          {
            if (charCount[i] < count[i])
            {
              isSubset = false;
              break;
            }
          }
          if (isSubset)
          {
            universal.Add(w);
          }
        }

        return universal;
    }
}