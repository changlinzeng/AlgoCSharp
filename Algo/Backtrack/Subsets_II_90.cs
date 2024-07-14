public class Subsets_II_90 {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var sets = new List<IList<int>>();
        Array.Sort(nums);
        Backtrack(nums, 0, [], sets);
        return sets;
    }

    private void Backtrack(in int[] nums, in int start, IEnumerable<int> set, IList<IList<int>> sets)
    {
      sets.Add([.. set]);
      for (var i = start; i < nums.Length; i++)
      {
        // skip duplicate
        if (i > start && nums[i] == nums[i - 1])
        {
          continue;
        }
        Backtrack(nums, i + 1, set.Append(nums[i]), sets);
      }
    }
}