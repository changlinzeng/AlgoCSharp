public class PermutationInString_567 {
    public bool CheckInclusion(string s1, string s2) {
        var window = s1.Length;
        var count1 = new int[26];
        foreach (var c in s1)
        {
          count1[c - 'a']++;
        }

        var count2 = new int[26];
        for (var i = 0; i < s2.Length; i++)
        {
          var ch = s2[i];
          count2[ch - 'a']++;
          if (i - window >= 0)
          {
            count2[s2[i - window] - 'a']--;
          }
          if (i < window - 1)
          {
            continue;
          }
          // check inclusive
          var match = true;
          for (var j = 0; j < count1.Length; j++)
          {
            if (count1[j] != count2[j])
            {
              match = false;
              break;
            }
          }
          if (match)
          {
            return true;
          }
        }
        return false;
    }
}