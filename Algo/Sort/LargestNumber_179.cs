public class LargestNumber_179 {
    public static string LargestNumber(int[] nums) {
        var pq = new PriorityQueue<string, string>(Comparer<string>.Create((a, b) =>
        {
          var n1 = a + b;
          var n2 = b + a;
          for (var i = 0; i < a.Length + b.Length; i++)
          {
            if (n1[i] < n2[i])
            {
              return 1;
            }
            if (n1[i] > n2[i])
            {
              return -1;
            }
          }
          return 0;
        }));

        foreach (var num in nums)
        {
          pq.Enqueue(num.ToString(), num.ToString());
        }

        var result = "";
        while (pq.Count > 0 && pq.Peek() == "0")
        {
          pq.Dequeue();
        }
        while (pq.Count > 0)
        {
          result += pq.Dequeue();
        }
        if (string.IsNullOrEmpty(result))
        {
          result = "0";
        }
        return result;
    }
}