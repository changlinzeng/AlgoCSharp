public class FindTheDuplicateNumber_287 {
    public int FindDuplicate(int[] nums) {
        int start = 0, end = nums.Length - 1;
        while (start < end)
        {
          var mid = start + (end - start) / 2;
          // count numbers that are less than nums[mid]
          var count = nums.Count(n => n <= mid);

          // if the number of numbers less than mid greater than mid,
          // it means there are duplicates between [1, mid]
          // Otherwise, the duplicates are in [mid + 1, end]
          if (count > mid)
          {
            end = mid;
          }
          else
          {
            start = mid + 1;
          }
        }

        return start;
    }
}