using Microsoft.Win32.SafeHandles;

public class MinimumRemoveToMakeValidParentheses_1249 {
    public string MinRemoveToMakeValid(string s) {
        var leftCount = 0;
        var stack = new Stack<string>();
        foreach (var ch in s)
        {
          if (ch >= 'a' && ch <= 'z')
          {
            stack.Push(ch.ToString());
          }
          else if (ch == '(')
          {
            leftCount++;
            stack.Push("(");
          }
          else
          {
            if (leftCount > 0)
            {
              var tmp = "";
              while (stack.Peek() != "(")
              {
                tmp = stack.Pop() + tmp;
              }
              stack.Pop();  // pop "("
              stack.Push("(" + tmp + ")");
              leftCount--;
            }
          }
        }
        return string.Join("", stack.Where(c => c != "(").Reverse());
    }
}