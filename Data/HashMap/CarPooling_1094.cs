public class CarPooling_1094 {
    public bool CarPooling(int[][] trips, int capacity) {
      // map of time -> passenges get in/out at this time.
      // positive for getting on the bus and negative for getting out of this bus
      var timePassengers = new SortedDictionary<int, int>();
      foreach (var trip in trips)
      {
        if (!timePassengers.TryAdd(trip[1], trip[0]))
        {
          timePassengers[trip[1]] = timePassengers[trip[1]] + trip[0];
        }
        if (!timePassengers.TryAdd(trip[2], -1 * trip[0]))
        {
          timePassengers[trip[2]] = timePassengers[trip[2]] - trip[0];
        }
      }

      var totalPassengers = 0;
      foreach (var (_, v) in timePassengers)
      {
        totalPassengers += v;
        if (totalPassengers > capacity)
        {
          return false;
        }
      }
      return true;
    }
}