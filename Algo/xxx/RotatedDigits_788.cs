public class RotatedDigits_788 {
    public int RotatedDigits(int n) {
        var count = 0;
        for (var i = 1; i <= n; i++)
        {
          if (IsGood(i))
          {
            count++;
          }
        }
        return count;
    }

    private bool IsGood(int num)
    {
      char[] set1 = ['0', '1', '8'];
      char[] set2 = ['0', '1', '8', '2', '5', '6', '9'];
      var chars = num.ToString().ToHashSet();
      return chars.IsSubsetOf(set2) && !chars.IsSubsetOf(set1);
    }
}