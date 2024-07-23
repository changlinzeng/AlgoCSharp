public class DecodeString_394 {
    public static string DecodeString(string s) {
        Dfs(s, 0, out string decoded, out int end);
        return decoded;
    }

    private static void Dfs(string s, int start, out string decoded, out int end)
    {
      var num = 0;
      decoded = "";
      end = start;
      int i = start;
      while (i < s.Length)
      {
        var c = s[i];
        if (c >= '0' && c <= '9')
        {
          num = num * 10 + (c - '0');
        }
        else if (c >= 'a' && c <= 'z')
        {
          decoded += c;
        }
        else if (c == '[')
        {
          Dfs(s, i + 1, out string res, out int to);
          decoded += string.Concat(Enumerable.Repeat(res, num));
          i = to;
          num = 0;
        }
        else if (c == ']')
        {
          end = i;
          break;
        }
        i++;
      }
    }
}