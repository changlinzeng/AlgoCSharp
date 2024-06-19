public class ValidTriangleNumber_611 {
    public int TriangleNumber(int[] nums) {
      var count = 0;
      Array.Sort(nums);
      for (var i = 0; i < nums.Length; i++)
      {
        for (var j = i + 1; j < nums.Length; j++)
        {
          for (var k = j + 1; k < nums.Length; k++)
          {
            if (nums[i] + nums[j] > nums[k])
            {
              count++;
            }
            else {
              break;
            }
          }
        }
      }
      return count;
    }
}