using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.EulerCSharp
{
    class Utilities
    {
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

        public bool IsPalindrome(long n)
        {
            return (n.ToString().Equals(ReverseString(n.ToString())));
        }

        /// <summary>
        /// Returns a list of primes, up to the lower of a certain number of primes or a maximum prime x. 
        /// </summary>
        /// <param name="number">number of primes</param>
        /// <param name="limit">maximum prime</param>
        /// <returns>first prime is primes[1] = 2.  primes[0] = number found.</returns>
        public long[] Primes(long number, long limit)
        {
            bool[] sieveOut = new bool[limit];
            long[] primes = new long[number + 1];
            long primesfound = 1;
            primes[1] = 2;
            long lastprime, nextprime;

            do
            {
                lastprime = primes[primesfound];

                for (long i = lastprime; i < limit; i += lastprime)
                    sieveOut[i] = true;

                nextprime = lastprime + 1;
                while (nextprime < limit && sieveOut[nextprime])
                {
                    nextprime++;
                }
                if (nextprime < limit && !sieveOut[nextprime])
                {
                    primesfound++;
                    primes[primesfound] = nextprime;
                }

            } while (primesfound < number && nextprime < limit);

            primes[0] = primesfound;

            return primes;
        }

        public long DistinctPrimeFactors(long number, long[] primes)
        {
            return PrimeFactors(number, primes).Distinct().Count();
        }

        public List<long> PrimeFactors(long number, long[] primes)
        {
            List<long> factors = new List<long>();

            if (number < 1)
            {
                return factors;
            }

            long reduced = number;
            int primeIndex = 1;

            while (reduced > 1)
            {
                while (reduced % primes[primeIndex] == 0)
                {
                    factors.Add(primes[primeIndex]);
                    reduced = reduced / primes[primeIndex];
                }
                primeIndex++;
                if (primeIndex > primes[0])
                {
                    throw new Exception("Not enough primes in PrimeFactors");
                }
            }

            return factors;
        }

        public Dictionary<long, long> PrimeFactorisation(long number, long[] primes)
        {
            Dictionary<long, long> factorisation = new Dictionary<long, long>();

            List<long> factors = PrimeFactors(number, primes);
            List<long> uniqueFactors = factors.Distinct().ToList();

            foreach (long l in uniqueFactors)
            {
                factorisation.Add(l, factors.Count(n => n == l));
            }

            return factorisation;
        }

        public long EulerTotient(long number, long[] primes)
        {
            Dictionary<long, long> factorisation = PrimeFactorisation(number, primes);

            long phi = number;

            foreach (long l in factorisation.Keys)
            {
                phi *= l - 1;
                phi /= l;
            }

            return phi;
        }

        public bool IsPrime(long n)
        {
            if (n < 2)
                return false;

            if (n == 2 || n == 3 || n == 5 || n == 7)
                return true;

            if (n % 2 == 0)
                return false;

            long testTo = (long)(Math.Sqrt(n));

            for (int i = 2; i < testTo; i++)
                if (n % i == 0)
                    return false;

            if (testTo * testTo == n)
                return false;

            return true;
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

    class BigNum
    {
        private List<int> digits;
        public int NumDigits { get { return digits.Count; } }

        public BigNum()
        {
            digits = new List<int>();
        }

        public BigNum(long n)
        {
            digits = new List<int>();

            if (n <= 0)
                return;

            string s = n.ToString();
            for (int i = 0; i < s.Length; i++)
                digits.Add(int.Parse(s.Substring(i, 1)));

            digits.Reverse();
        }

        public override string ToString()
        {
            if (digits.Count == 0)
                return "0";

            StringBuilder sb = new StringBuilder();

            for (int i = digits.Count - 1; i >= 0; i--)
                sb.Append(digits[i].ToString());

            return sb.ToString();
        }

        public BigNum MultiplyBy(long n)
        {
            BigNum result = new BigNum();

            long carry = 0;
            long newDigit = 0;

            for (int i = 0; i < this.digits.Count; i++)
            {
                long mult = n * this.digits[i] + carry;
                newDigit = (mult % 10);
                result.digits.Add((int)newDigit);
                carry = (mult - newDigit) / 10;
            }

            if (carry > 0)
            {
                string s = carry.ToString();
                for (int i = s.Length - 1; i >= 0; i--)
                    result.digits.Add(int.Parse(s.Substring(i, 1)));
            }

            return result;
        }

        public BigNum AddTo(BigNum add)
        {
            BigNum result = new BigNum();

            long carry = 0;
            long newDigit = 0;

            long maxDigits = Math.Max(this.digits.Count, add.digits.Count);

            for (int i = 0; i < maxDigits; i++)
            {
                long a = carry;
                if (i < this.digits.Count)
                    a += this.digits[i];
                if (i < add.digits.Count)
                    a += add.digits[i];
                newDigit = a % 10;
                carry = (a - newDigit) / 10;
                result.digits.Add((int)newDigit);
            }

            while (carry > 0)
            {
                newDigit = carry % 10;
                carry = (carry - newDigit) / 10;
                result.digits.Add((int)newDigit);
            }

            return result;
        }

        public long SumDigits()
        {
            long sum = 0;
            foreach (int n in digits)
                sum += n;

            return sum;
        }
    }

    public struct Fraction
    {
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

            Utilities util = new Utilities();
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
}
