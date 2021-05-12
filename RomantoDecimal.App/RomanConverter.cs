using System;
using System.Collections.Generic;

namespace RomantoDecimal.App
{
    public class RomanConverter
    {
        public static int ConvertRoman(string roman) {

            Dictionary<string, int> romanNumerals =
            new Dictionary<string, int>(){
                {"I",1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000}
            };
            return romanNumerals[roman];
        }
    }
}
