public class LetterCasePermutation_784 {
    public IList<string> LetterCasePermutation(string s) {
        var result = new List<string>();
        Backtrack(s, 0, "", result);
        return result;
    }

    private void Backtrack(string s, int start, string path, IList<string> result)
    {
      if (start == s.Length)
      {
        result.Add(path);
        return;
      }
      if (s[start] >= '0' && s[start] <= '9')
      {
        Backtrack(s, start + 1, path + s[start], result);
      }
      else if (s[start] >= 'a' && s[start] <= 'z' || s[start] >= 'A' && s[start] <= 'Z')
      {
        var c = s[start];
        if (c >= 'a' && c <= 'z')
        {
          // lower case
          Backtrack(s, start + 1, path + c, result);
          // upper case
          Backtrack(s, start + 1, path + (char)(c - 32), result);
        }
        else
        {
          // upper case
          Backtrack(s, start + 1, path + c, result);
          // lower case
          Backtrack(s, start + 1, path + (char)(c + 32), result);
        }
      }
    }
}