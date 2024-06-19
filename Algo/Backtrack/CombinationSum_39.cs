public class CombinationSum_39 {
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
      var all = new List<IList<int>>();
      Array.Sort(candidates);
      Backtrack(candidates, target, 0, [], all);
      return all;
    }

    private void Backtrack(int[] candidates, int target, int start, IList<int> combination, IList<IList<int>> all)
    {
      if (target == 0)
      {
        all.Add([.. combination]);
        return;
      }
      for (var i = start; i < candidates.Length; i++)
      {
        var num = candidates[i];
        if (num <= target)
        {
          combination.Add(num);
          Backtrack(candidates, target - num, i, combination, all);
          combination.RemoveAt(combination.Count - 1);
        }
      }
    }
}