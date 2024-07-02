public class SnapshotArray {

    private readonly int[] data;
    // snapshots are a list of maps that record the changes to index i
    private readonly List<Dictionary<int, int>> snapshot;

    public SnapshotArray(int length) {
        data = new int[length];
        snapshot = [];
        snapshot.Add([]);
    }
    
    public void Set(int index, int val) {
        var active = snapshot.Last();
        if (!active.TryAdd(index, val))
        {
          active[index] = val;
        }
    }
    
    public int Snap() {
        var id = snapshot.Count - 1;
        snapshot.Add([]);
        return id;
    }
    
    public int Get(int index, int snap_id) {
      // search snapshot from snap_id to snapshot 0
      for (var i = snap_id; i >= 0; i--)
      {
        if (snapshot[i].ContainsKey(index))
        {
          return snapshot[i][index];
        }
      }

      // return from original data if index is in snapshot
      return data[index];
    }
}
