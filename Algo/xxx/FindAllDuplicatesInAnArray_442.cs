public class FindAllDuplicatesInAnArray_442 {
    // use nums[i] as index and reverse the number at nums[i]
    // if we find the number at nums[i] is already reversed, then nums[i] is a duplicate
    public IList<int> FindDuplicates(int[] nums) {
        IList<int> duplicates = [];
        for (var i = 0; i < nums.Length; i++)
        {
          var num = Math.Abs(nums[i]);
          if (nums[num - 1] < 0)
          {
            duplicates.Add(num);
          }
          else
          {
            nums[num - 1] = -1 * nums[num - 1];
          }
        }

        return duplicates;
    }
}