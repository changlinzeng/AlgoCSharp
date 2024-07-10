public class ValidParenthesisString_678 {
    public bool CheckValidString(string s) {
        var leftParens = new Stack<int>();  // indexes of left parenthesis
        var asterisks = new Stack<int>();  // indexes of aserisks
        for (var i = 0; i < s.Length; i++)
        {
          if (s[i] == '(')
          {
            leftParens.Push(i);
          }
          else if (s[i] == '*')
          {
            asterisks.Push(i);
          }
          else
          {
            if (leftParens.Count > 0)
            {
              // consume left parenthesis
              leftParens.Pop();
            }
            else if (asterisks.Count > 0)
            {
              // if no left parenthesis, then consume asterisk
              asterisks.Pop();
            }
            else
            {
              // find excess right parenthesis
              return false;
            }
          }
        }

        // consume left parenthesis with asterisks
        while (leftParens.Count > 0 && asterisks.Count > 0)
        {
          // left parenthesis should be on the left side of asterisk
          if (leftParens.Pop() > asterisks.Pop())
          {
            return false;
          }
        }

        // make sure we consumed all left parenthese
        return leftParens.Count == 0;
    }
}