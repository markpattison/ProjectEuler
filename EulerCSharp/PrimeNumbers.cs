using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class PrimeNumbers
    {
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

    }
}
