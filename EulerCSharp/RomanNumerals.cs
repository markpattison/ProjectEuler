using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler
{
    public static class RomanNumerals
    {
        public static long Problem89(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            long result = 0;

            for (int i = 0; i < 1000; i++)
            {
                string original = sr.ReadLine();
                long n = Parse(original);
                string minimal = Minimal(n);

                result += original.Length - minimal.Length;
            }

            return result;
        }

        public static long Parse(string s)
        {
            long[] charValues = s.ToCharArray().Select(CharacterValue).ToArray();

            long result = 0;

            for (int i = 0; i < charValues.Length; i++)
            {
                long value = charValues[i];

                if (charValues.Where((n, index) => (index > i)).All(n => (n <= value)))
                {
                    result += value;
                }
                else
                {
                    result -= value;
                }
            }

            return result;
        }

        public static string Minimal(long n)
        {
            string roman = NoSubtractivePairs(n);

            roman = roman.Replace("DCCCC", "CM");
            roman = roman.Replace("CCCC", "CD");
            roman = roman.Replace("LXXXX", "XC");
            roman = roman.Replace("XXXX", "XD");
            roman = roman.Replace("VIIII", "IX");
            roman = roman.Replace("IIII", "IV");

            return roman;
        }

        public static string NoSubtractivePairs(long n)
        {
            long remaining = n;
            StringBuilder sb = new StringBuilder();

            while (remaining > 0)
            {
                if (remaining >= 1000)
                {
                    sb.Append("M");
                    remaining -= 1000;
                }
                else if (remaining >= 500)
                {
                    sb.Append("D");
                    remaining -= 500;
                }
                else if (remaining >= 100)
                {
                    sb.Append("C");
                    remaining -= 100;
                }
                else if (remaining >= 50)
                {
                    sb.Append("L");
                    remaining -= 50;
                }
                else if (remaining >= 10)
                {
                    sb.Append("X");
                    remaining -= 10;
                }
                else if (remaining >= 5)
                {
                    sb.Append("V");
                    remaining -= 5;
                }
                else if (remaining >= 1)
                {
                    sb.Append("I");
                    remaining -= 1;
                }
            }

            return sb.ToString();
        }

        public static long CharacterValue(char ch)
        {
            switch (ch)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new Exception();
            }
        }
    }
}
