using System;
using System.Collections.Generic;

namespace RomantoDecimal.App
{
    public class RomanConverter
    {
        public static Dictionary<char, int> romanNumerals =
            new Dictionary<char, int>(){
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
        public static int ConvertRoman(string roman)
        {
            int summation = 0;

            // foreach (var letter in roman)
            // {
            //     summation += romanNumerals[letter];
            // }
            for (int i = 0; i < roman.Length; i++)
            {
                int current = romanNumerals[roman[i]];
                int next = current;
                if (i != roman.Length - 1)
                {
                    next = romanNumerals[roman[i + 1]];
                }

                if (current < next)
                {
                    summation += (next - current);
                    i++;
                }
                else
                {
                    summation += current;
                }

            }


            return summation;
        }
    }
}
