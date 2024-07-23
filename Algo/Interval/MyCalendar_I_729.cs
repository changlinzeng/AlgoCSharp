public class MyCalendar {
    private readonly List<int[]> calendar;

    public MyCalendar() {
        calendar = [];
    }
    
    public bool Book(int start, int end) {
        if (calendar.Count == 0)
        {
          calendar.Add([start, end]);
          return true;
        }
        else
        {
          if (start <= calendar.First()[0])
          {
            if (end <= calendar.First()[0])
            {
              calendar.Insert(0, [start, end]);
              return true;
            }
            else
            {
              return false;
            }
          }
          if (start >= calendar.Last()[0])
          {
            if (start >= calendar.Last()[1])
            {
              calendar.Add([start, end]);
              return true;
            }
            else
            {
              return false;
            }
          }

          // binary search the position to add new event
          int from = 0, to = calendar.Count - 1;
          var mid = 0;
          while (from < to)
          {
            mid = from + (to - from) / 2;
            if (mid == from)
            {
              break;
            }
            if (calendar[mid][0] == start)
            {
              return false;
            }
            else if (calendar[mid][0] < start)
            {
              from = mid;
            }
            else
            {
              to = mid;
            }
          }
          if (start >= calendar[mid][1] && end <= calendar[mid + 1][0])
          {
            calendar.Insert(mid + 1, [start, end]);
            return true;
          }
          return false;
        }
    }
}