using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.EulerCSharp
    {
        public class Utilities
        {
            public static string DataPath
            {
                get
                {
                    var path = System.Environment.GetEnvironmentVariable("EulerData");
                    if (String.IsNullOrEmpty(path))
                    {
                        var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                        var uri = new System.UriBuilder(codeBase);
                        var assemblyPath = System.Uri.UnescapeDataString(uri.Path);
                        var assemblyDir = System.IO.Path.GetDirectoryName(assemblyPath);
                        var data = System.IO.Path.Combine(assemblyDir, @"..\..\..\Data");
                        return data;
                    }
                    else
                    {
                        return path;
                    }
                }
            }

            public long SumDigits(BigInteger n)
            {
                string s = n.ToString();
                long total = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    long digit = long.Parse(s.Substring(i, 1));
                    total += digit;
                }

                return total;
            }

            public long NumberOfDigits(BigInteger n)
            {
                return n.ToString().Length;
            }

            public long SumOfSquaredDigits(long n)
            {
                if (n <= 0) return 0;

                string s = n.ToString();
                long total = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    long digit = long.Parse(s.Substring(i, 1));
                    total += digit * digit;
                }

                return total;
            }

            public long Value(string s)
            {
                if (s == null)
                    return 0;

                if (s.Length == 0)
                    return 0;

                long value = 0;
                char[] digits = s.ToCharArray();
                foreach (char c in digits)
                {
                    value += System.Convert.ToInt32(c) - 64;
                }

                return value;
            }

            public string ReverseString(string s)
            {
                if (s == null)
                    return null;
                if (s == "")
                    return "";

                StringBuilder sb = new StringBuilder();

                for (int i = 1; i <= s.Length; i++)
                    sb.Append(s[s.Length - i]);

                return sb.ToString();
            }

            public long ReverseNumber(long s)
            {
                return long.Parse(ReverseString(s.ToString()));
            }

            public bool IsPalindrome(long n)
            {
                return IsPalindrome(n.ToString());
            }

            public bool IsPalindrome(string s)
            {
                return s.Equals(ReverseString(s));
            }

            public long TriangularNumber(long n)
            {
                return n * (n + 1) / 2;
            }

            public long NumberOfDivisors(long n)
            {
                if (n == 1)
                    return 1;

                long answer = 2; // include 1 and n
                long testTo = (long)(Math.Sqrt(n));

                for (int i = 2; i < testTo; i++)
                    if (n % i == 0)
                        answer += 2;

                if (testTo * testTo == n)
                    answer++;

                return answer;
            }

            public long SumOfProperDivisors(long n)
            {
                if (n == 1)
                    return 1;

                long sum = 0;

                for (long i = 1; i < n; i++)
                    if (n % i == 0)
                        sum += i;

                return sum;
            }

            public bool IsAbundant(long n)
            {
                return (SumOfProperDivisors(n) > n);
            }

            public bool[] AbundantsUpTo(long n)
            {
                // this could easily be speeded up
                bool[] isAbundant = new bool[n + 1];

                for (int i = 12; i <= n; i++)
                    if (IsAbundant(i))
                        isAbundant[i] = true;

                return isAbundant;
            }

            public long NumberOfLetters(long n)
            {
                string s = Letters(n);
                long a = 0;
                for (int i = 0; i < s.Length; i++)
                    if (s.Substring(i, 1) != " ")
                        a++;

                return a;
            }

            public string Letters(long n)
            {
                if (n > 1000 || n < 0)
                    throw new Exception("n invalid in NumberOfLetters");

                if (n == 0)
                    return "";

                if (n == 1000)
                    return "one thousand";

                if (n >= 100)
                    if (n % 100 == 0)
                        return Letters(n / 100) + " hundred";
                    else
                        return Letters(n / 100) + " hundred" + " and " + Letters(n % 100);

                if (n >= 20)
                {
                    string a = "";
                    switch (n / 10)
                    {
                        case 2:
                            a = "twenty ";
                            break;
                        case 3:
                            a = "thirty ";
                            break;
                        case 4:
                            a = "forty ";
                            break;
                        case 5:
                            a = "fifty ";
                            break;
                        case 6:
                            a = "sixty ";
                            break;
                        case 7:
                            a = "seventy ";
                            break;
                        case 8:
                            a = "eighty ";
                            break;
                        case 9:
                            a = "ninety ";
                            break;
                    }
                    a += Letters(n % 10);
                    return a;
                }

                switch (n)
                {
                    case 1:
                        return "one";
                    case 2:
                        return "two";
                    case 3:
                        return "three";
                    case 4:
                        return "four";
                    case 5:
                        return "five";
                    case 6:
                        return "six";
                    case 7:
                        return "seven";
                    case 8:
                        return "eight";
                    case 9:
                        return "nine";
                    case 10:
                        return "ten";
                    case 11:
                        return "eleven";
                    case 12:
                        return "twelve";
                    case 13:
                        return "thirteen";
                    case 14:
                        return "fourteen";
                    case 15:
                        return "fifteen";
                    case 16:
                        return "sixteen";
                    case 17:
                        return "seventeen";
                    case 18:
                        return "eighteen";
                    case 19:
                        return "nineteen";
                }

                throw new Exception("n invalid in NumberOfLetters");
            }

            public string ToBinary(long n)
            {
                if (n == 0)
                    return "0";
                if (n == 1)
                    return "1";
                if (n < 0)
                    throw new Exception("Negative number in ToBinary");

                long maxPower = 0;
                long twoPower = 1;

                while (n >= twoPower * 2)
                {
                    maxPower++;
                    twoPower *= 2;
                }

                StringBuilder sb = new StringBuilder();
                long dec = n;

                for (long i = maxPower; i >= 0; i--)
                {
                    if (dec >= twoPower)
                    {
                        sb.Append("1");
                        dec -= twoPower;
                    }
                    else
                    {
                        sb.Append("0");
                    }
                    twoPower /= 2;
                }

                return sb.ToString();
            }

            public List<long> RotateDigits(long n)
            {
                string s = n.ToString();
                string s2 = s + s;
                List<long> perms = new List<long>();

                if (s.Length == 1)
                {
                    perms.Add(n);
                    return perms;
                }

                for (int i = 0; i < s.Length; i++)
                {
                    perms.Add(long.Parse(s2.Substring(i, s.Length)));
                }

                return perms;
            }

            public bool ArePermutations(long m, long n)
            {
                var m1 = m.ToString().ToCharArray().OrderBy(c => c).ToArray();
                var n1 = n.ToString().ToCharArray().OrderBy(c => c).ToArray();

                return m1.SequenceEqual(n1);
            }

            public List<string> AllDigitPermutations(string s)
            {
                List<string> perms = new List<string>();

                if (s.Length == 1)
                {
                    perms.Add(s);
                    return perms;
                }

                // choose character for 1st digit
                for (int i = 0; i < s.Length; i++)
                {
                    string s1 = s.Substring(i, 1);
                    string s2 = s.Remove(i, 1);
                    List<string> recurse = AllDigitPermutations(s2);
                    foreach (string s3 in recurse)
                    {
                        perms.Add(s1 + s3);
                    }
                }

                return perms;
            }

            public long Pentagonal(long n)
            {
                return n * (3 * n - 1) / 2;
            }

            public bool IsPentagonal(long n)
            {
                long closest = (long)Math.Round(1.0 / 6.0 * (1.0 + Math.Sqrt(1.0 + 24.0 * n)));

                return (n == Pentagonal(closest));
            }

            public long Hexagonal(long n)
            {
                return n * (2 * n - 1);
            }

            public bool IsHexagonal(long n)
            {
                long closest = (long)Math.Round(1.0 / 4.0 * (1.0 + Math.Sqrt(1.0 + 8.0 * n)));

                return (n == Hexagonal(closest));
            }

            public long GCD(long a, long b)
            {
                long t;

                while (b != 0)
                {
                    t = b;
                    b = a % b;
                    a = t;
                }

                return a;
            }

            public bool Is9Pandigital(string s)
            {
                if (s.Length != 9)
                    return false;

                char[] chars = s.ToCharArray().OrderBy(c => c).ToArray();

                string s2 = new string(chars);

                if (s2 == "123456789")
                    return true;
                else
                    return false;
            }

            public static List<List<T>> GenerateSubsets<T>(List<T> set, bool includeEmpty, bool includeFull)
            {
                int size = set.Count;
                int numberOfSubsets = 1 << size;

                List<List<T>> result = new List<List<T>>();

                int start = includeEmpty ? 0 : 1;
                int end = includeFull ? numberOfSubsets : numberOfSubsets - 1;

                for (int i = start; i < end; i++)
                {
                    List<T> subset = new List<T>();

                    for (int j = 0; j < size; j++)
                    {
                        if (((1 << j) & i) != 0)
                        {
                            subset.Add(set[j]);
                        }
                    }

                    result.Add(subset);
                }

                return result;
            }
        }

        class Problem14Chain
        {
            static long[] lengths = new long[1000000];

            public long GetChainLength(long n)
            {
                if (n <= 1)
                    return 1;

                if (n < 1000000 && lengths[n] > 0)
                    return lengths[n];

                long next, length;

                if (n % 2 == 0)
                    next = n / 2;
                else
                    next = 3 * n + 1;

                length = 1 + GetChainLength(next);

                if (n < 1000000)
                    lengths[n] = length;

                return length;
            }
        }

        public struct Fraction
        {
            private static Utilities util = new Utilities();
            private long numerator, denominator;

            public long Numerator { get { return numerator; } }
            public long Denominator { get { return denominator; } }

            public Fraction(long numerator, long denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }

            public override string ToString()
            {
                return numerator.ToString() + "/" + denominator.ToString();
            }

            public Fraction Reduce()
            {
                if (numerator == 0)
                    return new Fraction(0, 1);

                long gcd = util.GCD(numerator, denominator);

                return new Fraction(numerator / gcd, denominator / gcd);
            }

            public double ToDouble()
            {
                return (double)numerator / (double)denominator;
            }

            public static Fraction operator *(Fraction f1, Fraction f2)
            {
                return new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator).Reduce();
            }

            public static Fraction operator /(Fraction f1, Fraction f2)
            {
                return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator).Reduce();
            }

            public static Fraction operator +(Fraction f1, Fraction f2)
            {
                return new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator).Reduce();
            }

            public static bool operator ==(Fraction f1, Fraction f2)
            {
                Fraction f1r = f1.Reduce();
                Fraction f2r = f2.Reduce();

                return (f1r.Numerator == f2r.Numerator && f1r.Denominator == f2r.Denominator);
            }

            public static bool operator !=(Fraction f1, Fraction f2)
            {
                return !(f1 == f2);
            }
        }

        public struct BigFraction
        {
            private static Utilities util = new Utilities();
            private BigInteger numerator, denominator;

            public BigInteger Numerator { get { return numerator; } }
            public BigInteger Denominator { get { return denominator; } }

            public BigFraction(BigInteger numerator, BigInteger denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }

            public override string ToString()
            {
                return numerator.ToString() + "/" + denominator.ToString();
            }

            public BigFraction Reduce()
            {
                if (numerator == 0)
                    return new BigFraction(0, 1);

                BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

                return new BigFraction(numerator / gcd, denominator / gcd);
            }

            public double ToDouble()
            {
                return (double)numerator / (double)denominator;
            }

            public static BigFraction operator *(BigFraction f1, BigFraction f2)
            {
                return new BigFraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator).Reduce();
            }

            public static BigFraction operator /(BigFraction f1, BigFraction f2)
            {
                return new BigFraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator).Reduce();
            }

            public static BigFraction operator +(BigFraction f1, BigFraction f2)
            {
                return new BigFraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator).Reduce();
            }

            public static bool operator ==(BigFraction f1, BigFraction f2)
            {
                BigFraction f1r = f1.Reduce();
                BigFraction f2r = f2.Reduce();

                return (f1r.Numerator == f2r.Numerator && f1r.Denominator == f2r.Denominator);
            }

            public static bool operator !=(BigFraction f1, BigFraction f2)
            {
                return !(f1 == f2);
            }
        }

    }
