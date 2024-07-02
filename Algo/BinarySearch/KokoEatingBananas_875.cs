public class KokoEatingBananas_875 {
    public static int MinEatingSpeed(int[] piles, int h) {
        int minSpeed = 0, maxSpeed = piles.Max();
        while (minSpeed < maxSpeed)
        {
          var mid = minSpeed + (maxSpeed - minSpeed) / 2;
          if (mid == 0)
          {
            return 1;
          }
          // check if koko can eat all bananas with speed mid within h hours
          if (TryEat(piles, h, mid))
          {
            maxSpeed = mid;
          }
          else
          {
            minSpeed = mid + 1;
          }
        }
        return minSpeed;
    }

    private static bool TryEat(in int[] piles, in int h, in int speed)
    {
      var time = 0;
      var i = 0;
      while (i < piles.Length)
      {
        if (time > h)
        {
          return false;
        }
        var left = piles[i];
        if (speed >= left)
        {
          time++;
        }
        else
        {
          time += left / speed;
          if (left % speed != 0)
          {
            time++;
          }
        }
        i++;
      }
      return time <= h;
    }
}