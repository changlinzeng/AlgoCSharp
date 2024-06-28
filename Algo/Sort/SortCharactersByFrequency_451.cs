public class SortCharactersByFrequency_451 {
    public static string FrequencySort(string s) {
        var count = new Dictionary<char, int>();
        foreach (var ch in s)
        {
          count.Add(ch, count.GetValueOrDefault(ch, 0) + 1);
          if (count.ContainsKey(ch))
          {
            count[ch]++;
          }
          else
          {
            count.Add(ch, 1);
          }
        }
        var keys = count.Keys.ToArray();
        Array.Sort(keys, (a, b) =>
        {
          if (count[a] == count[b])
          {
            return a - b;
          }
          return count[b] - count[a];
        });

        var result = "";
        foreach (var c in keys)
        {
          result += new string(c, count[c]);
        }

        return result;
    }
}