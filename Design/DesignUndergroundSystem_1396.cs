public class UndergroundSystem {

    private readonly Dictionary<string, Tuple<int, double>> average;
    private readonly Dictionary<int, CheckInInfo> checkIn;

    public UndergroundSystem() {
        average = [];
        checkIn = [];
    }

    public void CheckIn(int id, string stationName, int t) {
        checkIn.Add(id, new CheckInInfo(stationName, t));
    }

    public void CheckOut(int id, string stationName, int t) {
        if (!checkIn.ContainsKey(id))
        {
          return;
        }
        var checkinStation = checkIn[id].Station;
        var checkinTime = checkIn[id].Time;
        var key = $"{checkinStation}_{stationName}";
        average.TryAdd(key, Tuple.Create(0, 0d));
        int count = average[key].Item1;
        double avg = average[key].Item2;
        average[key] = Tuple.Create(count + 1, (count * avg + t - checkinTime) / (count + 1));
        checkIn.Remove(id);
    }

    public double GetAverageTime(string startStation, string endStation) {
         return average[$"{startStation}_{endStation}"].Item2;
    }

    record CheckInInfo(string Station, int Time)
    {
      public string Station {get; private set;} = Station;
      public int Time {get; private set;} = Time;
    }
}