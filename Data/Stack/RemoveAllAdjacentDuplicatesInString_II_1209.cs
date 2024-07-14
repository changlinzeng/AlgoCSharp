public class RemoveAllAdjacentDuplicatesInString_II_1209 {
    public string RemoveDuplicates(string s, int k) {
        var count = new Stack<Tuple<char, int>>();
        foreach (var c in s)
        {
          if (count.Count == 0 || count.Peek().Item1 != c)
          {
            count.Push(Tuple.Create(c, 1));
          }
          else
          {
            var top = count.Pop();
            if (top.Item2 < k - 1)
            {
              count.Push(Tuple.Create(c, top.Item2 + 1));
            }
          }
        }
        
        return string.Join("", count.Reverse().Select(c => new string(c.Item1, c.Item2)));
    }
}