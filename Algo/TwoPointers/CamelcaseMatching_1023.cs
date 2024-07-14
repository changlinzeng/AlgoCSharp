public class CamelcaseMatching_1023 {
    public static IList<bool> CamelMatch(string[] queries, string pattern) {
        IList<bool> result = [];
        foreach (var q in queries)
        {
          result.Add(TryMatch(q, pattern));
        }
        return result;
    }

    private static bool TryMatch(string q, string p)
    {
      int i = 0, j = 0;
      while (i < q.Length && j < p.Length)
      {
        if (p[j] >= 'A' && p[j] <= 'Z')
        {
          // find next upper
          while (i < q.Length && q[i] >= 'a' && q[i] <= 'z')
          {
            i++;
          }
          if (i >= q.Length)
          {
            break;
          }
          // upper not equal
          if (q[i] != p[j])
          {
            return false;
          }
          i++;
          j++;
        }
        else
        {
          if (q[i] >= 'A' && q[i] <= 'Z')
          {
            return false;
          }
          if (q[i] == p[j])
          {
            j++;
          }
          i++;
        }
      }
      if (j == p.Length)
      {
        while (i < q.Length && q[i] >= 'a' && q[i] <= 'z')
        {
          i++;
        }
      }
      return i == q.Length && j == p.Length;
    }
}