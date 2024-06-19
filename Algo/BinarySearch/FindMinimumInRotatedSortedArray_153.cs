public class FindMinimumInRotatedSortedArray_153 {
    public static int FindMin(int[] nums) {
        int start = 0, end = nums.Length - 1;
        while (start < end)
        {
            var mid = start + (end - start) / 2;
            // nums[start] < nums[end] means we are on either the
            // left side or the right side in an increasing order
            if (nums[start] < nums[end])
            {
                return nums[start];
            }
            if (nums[mid] > nums[start])
            {
                // on the upper
                start = mid + 1;
            }
            else
            {
                // on the lower
                end = mid;
            }
        }
        return nums[start];
    }
}