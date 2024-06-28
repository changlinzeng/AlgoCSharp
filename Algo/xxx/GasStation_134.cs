public class GasStation_134 {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int i = 0, len = gas.Length;
        int start = 0;
        int fuel = 0, total = 0;
        // calculate the gas left at each station and if it is negative,
        // it means we could make full trip from the start station to current station
        // then we try to make trip at station i + 1
        while (i < len)
        {
          total = total + gas[i] - cost[i];
          fuel = fuel + gas[i] - cost[i];
          if (fuel < 0)
          {
            fuel = 0;
            start = i + 1;
          }
          i++;
        }
        return total < 0 ? -1 : start;
    }
}