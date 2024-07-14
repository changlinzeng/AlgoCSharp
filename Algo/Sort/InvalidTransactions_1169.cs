public class InvalidTransactions_1169 {
    public IList<string> InvalidTransactions(string[] transactions) {
        var trans = transactions.Select(t =>
          {
            var fields = t.Split(",");
            return new Transaction(fields[0], int.Parse(fields[1]), int.Parse(fields[2]), fields[3]);
          }).ToList();

        // sort by name then time
        trans.Sort((a, b) =>
          {
            if (a.Name == b.Name)
            {
              return a.Time - b.Time;
            }
            return a.Name.CompareTo(b.Name);
          });

        var added = new bool[trans.Count];
        var invalid = new List<Transaction>();
        for (var i = 0; i < trans.Count; i++)
        {
          for (var j = i; j < trans.Count && trans[j].Name == trans[i].Name; j++)
          {
            if (trans[j].Amount > 1000 && !added[j])
            {
              invalid.Add(trans[j]);
              added[j] = true;
            }
            if (trans[j].City != trans[i].City && trans[j].Time - trans[i].Time <= 60)
            {
              if (!added[i])
              {
                invalid.Add(trans[i]);
                added[i] = true;
              }
              if (!added[j])
              {
                invalid.Add(trans[j]);
                added[j] = true;
              }
            }
          }
        }
        return invalid.Select(t => string.Join(",", [t.Name, t.Time, t.Amount, t.City])).ToList();
    }

    record Transaction(string Name, int Time, int Amount, string City) {}
}