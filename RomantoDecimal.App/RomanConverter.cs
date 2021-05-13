using System;
using System.Collections.Generic;

namespace RomantoDecimal.App
{
  public class RomanConverter
  {
    public static int ConvertRoman(string roman)
    {
      var intialDict = new Dictionary<char, int>(){
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
      };
      int summation = 0;
      roman = roman.ToUpper();

      for (int i = 0; i < roman.Length; i++)
      {
        // Checks negatives
        if (roman[i] == '-')
        {
          throw new ApplicationException("Negative Values Are Invalid");
        }

        int current = intialDict[roman[i]];
        int next = current;
        // Reinitialize next if not null
        if (i != roman.Length - 1) next = intialDict[roman[i + 1]];

        // Subtraction method
        if (current < next)
        {
          summation += (next - current);
          i++;
        }
        else
        {
          // Addition method
          summation += current;
          foreach (var item in intialDict.Keys)
          {
            if (intialDict[item] > current)
            {
              intialDict.Remove(item);
            };
          }
        }
      }

      // Exceeding Method
      if (summation > 3999)
      {
        throw new ApplicationException("Number exceeds max value of 3999");
      }

      return summation;
    }
  }
}
