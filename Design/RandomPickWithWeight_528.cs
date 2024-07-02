public class RandomPickWithWeight_528 {

    private readonly int[] weight;

    public RandomPickWithWeight_528(int[] w) {
      weight = new int[w.Length + 1];
      weight[0] = 0;
      // calculate the prefix sum and the diff between two sums are the probability
      for (var i = 0; i < w.Length; i++)
      {
        weight[i + 1] = w[i] + weight[i];
      }      
    }
    
    public int PickIndex() {
        var rand = new Random().Next(weight.Last());
        for (var i = 0; i < weight.Length - 1; i++)
        {
          if (rand >= weight[i] && rand < weight[i + 1])
          {
            return i;
          }
        }
        return -1;
    }
}