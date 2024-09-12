public class OpenTheLock_752 {
    public static int OpenLock(string[] deadends, string target) {
        var steps = 0;
        Queue<string> q = [];
        HashSet<string> visited = [];
        ISet<string> dead = new HashSet<string>(deadends);
        if (dead.Contains("0000"))
        {
          return -1;
        }
        q.Enqueue("0000");
        while (q.Count > 0)
        {
          var size = q.Count;
          IList<string> list = [];
          for (var i = 0; i < size; i++)
          {
            var e = q.Dequeue();
            if (e == target)
            {
              return steps;
            }
            if (!visited.Add(e))
            {
              continue;
            }
            foreach (var n in NextWheels(e, dead))
            {
              list.Add(n);
            }
          }
          foreach (var c in list)
          {
            q.Enqueue(c);
          }
          steps++;
        }
        return -1;
    }

    private static IList<string> NextWheels(string wheel, ISet<string> deadends)
    {
      IList<string> result = [];
      for (var i = 0; i < wheel.Length; i++)
      {
        var res1 = "";
        var res2 = "";
        for (var j = 0; j < wheel.Length; j++)
        {
          if (j == i)
          {
            // replace the i(th) digit
            res1 += wheel[i] switch
            {
              '9' => '0',
              _ => (char)(wheel[i] + 1)
            };
            res2 += wheel[i] switch
            {
              '0' => '9',
              _ => (char)(wheel[i] - 1)
            };
          }
          else
          {
            res1 += wheel[j];
            res2 += wheel[j];
          }
        }
        foreach (var w in new List<string>(){res1, res2})
        {
          if (!deadends.Contains(w))
          {
            result.Add(w);
          }
        }
      }
      return result;
    }
}