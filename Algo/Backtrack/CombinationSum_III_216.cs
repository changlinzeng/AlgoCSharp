public class CombinationSUm_III_216 {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var all = new List<IList<int>>();
        Backtrack(k, n, 1, [], all);
        return all;
    }

    private void Backtrack(int k, int n, in int start, in IEnumerable<int> comb, in IList<IList<int>> all)
    {
      if (k == 0 && n == 0)
      {
        all.Add([.. comb]);
        return;
      }
      for (var i = start; i <= 9; i++)
      {
        if (i > n)
        {
          break;
        }
        Backtrack(k - 1, n - i, i + 1, comb.Append(i), all);
      }
    }
}