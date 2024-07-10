public class KeysAndRooms_841 {
    public static bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var visited = new bool[rooms.Count];
        Dfs(rooms, 0, visited);
        return !visited.Any(v => !v);
    }

    private static void Dfs(IList<IList<int>> rooms, int room, bool[] visited)
    {
      if (visited[room])
      {
        return;
      }
      visited[room] = true;
      foreach (var nextRoom in rooms[room])
      {
        Dfs(rooms, nextRoom, visited);
      }
    }
}