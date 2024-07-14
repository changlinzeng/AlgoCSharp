public class ReverseWordsInAString_151 {
    public string ReverseWords(string s) {
        var stack = new Stack<string>();
        foreach (var w in s.Split(" ", StringSplitOptions.RemoveEmptyEntries))
        {
          stack.Push(w);
        }

        return string.Join(" ", stack);
    }
}