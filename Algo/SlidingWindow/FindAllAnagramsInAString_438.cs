public class FindAllAnagramsInAString_438 {
    public static IList<int> FindAnagrams(string s, string p) {
        var targetCount = new Dictionary<char, int>();
        foreach (var c in p)
        {
          if (!targetCount.TryAdd(c, 1))
          {
            targetCount[c]++;
          }
        }

        var result = new List<int>();
        var count = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++)
        {
          if (i < p.Length)
          {
            if (!count.TryAdd(s[i], 1))
            {
              count[s[i]]++;
            }
          }
          else
          {
            if (CompareDict(count, targetCount))
            {
              result.Add(i - p.Length);
            }
            
            if (!count.TryAdd(s[i], 1))
            {
              count[s[i]]++;
            }
            count[s[i - p.Length]]--;
          }
        }

        if (CompareDict(count, targetCount))
        {
          result.Add(s.Length - p.Length);
        }
        return result;
    }

    private static bool CompareDict(Dictionary<char, int> source, Dictionary<char, int> target)
    {
      foreach (var key in target.Keys)
      {
        if (!source.ContainsKey(key) || source[key] != target[key])
        {
          return false;
        }
      }
      return true;
    }
}