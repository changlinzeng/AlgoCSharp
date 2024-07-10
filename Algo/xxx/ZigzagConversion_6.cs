public class ZigzagConversion_6 {
    public string Convert(string s, int numRows) {
        var direction = 1;
        var row = 0;
        var rows = new SortedDictionary<int, string>();
        for (var i = 0; i < s.Length; i++)
        {
          rows.TryAdd(row, "");
          rows[row] = rows[row] + s[i];
          row += direction;
          if (row == numRows - 1 || row == 0)
          {
            direction = -1 * direction;
          }
        }

        return string.Join("", rows.Select(kv => kv.Value));
    }
}