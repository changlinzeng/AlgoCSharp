using System.Collections.Immutable;

public class PalindromePartitioning_131 {
    public static IList<IList<string>> Partition(string s) {
        var all = new List<IList<string>>();
        Backtrack(s, [], all);
        return all;
    }

    private static void Backtrack(string s, IList<string> partition, IList<IList<string>> all)
    {
      if (string.IsNullOrEmpty(s))
      {
        all.Add([.. partition]);
        return;
      }
      for (var i = 1; i <= s.Length; i++)
      {
        if (IsPalindrome(s[..i]))
        {
          partition.Add(s[..i]);
          Backtrack(s[i..], partition, all);
          partition.RemoveAt(partition.Count - 1);
        }
      }
    }

    private static bool IsPalindrome(string str)
    {
      for (int i = 0, j = str.Length - 1; i < j; i++, j--)
      {
        if (str[i] != str[j])
        {
          return false;
        }
      }
      return true;
    }
}