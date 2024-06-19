public class StringToInteger {
    public static int MyAtoi(string s) {
      long? num = null; 
      char? sign = null;
      for (var i = 0; i < s.Length; i++)
      {
        var ch = s[i];
        if (ch >= '0' && ch <= '9')
        {
          num ??= 0;
          num = num * 10 + int.Parse(ch + "");
          long res = (long)(sign == '-' ? -1 * num : num);
          if (res >= int.MaxValue) {
            return int.MaxValue;
          }
          if (res <= int.MinValue)
          {
            return int.MinValue;
          }
        }
        else if (ch == '-' || ch == '+')
        {
          if (num is not null)
          {
            break;
          }
          if (sign is not null)
          {
            break;
          }
          sign = ch;
        }
        else
        {
          if (num is not null || sign is not null)
          {
            break;
          }
          if (ch != ' ')
          {
            break;
          }
        }
      }
      num ??= 0;
      return (int)(sign == '-' ? -1 * num : num);
    }
}