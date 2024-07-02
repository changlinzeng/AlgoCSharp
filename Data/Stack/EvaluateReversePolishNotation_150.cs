public class EvaluateReversePolishNotation_150 {
    private static readonly string[] ops = ["+", "-", "*", "/"];

    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var token in tokens)
        {
          if (ops.Contains(token))
          {
            int num1 = stack.Pop(), num2 = stack.Pop();
            int result = token switch
            {
              "+" => num1 + num2,
              "-" => num1 - num2,
              "*" => num1 * num2,
              "/" => num1 / num2,
            };
            stack.Push(result);
          }
          else
          {
            stack.Push(int.Parse(token));
          }
        }
        return stack.Pop();
    }
}