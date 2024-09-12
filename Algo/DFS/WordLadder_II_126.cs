public class WordLadder_II_126 {
    // Timeout!!!
    public static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord))
        {
          return [];
        }
        if (!wordList.Contains(beginWord))
        {
          wordList.Add(beginWord);
        }
        Dictionary<string, IList<string>> adjMap = [];
        for (var i = 0; i < wordList.Count; i++)
        {
          adjMap.TryAdd(wordList[i], []);
          for (var j = i + 1; j < wordList.Count; j++)
          {
            adjMap.TryAdd(wordList[j], []);
            if (IsAdjacent(wordList[i], wordList[j]))
            {
              adjMap[wordList[i]].Add(wordList[j]);
              adjMap[wordList[j]].Add(wordList[i]);
            }
          }
        }

        // dijkstra to find the shortest path from beginWord to endWord
        Dictionary<int, IList<IList<string>>> paths = [];
        var minPath = int.MaxValue;
        var pq = new PriorityQueue<IList<string>, int>();
        pq.Enqueue([beginWord], 1);
        while (pq.Count > 0)
        {
          var path = pq.Dequeue();
          var word = path.Last();
          if (word == endWord)
          {
            paths.TryAdd(path.Count, []);
            paths[path.Count].Add(path);
            minPath = Math.Min(minPath, path.Count);
            continue;
          }
          if (path.Count >= minPath)
          {
            continue;
          }
          foreach (var sibling in adjMap[word])
          {
            if (!path.Contains(sibling))
            {
              IEnumerable<string> newPath = new List<string>(path).Append(sibling);
              pq.Enqueue(newPath.ToList(), newPath.Count());
            }
          }
        }

        // Dfs(adjMap, beginWord, endWord, new HashSet<string>(), [], paths);

        if (paths.Count == 0)
        {
          return [];
        }
        var minLen = paths.Keys.Min();
        return paths[minLen];
    }

    private static void Dfs(Dictionary<string, IList<string>> adjMap, string word, string target, ISet<string> visited,
                     IList<string> path, Dictionary<int, IList<IList<string>>> paths)
    {
      if (word == target)
      {
        path.Add(word);
        paths.TryAdd(path.Count, []);
        paths[path.Count].Add([.. path]);
        return;
      }
      if (!visited.Add(word))
      {
        return;
      }
      foreach (var sibling in adjMap[word])
      {
        path.Add(word);
        Dfs(adjMap, sibling, target, visited.ToHashSet(), path, paths);
        path.RemoveAt(path.Count - 1);
      }
      // visited.Remove(word);
    }

    private static bool IsAdjacent(string from, string to)
    {
      var diff = 0;
      for (var i = 0; i < from.Length; i++)
      {
        if (diff > 1)
        {
          return false;
        }
        if (from[i] != to[i])
        {
          diff++;
        }
      }
      return diff == 1;
    }
}