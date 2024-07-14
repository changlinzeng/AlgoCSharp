public class CombinationSum_II_40 {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var all = new List<IList<int>>();
        Array.Sort(candidates);
        Backtrack(candidates, target, 0, [], all);
        return all;
    }

    private void Backtrack(in int[] candidates, in int sum, in int start, IEnumerable<int> combination, IList<IList<int>> all)
    {
      if (sum == 0)
      {
        all.Add([.. combination]);
        return;
      }
      for (var i = start; i < candidates.Length; i++)
      {
        if (i > start && candidates[i] == candidates[i - 1])
        {
          continue;
        }
        if (candidates[i] > sum)
        {
          break;
        }
        Backtrack(candidates, sum - candidates[i], i + 1, combination.Append(candidates[i]), all);
      }
    }
}