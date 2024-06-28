public class RemoveDuplicateLetters_316 {
    public string RemoveDuplicateLetters(string s) {
        var count = new int[26];
        foreach (var c in s)
        {
          count[c - 'a']++;
        }

        var maxStack = new Stack<char>();
        foreach (var ch in s)
        {
          if (maxStack.Contains(ch))
          {
            count[ch - 'a']--;
            continue;
          }
          while (maxStack.Count > 0 && maxStack.Peek() >= ch && count[maxStack.Peek() - 'a'] > 1)
          {
            count[maxStack.Pop() - 'a']--;
          }
          maxStack.Push(ch);
        }

        return string.Join("", maxStack.Reverse());
    }
}