public class Combinations_77 {
    public IList<IList<int>> Combine(int n, int k) {
        var all = new List<IList<int>>();
        Backtrack(n, k, 0, all, []);
        return all;
    }

    private void Backtrack(int n, int k, int start, List<IList<int>> all, List<int> comb)
    {
      if (k == 0)
      {
        all.Add([.. comb]);
        return;
      }
      for (var i = start; i <= n; i++)
      {
        comb.Add(i);
        Backtrack(n, k - 1, i + 1, all, comb);
        comb.RemoveAt(comb.Count - 1);
      }
    }
}