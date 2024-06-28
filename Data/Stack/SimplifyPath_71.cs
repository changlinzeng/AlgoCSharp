public class SimplifyPath_71 {
    public static string SimplifyPath(string path) {
        var stack = new Stack<string>();
        path.Split("/").Where(a => !string.IsNullOrEmpty(a)).ToList().ForEach(dir =>
          {
            switch (dir)
            {
              case "..":
                if (stack.Count > 0) stack.Pop();
                break;
              case ".":
                break;
              default:
                stack.Push(dir);
                break;
            };
          });
        return "/" + string.Join("/", stack.Reverse());
    }
}