public class SearchInRotatedSortedArray_33 {
    public int Search(int[] nums, int target) {
        int start = 0, end = nums.Length - 1;
        while (start <= end)
        {
          var mid = start + (end - start) / 2;
          if (nums[mid] == target)
          {
            return mid;
          }
          if (nums[mid] > nums[start])
          {
            // in the upper section
            if (target >= nums[start] && target < nums[mid])
            {
              end = mid - 1;
            }
            else
            {
              start = mid + 1;
            }
          }
          else if (nums[mid] < nums[end])
          {
            // in the lower section
            if (target > nums[mid] && target <= nums[end])
            {
              start = mid + 1;
            }
            else
            {
              end = mid - 1;
            }
          }
          else
          {
            if (mid == start)
            {
              start++;
            }
            if (mid == end)
            {
              end--;
            }
          }
        }
        return -1;
    }
}