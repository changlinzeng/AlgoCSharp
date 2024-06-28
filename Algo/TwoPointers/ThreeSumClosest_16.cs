public class ThreeSumClosest_16 {
    public int ThreeSumClosest(int[] nums, int target) {
        int i = 0, j = 1, k = nums.Length - 1;
        int minDiff = int.MaxValue;
        int closest = 0;

        Array.Sort(nums);
        while (j < k)
        {
          var sum = nums[i] + nums[j] + nums[k];
          var diff = Math.Abs(sum - target);
          if (diff == 0)
          {
            return sum;
          }
          if (diff < minDiff)
          {
            closest = sum;
            minDiff = diff;
          }

          if (sum > target && j == i + 1)
          {
            k--;
            i = 0;
            j = 1;
          }
          else
          {
            j++;
            if (j == k)
            {
              i++;
              j = i + 1;
            }
          }
        }

        return closest;
    }
}