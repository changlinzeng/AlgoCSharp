public class ExclusiveTimeOfFunctions_636 {
    // TODO: the same solution works in Java but not here!
    public static int[] ExclusiveTime(int n, IList<string> logs) {
        var logArr = logs.Select(log =>
        {
          var strs = log.Split(":");
          return new Log(int.Parse(strs[0]), strs[1] == "start", int.Parse(strs[2]));
        }).ToArray();

        // Array.Sort(logArr, (a, b) => a.Ts - b.Ts);

        var time = new int[n];
        var stack = new Stack<Log>();
        foreach (var log in logArr)
        {
          if (log.Start)
          {
            stack.Push(log);
          }
          else
          {
            var prev = stack.Pop();
            var funcTime = log.Ts - prev.Ts + 1;
            time[prev.Id] += funcTime;  // add time for prev job
            // remove the overlapped time for prev function
            if (stack.Count > 0)
            {
              time[stack.Peek().Id] -= funcTime;
            }
          }
        }
        return time;
    }

    record Log(int Id, bool Start, int Ts) {}
}