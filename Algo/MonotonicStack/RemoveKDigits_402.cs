public class RemoveKDigits_402 {
    public string RemoveKdigits(string num, int k) {
        var len = num.Length;
        var maxStack = new Stack<char>();

        if (k >= num.Length)
        {
          return "0";
        }

        for (var i = 0; i < len; i++)
        {
          while (maxStack.Count > 0 && maxStack.Peek() > num[i] && maxStack.Count + (len - i) > len - k)
          {
            maxStack.Pop();
          }
          if (maxStack.Count < len - k)
          {
            maxStack.Push(num[i]);
          }
        }

        var result = string.Join("", maxStack.Reverse());
        // remove leading zeros
        int j = 0;
        while (j < result.Length && result[j] == '0')
        {
          j++;
        }
        return j < result.Length ? result[j..] : "0";
    }
}