public class MinimumTimeToCompleteTrips_2187 {
    public static long MinimumTime(int[] time, int totalTrips) {
        long minTime = 0; 
        long maxTime = (long)time.Max() * (long)totalTrips;
        long minT = maxTime;
        while (minTime < maxTime)
        {
          long mid = minTime + (maxTime - minTime) / 2;
          long trips = time.Select(t => mid / t).Sum();
          if (trips >= totalTrips)
          {
            minT = Math.Min(minT, mid);
            maxTime = mid;
          }
          else if (trips < totalTrips)
          {
            minTime = mid + 1;
          }
        }
        return minT;
    }
}