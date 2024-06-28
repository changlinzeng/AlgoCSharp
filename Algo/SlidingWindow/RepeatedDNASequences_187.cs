public class RepeatedDNASequences_187 {
    public static IList<string> FindRepeatedDnaSequences(string s) {
        if (s.Length < 10)
        {
          return [];
        }
        var uniq = new HashSet<string>();
        var result = new HashSet<string>();
        var dna = s[..10];
        uniq.Add(dna);
        for (var i = 10; i < s.Length; i++)
        {
          dna += s[i];
          dna = dna[1..];
          if (!uniq.Add(dna))
          {
            result.Add(dna);
          }
        }
        return [.. result];
    }
}