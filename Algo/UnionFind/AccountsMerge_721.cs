public class AccountsMerge_721 {
    public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
      var parents = new int[accounts.Count];
      for (var i = 0; i < parents.Length; i++)
      {
        parents[i] = i;
      }

      Dictionary<string, int> emailAcct = [];  // email -> acct id

      for (var i = 0; i < accounts.Count; i++)
      {
        var acct = accounts[i];
        foreach (var email in acct.Skip(1))
        {
          // if current email belongs to more than 1 account, then merge account
          if (!emailAcct.TryAdd(email, i))
          {
            // current parent account of this email
            var parent = parents[emailAcct[email]];
            if (parent != i)
            {
              for (var j = 0; j < parents.Length; j++)
              {
                if (parents[j] == parent)
                {
                  parents[j] = i;
                }
              }
            }
          }
        }
      }

      Dictionary<int, ISet<string>> mergedAcct = [];
      for (var i = 0; i < parents.Length; i++)
      {
        mergedAcct.TryAdd(parents[i], new HashSet<string>());
        for (var k = 1; k < accounts[i].Count; k++)
        {
          mergedAcct[parents[i]].Add(accounts[i][k]);
        }
      }

      IList<IList<string>> result = [];
      foreach (var kv in mergedAcct)
      {
        List<string> res = [];
        res.Add(accounts[kv.Key][0]);
        var list = mergedAcct[kv.Key].ToList();
        list.Sort(Comparer<string>.Create((a, b) => string.CompareOrdinal(a, b)));
        res.AddRange(list);
        result.Add(res);
      }
      return result;
    }
}