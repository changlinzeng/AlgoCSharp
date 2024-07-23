public class BrokenCalculator_991 {
    public int BrokenCalc(int startValue, int target) {
      if (target == startValue)
      {
        return 0;
      }
      if (target < startValue)
      {
        return startValue - target;
      }
      if (target % 2 == 0)
      {
        // if target is even, then we multiple by 2
        return 1 + BrokenCalc(startValue, target / 2);
      }
      else
      {
        // if target is odd, then we minus 1
        return 1 + BrokenCalc(startValue, target + 1);
      }
    }
}