public class ContinousSubarraySum_523 {
    public static bool CheckSubarraySum(int[] nums, int k) {
        var modMap = new Dictionary<int, int>();  // mod of prefix sum / k -> index
        var sum = 0;
        modMap.Add(0, 0);
        for (var i = 0; i < nums.Length; i++)
        {
          sum += nums[i];
          var mod = sum % k;
          if (modMap.TryGetValue(mod, out int val) && val < i)
          {
            return true;
          }
          else
          {
            modMap.TryAdd(mod, i + 1);
          }
        }
        return false;
    }
}