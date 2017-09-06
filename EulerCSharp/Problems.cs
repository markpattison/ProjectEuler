using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler.EulerCSharp
{
    public class Problems
    {
        static Utilities util = new Utilities();

        /// <summary>
        /// Problem1
        /// Completed 10/11/2008
        /// </summary>
        public long Problem1()
        {
            long max = 1000;
            long answer = 0;

            long[] range = new long[max];

            for (long i = 0; i < max; i++)
                range[i] = i;

            IEnumerable<long> q = from i in range
                                  where (i % 3 == 0 || i % 5 == 0)
                                  select i;

            answer = q.Sum();

            return answer;
        }

        /// <summary>
        /// Problem2
        /// Completed 10/11/2008
        /// </summary>
        public long Problem2()
        {
            long limit = 4000000;
            long answer = 0;

            List<long> fib = new List<long>();

            fib.Add(1);
            fib.Add(1);

            while (fib.Last() <= limit)
            {
                if (fib.Last() % 2 == 0)
                    answer += fib.Last();
                fib.Add(fib[fib.Count - 2] + fib.Last());
            }

            return answer;
        }

        /// <summary>
        /// Problem3
        /// Completed 10/11/2008
        /// </summary>
        public long Problem3()
        {
            long target = 600851475143;
            long answer = 0;
            long end = (int)Math.Sqrt(target) + 2;

            for (long i = 2; i < end; i++)
                while (target % i == 0)
                {

                    answer = i;
                    target /= i;
                }

            return answer;
        }

        /// <summary>
        /// Problem4
        /// Completed 10/11/2008
        /// </summary>
        public long Problem4()
        {
            long answer = 0;
            long max = 999;
            long product = 0;

            for (long i = 1; i <= max; i++)
                for (long j = 1; j <= max; j++)
                {
                    product = i * j;
                    if (product > answer && util.IsPalindrome(product))
                        answer = product;
                }

            return answer;
        }

        /// <summary>
        /// Problem5
        /// Completed 11/11/2008
        /// </summary>
        public long Problem5()
        {
            long answer = 0;
            long limit = 20;

            // NB this is highly inefficient
            // problem can be done by hand in <1 minute...

            bool done;

            do
            {
                done = true;
                answer++;
                for (long j = 1; j <= limit; j++)
                {
                    if (answer % j != 0)
                        done = false;
                }
            } while (!done);

            return answer;
        }

        /// <summary>
        /// Problem6
        /// Completed 11/11/2008
        /// </summary>
        public long Problem6()
        {
            long answer = 0;
            long limit = 100;

            long sum = 0;
            long sumOfSquares = 0;
            long squareOfSum = 0;

            for (long i = 1; i <= limit; i++)
            {
                sum += i;
                sumOfSquares += (i * i);
            }
            squareOfSum = sum * sum;

            answer = squareOfSum - sumOfSquares;

            return answer;
        }

        /// <summary>
        /// Problem7
        /// Completed 11/11/2008
        /// </summary>
        public long Problem7()
        {
            long answer = 0;
            long number = 10001;
            long biglimit = 1000000;

            long[] primes = util.Primes(number, biglimit);

            if (primes[0] >= number)
                answer = primes[number];
            else
                answer = -primes[0];

            return answer;
        }

        /// <summary>
        /// Problem8
        /// Completed 11/11/2008
        /// </summary>
        public long Problem8()
        {
            long answer = 0;

            string num = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            for (int i = 0; i <= num.Length - 5; i++)
            {
                long product = 1;
                for (int j = 0; j < 5; j++)
                    product *= long.Parse(num[i + j].ToString());

                if (product > answer)
                    answer = product;
            }


            return answer;
        }

        /// <summary>
        /// Problem9
        /// Completed 12/11/2008
        /// </summary>
        public long Problem9()
        {
            long answer = 0;
            long target = 1000;
            long a, b, c;

            for (a = 1; a < target; a++)
                for (b = a; b < target; b++)
                {
                    c = (long)Math.Sqrt(a * a + b * b);
                    if (a * a + b * b == c * c && a + b + c == target)
                    {
                        answer = a * b * c;
                        a = target;
                        b = target;
                    }
                }

            return answer;
        }

        /// <summary>
        /// Problem10
        /// Completed 12/11/2008
        /// </summary>
        public long Problem10()
        {
            long answer = 0;
            long number = 150000;
            long limit = 2000000;

            long[] primes = util.Primes(number, limit);

            for (int i = 1; i <= primes[0]; i++)
                answer += primes[i];

            return answer;
        }

        /// <summary>
        /// Problem11
        /// Completed 11/11/2008
        /// </summary>
        public long Problem11()
        {
            // done by eye, they are diagonal near the bottom left

            long answer = 87 * 97 * 94 * 89; // 70600674

            return answer;
        }

        /// <summary>
        /// Problem12
        /// Completed 12/11/2008
        /// </summary>
        public long Problem12()
        {
            long answer = 0;
            long target = 500;
            long n = 3;

            do
            {
                n++;
            } while (util.NumberOfDivisors(util.TriangularNumber(n)) <= target);

            answer = util.TriangularNumber(n);

            return answer;
        }

        /// <summary>
        /// Problem13
        /// Completed 13/11/2008
        /// </summary>
        public long Problem13()
        {
            long answer = 0;

            string[] nums = new string[100];
            int i = 0;

            nums[i++] = "37107287533902102798797998220837590246510135740250";
            nums[i++] = "46376937677490009712648124896970078050417018260538";
            nums[i++] = "74324986199524741059474233309513058123726617309629";
            nums[i++] = "91942213363574161572522430563301811072406154908250";
            nums[i++] = "23067588207539346171171980310421047513778063246676";
            nums[i++] = "89261670696623633820136378418383684178734361726757";
            nums[i++] = "28112879812849979408065481931592621691275889832738";
            nums[i++] = "44274228917432520321923589422876796487670272189318";
            nums[i++] = "47451445736001306439091167216856844588711603153276";
            nums[i++] = "70386486105843025439939619828917593665686757934951";
            nums[i++] = "62176457141856560629502157223196586755079324193331";
            nums[i++] = "64906352462741904929101432445813822663347944758178";
            nums[i++] = "92575867718337217661963751590579239728245598838407";
            nums[i++] = "58203565325359399008402633568948830189458628227828";
            nums[i++] = "80181199384826282014278194139940567587151170094390";
            nums[i++] = "35398664372827112653829987240784473053190104293586";
            nums[i++] = "86515506006295864861532075273371959191420517255829";
            nums[i++] = "71693888707715466499115593487603532921714970056938";
            nums[i++] = "54370070576826684624621495650076471787294438377604";
            nums[i++] = "53282654108756828443191190634694037855217779295145";
            nums[i++] = "36123272525000296071075082563815656710885258350721";
            nums[i++] = "45876576172410976447339110607218265236877223636045";
            nums[i++] = "17423706905851860660448207621209813287860733969412";
            nums[i++] = "81142660418086830619328460811191061556940512689692";
            nums[i++] = "51934325451728388641918047049293215058642563049483";
            nums[i++] = "62467221648435076201727918039944693004732956340691";
            nums[i++] = "15732444386908125794514089057706229429197107928209";
            nums[i++] = "55037687525678773091862540744969844508330393682126";
            nums[i++] = "18336384825330154686196124348767681297534375946515";
            nums[i++] = "80386287592878490201521685554828717201219257766954";
            nums[i++] = "78182833757993103614740356856449095527097864797581";
            nums[i++] = "16726320100436897842553539920931837441497806860984";
            nums[i++] = "48403098129077791799088218795327364475675590848030";
            nums[i++] = "87086987551392711854517078544161852424320693150332";
            nums[i++] = "59959406895756536782107074926966537676326235447210";
            nums[i++] = "69793950679652694742597709739166693763042633987085";
            nums[i++] = "41052684708299085211399427365734116182760315001271";
            nums[i++] = "65378607361501080857009149939512557028198746004375";
            nums[i++] = "35829035317434717326932123578154982629742552737307";
            nums[i++] = "94953759765105305946966067683156574377167401875275";
            nums[i++] = "88902802571733229619176668713819931811048770190271";
            nums[i++] = "25267680276078003013678680992525463401061632866526";
            nums[i++] = "36270218540497705585629946580636237993140746255962";
            nums[i++] = "24074486908231174977792365466257246923322810917141";
            nums[i++] = "91430288197103288597806669760892938638285025333403";
            nums[i++] = "34413065578016127815921815005561868836468420090470";
            nums[i++] = "23053081172816430487623791969842487255036638784583";
            nums[i++] = "11487696932154902810424020138335124462181441773470";
            nums[i++] = "63783299490636259666498587618221225225512486764533";
            nums[i++] = "67720186971698544312419572409913959008952310058822";
            nums[i++] = "95548255300263520781532296796249481641953868218774";
            nums[i++] = "76085327132285723110424803456124867697064507995236";
            nums[i++] = "37774242535411291684276865538926205024910326572967";
            nums[i++] = "23701913275725675285653248258265463092207058596522";
            nums[i++] = "29798860272258331913126375147341994889534765745501";
            nums[i++] = "18495701454879288984856827726077713721403798879715";
            nums[i++] = "38298203783031473527721580348144513491373226651381";
            nums[i++] = "34829543829199918180278916522431027392251122869539";
            nums[i++] = "40957953066405232632538044100059654939159879593635";
            nums[i++] = "29746152185502371307642255121183693803580388584903";
            nums[i++] = "41698116222072977186158236678424689157993532961922";
            nums[i++] = "62467957194401269043877107275048102390895523597457";
            nums[i++] = "23189706772547915061505504953922979530901129967519";
            nums[i++] = "86188088225875314529584099251203829009407770775672";
            nums[i++] = "11306739708304724483816533873502340845647058077308";
            nums[i++] = "82959174767140363198008187129011875491310547126581";
            nums[i++] = "97623331044818386269515456334926366572897563400500";
            nums[i++] = "42846280183517070527831839425882145521227251250327";
            nums[i++] = "55121603546981200581762165212827652751691296897789";
            nums[i++] = "32238195734329339946437501907836945765883352399886";
            nums[i++] = "75506164965184775180738168837861091527357929701337";
            nums[i++] = "62177842752192623401942399639168044983993173312731";
            nums[i++] = "32924185707147349566916674687634660915035914677504";
            nums[i++] = "99518671430235219628894890102423325116913619626622";
            nums[i++] = "73267460800591547471830798392868535206946944540724";
            nums[i++] = "76841822524674417161514036427982273348055556214818";
            nums[i++] = "97142617910342598647204516893989422179826088076852";
            nums[i++] = "87783646182799346313767754307809363333018982642090";
            nums[i++] = "10848802521674670883215120185883543223812876952786";
            nums[i++] = "71329612474782464538636993009049310363619763878039";
            nums[i++] = "62184073572399794223406235393808339651327408011116";
            nums[i++] = "66627891981488087797941876876144230030984490851411";
            nums[i++] = "60661826293682836764744779239180335110989069790714";
            nums[i++] = "85786944089552990653640447425576083659976645795096";
            nums[i++] = "66024396409905389607120198219976047599490197230297";
            nums[i++] = "64913982680032973156037120041377903785566085089252";
            nums[i++] = "16730939319872750275468906903707539413042652315011";
            nums[i++] = "94809377245048795150954100921645863754710598436791";
            nums[i++] = "78639167021187492431995700641917969777599028300699";
            nums[i++] = "15368713711936614952811305876380278410754449733078";
            nums[i++] = "40789923115535562561142322423255033685442488917353";
            nums[i++] = "44889911501440648020369068063960672322193204149535";
            nums[i++] = "41503128880339536053299340368006977710650566631954";
            nums[i++] = "81234880673210146739058568557934581403627822703280";
            nums[i++] = "82616570773948327592232845941706525094512325230608";
            nums[i++] = "22918802058777319719839450180888072429661980811197";
            nums[i++] = "77158542502016545090413245809786882778948721859617";
            nums[i++] = "72107838435069186155435662884062257473692284509516";
            nums[i++] = "20849603980134001723930671666823555245252804609722";
            nums[i++] = "53503534226472524250874054075591789781264330331690";

            double sum = 0.0;

            for (int j = 0; j < 100; j++)
                sum += double.Parse(nums[j]);

            answer = long.Parse(sum.ToString().Substring(0, 1) + sum.ToString().Substring(2, 9));

            return answer;
        }

        /// <summary>
        /// Problem14
        /// Completed 13/11/2008
        /// </summary>
        public long Problem14()
        {
            long answer = 0;
            long longest = 0;
            long longestChain = 0;

            Problem14Chain chain = new Problem14Chain();

            for (long i = 1; i < 1000000; i++)
                if (chain.GetChainLength(i) > longestChain)
                {
                    longest = i;
                    longestChain = chain.GetChainLength(i);
                }
            answer = longest;

            return answer;
        }

        /// <summary>
        /// Problem15
        /// Completed 13/11/2008
        /// </summary>
        public long Problem15()
        {
            // done using a calculator

            // this is just (40 choose 20)
            // using Pascal's triangle as the reasoning...

            long answer = 137846528820;

            return answer;
        }

        /// <summary>
        /// Problem16
        /// Completed 14/11/2008
        /// </summary>
        public long Problem16()
        {
            long answer = 0;
            long target = 1000;

            BigNum n = new BigNum(1);

            for (long i = 0; i < target; i++)
                n = n.MultiplyBy(2);

            answer = n.SumDigits();

            return answer;
        }

        /// <summary>
        /// Problem17
        /// Completed 3/12/2008
        /// </summary>
        public long Problem17()
        {
            long answer = 0;
            long target = 1000;

            string a;

            for (int i = 1; i <= target; i++)
            {
                answer += util.NumberOfLetters(i);
                a = util.Letters(i);
            }

            return answer;
        }

        /// <summary>
        /// Problem18
        /// Completed 14/11/2008
        /// </summary>
        public long Problem18()
        {
            long answer = 0;

            long[,] triangle = new long[,] {
                {75,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {95, 64,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {17, 47, 82,0,0,0,0,0,0,0,0,0,0,0,0},
                {18, 35, 87, 10,0,0,0,0,0,0,0,0,0,0,0},
                {20, 04, 82, 47, 65,0,0,0,0,0,0,0,0,0,0},
                {19, 01, 23, 75, 03, 34,0,0,0,0,0,0,0,0,0},
                {88, 02, 77, 73, 07, 63, 67,0,0,0,0,0,0,0,0},
                {99, 65, 04, 28, 06, 16, 70, 92,0,0,0,0,0,0,0},
                {41, 41, 26, 56, 83, 40, 80, 70, 33,0,0,0,0,0,0},
                {41, 48, 72, 33, 47, 32, 37, 16, 94, 29,0,0,0,0,0},
                {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14,0,0,0,0},
                {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57,0,0,0},
                {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48,0,0},
                {63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31,0},
                {04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23} };

            long size = triangle.GetLength(0);

            long[,] max = new long[size, size];

            for (long row = size - 1; row >= 0; row--)
            {
                for (long column = row; column >= 0; column--)
                {
                    if (row == size - 1)
                        max[row, column] = triangle[row, column];
                    else
                        max[row, column] = triangle[row, column] + Math.Max(max[row + 1, column], max[row + 1, column + 1]);
                }
            }

            answer = max[0, 0];

            return answer;
        }

        /// <summary>
        /// Problem19
        /// Completed 12/01/2009
        /// </summary>
        public long Problem19()
        {
            long answer = 0;

            // Monday = 0, Sunday = 6
            // January = 0

            // years are plus 1900
            long[] firstDayOfYear = new long[101];
            firstDayOfYear[0] = 0;

            long daysInYear;
            long prevYear;
            for (long i = 1; i <= 100; i++)
            {
                prevYear = i + 1900 - 1;
                daysInYear = 365;
                if (prevYear % 4 == 0)
                    daysInYear = 366;
                if (prevYear % 100 == 0)
                    daysInYear = 365;
                if (prevYear % 400 == 0)
                    daysInYear = 366;
                firstDayOfYear[i] = (firstDayOfYear[i - 1] + daysInYear) % 7;
            }

            long[,] firstDayOfMonth = new long[101, 12];

            long daysInPrevMonth;
            for (long i = 0; i <= 100; i++)
            {
                firstDayOfMonth[i, 0] = firstDayOfYear[i];

                for (long m = 1; m < 12; m++)
                {
                    daysInPrevMonth = 31;
                    if (m == 4 || m == 6 || m == 9 || m == 11)
                        daysInPrevMonth = 30;
                    if (m == 2)
                    {
                        daysInPrevMonth = 28;
                        long year = i + 1900;
                        if (year % 4 == 0)
                            daysInPrevMonth = 29;
                        if (year % 100 == 0)
                            daysInPrevMonth = 28;
                        if (year % 400 == 0)
                            daysInPrevMonth = 29;
                    }
                    firstDayOfMonth[i, m] = (firstDayOfMonth[i, m - 1] + daysInPrevMonth) % 7;
                }
            }

            for (long i = 1; i <= 100; i++)
            {
                for (long m = 0; m < 12; m++)
                {
                    if (firstDayOfMonth[i, m] == 6)
                        answer++;
                }
            }

            return answer;
        }

        /// <summary>
        /// Problem20
        /// Completed 12/01/2009
        /// </summary>
        public long Problem20()
        {
            long answer = 0;
            long target = 100;

            BigNum n = new BigNum(target);

            for (long i = 2; i < target; i++)
                n = n.MultiplyBy(i);

            answer = n.SumDigits();

            return answer;
        }


        /// <summary>
        /// Problem22
        /// Completed 31/08/2009
        /// </summary>
        public long Problem22()
        {
            long answer = 0;

            // get names

            StreamReader sr = new StreamReader("Data\\names.txt");
            string all = sr.ReadLine();
            string[] names = all.Split(',').Select(s => s.Substring(1, s.Length - 2)).ToArray();

            Array.Sort<string>(names);

            for (int pos = 0; pos < names.Length; pos++)
            {
                answer += (pos + 1) * util.Value(names[pos]);
            }

            return answer;
        }

        /// <summary>
        /// Problem23
        /// Completed 31/08/2009
        /// </summary>
        public long Problem23()
        {
            long answer = 0;
            int max = 28123;

            bool[] isAbundant = util.AbundantsUpTo(max);

            for (int i = 1; i <= max; i++)
            {
                bool found = false;
                for (int compare = 1; compare <= i; compare++)
                {
                    if (isAbundant[compare] && isAbundant[i - compare])
                        found = true;
                }
                if (!found)
                    answer += i;
            }

            return answer;
        }

        /// <summary>
        /// Problem24
        /// Completed 12/01/2009
        /// </summary>
        public long Problem24()
        {
            long answer = 0;

            // done by hand

            // start with 1,000,000 permutations of <0123456789>

            // 2 * 9! uses 725,760 perms leaving 274,240 of 2<013456789>
            // 6 * 8! uses 241,920 perms leaving  32,320 of 27<01345689>
            // 6 * 7! uses  30,240 perms leaving   2,080 of 278<0134569>
            // 2 * 6! uses   1,440 perms leaving     640 of 2783<014569>
            // 5 * 5! uses     600 perms leaving      40 of 27839<01456>
            // 1 * 4! uses      24 perms leaving      16 of 278391<0456>
            // 2 * 3! uses      12 perms leaving       4 of 2783915<046>
            // 4th permutation of <046> is 460

            answer = 2783915460;

            return answer;
        }

        /// <summary>
        /// Problem25
        /// Completed 12/01/2009
        /// </summary>
        public long Problem25()
        {
            long answer = 0;
            long target = 1000;

            BigNum fibN = new BigNum(1);
            BigNum fibNminus1 = new BigNum(1);
            BigNum temp;
            long n = 2;

            while (fibN.NumDigits < target)
            {
                temp = fibN.AddTo(fibNminus1);
                fibNminus1 = fibN;
                fibN = temp;
                n++;
            }

            answer = n;

            return answer;
        }

        /// <summary>
        /// Problem26
        /// Completed 07/09/2009
        /// </summary>
        public long Problem26()
        {
            // unsatisfyingly guessed from primes near 1000

            long answer = 983;

            return answer;
        }

        /// <summary>
        /// Problem27
        /// Completed 07/09/2009
        /// </summary>
        public long Problem27()
        {
            long answer = 0;

            long maxProduct = 0;
            long max = 0;

            for (long a = -999; a < 1000; a++)
                for (long b = -999; b < 1000; b++)
                {
                    if (util.IsPrime(b))
                    {
                        long length = 0;
                        while (util.IsPrime(length * (a + length) + b))
                        {
                            if (length > max)
                            {
                                max = length;
                                maxProduct = a * b;
                            }
                            length++;
                        }
                    }
                }

            answer = maxProduct;

            return answer;
        }

        /// <summary>
        /// Problem28
        /// Completed 14/01/2009
        /// </summary>
        public long Problem28()
        {
            long answer = 0;
            long target = 1001;

            // observe that diagonal going up-right is (2n+1)^2
            // and that the other diagonals are the same less 2n, 4n and 6n
            //
            // then the sum for size 2p+1 is 1 + sum (n = 1 to p) of 4(2n+1)^2 - 2n - 4n - 6n
            // = 1 + sum (n = 1 to p) of 16n^2 + 4n + 4
            // = 1 + 16 * sum n^2 + 4 * sum n + 4 * sum 1
            //
            // now sum (n = 1 to p) of n^2 is p(p+1)(2p+1)/6
            // and sum (n = 1 to p) of n is p(p+1)/2
            // and sum (n = 1 to p) of 1 is p

            long p = (target - 1) / 2;

            answer = 1 + 16 * p * (p + 1) * (2 * p + 1) / 6 + 4 * p * (p + 1) / 2 + 4 * p;

            return answer;
        }

        /// <summary>
        /// Problem29
        /// Completed ???
        /// </summary>
        public long Problem29()
        {
            long answer = 0;

            double[] d = new double[99];

            for (int i = 0; i < 99; i++)
                d[i] = (double)(i + 2);

            List<double> l = new List<double>();

            for (int i = 0; i < 99; i++)
                for (int j = 0; j < 99; j++)
                    l.Add(Math.Pow(d[i], d[j]));

            answer = l.Distinct().Count();

            return answer;
        }

        /// <summary>
        /// Problem30
        /// Completed 14/01/2009
        /// </summary>
        public long Problem30()
        {
            long answer = 0;

            // note that for fifth powers, the number can be at most 6 digits (as 7 x 9^5 is only 413,343)

            long power = 5;
            long sum = 0;

            for (long i = 2; i < 1000000; i++)
            {
                string s = i.ToString();
                long sumPowers = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    long num = long.Parse(s.Substring(j, 1));
                    long prod = 1;
                    for (int k = 0; k < power; k++)
                        prod *= num;
                    sumPowers += prod;
                }
                if (sumPowers == i)
                    sum += i;
            }

            answer = sum;

            return answer;
        }

        /// <summary>
        /// Problem32
        /// Completed 08/09/2009
        /// </summary>
        public long Problem32()
        {
            // assuming a x b = c
            // note that the length of c must be four digits, leaving five for a * b
            // if c has five or more, a x b cannot be big enough
            // if c has three or less, a x b will be too big

            // so WLOG, a has one or two digits and b has four or three

            List<long> products = new List<long>();

            for (long a = 1; a < 10; a++)
                for (long b = 1000; b < 10000; b++)
                    if (util.Is9Pandigital(a.ToString() + b.ToString() + (a * b).ToString()))
                        products.Add(a * b);

            for (long a = 10; a < 100; a++)
                for (long b = 100; b < 1000; b++)
                    if (util.Is9Pandigital(a.ToString() + b.ToString() + (a * b).ToString()))
                        products.Add(a * b);

            long answer = products.Distinct().Sum();

            return answer;
        }

        /// <summary>
        /// Problem33
        /// Completed 05/03/2009
        /// </summary>
        public long Problem33()
        {
            long answer = 0;

            Fraction product = new Fraction(1, 1);

            for (long den = 12; den < 100; den++)
            {
                for (long num = 11; num < den; num++)
                {
                    Fraction f = new Fraction(num, den).Reduce();
                    string n = num.ToString();
                    string d = den.ToString();
                    string n2 = null;
                    string d2 = null;

                    if (n[0] == d[1])
                    {
                        n2 = n.Substring(1, 1);
                        d2 = d.Substring(0, 1);
                    }
                    if (n[1] == d[0])
                    {
                        n2 = n.Substring(0, 1);
                        d2 = d.Substring(1, 1);
                    }

                    if (n2 != null)
                    {
                        Fraction f2 = new Fraction(long.Parse(n2), long.Parse(d2)).Reduce();
                        if (f == f2)
                        {
                            product *= f;
                        }
                    }
                }
            }

            answer = product.Denominator;

            return answer;
        }

        /// <summary>
        /// Problem34
        /// Completed 14/01/2009
        /// </summary>
        public long Problem34()
        {
            long answer = 0;

            // note that highest possible answer is 7 * 9! = 2,540,160
            // because 8 * 9! = 2,903,040 and so no 8-digit numbers are possible

            // factorials
            long[] facs = new long[10];
            facs[0] = 1;
            facs[1] = 1;
            for (int i = 2; i < 10; i++)
                facs[i] = i * facs[i - 1];

            long sum = 0;

            for (long i = 3; i <= 7 * facs[9]; i++)
            {
                string s = i.ToString();
                long sumFacs = 0;
                for (int j = 0; j < s.Length; j++)
                    sumFacs += facs[int.Parse(s.Substring(j, 1))];
                if (sumFacs == i)
                    sum += i;
            }

            answer = sum;

            return answer;
        }

        /// <summary>
        /// Problem35
        /// Completed 22/01/2009
        /// </summary>
        public long Problem35()
        {
            long answer = 0;

            long target = 1000000;

            long[] primes = util.Primes(target, target);
            long numprimes = primes[0];

            bool[] isPrime = new bool[target];
            for (int i = 1; i <= numprimes; i++)
                isPrime[primes[i]] = true;

            long count = 3;
            // include 2, 3 & 5 to start with
            for (int i = 4; i <= numprimes; i++)
            {
                long p = primes[i];
                string s = p.ToString();
                if ((!s.Contains("0")) && (!s.Contains("2")) && (!s.Contains("4")) && (!s.Contains("5")) && (!s.Contains("6")) && (!s.Contains("8")))
                {
                    List<long> perms = util.RotateDigits(p);
                    bool allPrime = true;
                    foreach (long l in perms)
                    {
                        if (!isPrime[l])
                        {
                            allPrime = false;
                        }
                    }
                    if (allPrime)
                    {
                        count++;
                    }
                }
            }

            answer = count;

            return answer;
        }

        /// <summary>
        /// Problem36
        /// Completed 15/01/2009
        /// </summary>
        public long Problem36()
        {
            long answer = 0;

            long target = 1000000;
            long sum = 0;

            for (long i = 1; i < target; i += 2)
            {
                if (util.IsPalindrome(i))
                {
                    string b = util.ToBinary(i);
                    if (b.Equals(util.ReverseString(b)))
                    {
                        sum += i;
                    }
                }
            }

            answer = sum;

            return answer;
        }

        /// <summary>
        /// Problem37
        /// Completed 12/03/2009
        /// </summary>
        public long Problem37()
        {
            long answer = 0;
            long count = 0;
            long target = 11;

            long[] primes = util.Primes(100000, 10000000);
            long numprimes = primes[0];

            int numdigits = 0;
            bool isTruncatable = true;
            string digits;

            for (long i = 5; i <= numprimes; i++)
            {
                digits = primes[i].ToString();
                numdigits = digits.Length;
                isTruncatable = true;

                for (int j = 1; j < numdigits; j++)
                {
                    if (!primes.Contains(long.Parse(digits.Substring(j))))
                    {
                        isTruncatable = false;
                        j = numdigits - 1;
                    }
                    if (!primes.Contains(long.Parse(digits.Substring(0, j))))
                    {
                        isTruncatable = false;
                        j = numdigits - 1;
                    }
                }

                if (isTruncatable)
                {
                    count++;
                    answer += primes[i];
                }

                if (count >= target)
                {
                    // exit loop
                    i = numprimes + 1;
                }
            }

            return answer;
        }

        /// <summary>
        /// Problem38
        /// Completed 08/09/2009
        /// </summary>
        public long Problem38()
        {
            // note that the integer a must begin with 9

            long max = 0;

            for (long a = 9; a < 10000; a++)
            {
                if (a.ToString().Substring(0, 1) == "9")
                {
                    string s = a.ToString();
                    for (long b = 2; b < 6; b++)
                    {
                        s = s + (a * b).ToString();
                        if (util.Is9Pandigital(s))
                            max = Math.Max(max, long.Parse(s));
                    }
                }
            }

            long answer = max;

            return answer;
        }

        /// <summary>
        /// Problem39
        /// Completed 15/09/2009
        /// </summary>
        public long Problem39()
        {
            long answer = 0;

            long max = 0;
            long maxp = 0;

            // this double counts some but it doesn't matter when finding the max
            for (long p = 3; p <= 1000; p++)
            {
                long triangles = 0;
                for (long a = 1; a < p - 1; a++)
                {
                    for (long b = 1; b < (p - a); b++)
                    {
                        long c = p - a - b;
                        if (a * a + b * b == c * c)
                        {
                            triangles++;
                        }
                    }
                }

                if (triangles > max)
                {
                    max = triangles;
                    maxp = p;
                }
            }

            answer = maxp;

            return answer;
        }

        /// <summary>
        /// Problem40
        /// Completed ???
        /// </summary>
        public long Problem40()
        {
            long answer = 0;

            int i = 1;
            StringBuilder sb = new StringBuilder();

            while (sb.Length < 1000000)
            {
                sb.Append(i.ToString());
                i++;
            }

            answer = 1;
            int j = 1;

            for (int k = 0; k < 7; k++)
            {
                answer *= int.Parse(sb[j - 1].ToString());
                j *= 10;
            }

            return answer;
        }

        /// <summary>
        /// Problem41
        /// Completed 03/03/2009
        /// </summary>
        public long Problem41()
        {
            long answer = 0;

            // can't be 9 or 8 digits, as all such pandigital numbers are all divisible by 3

            long max = 7654321;
            long[] primes = util.Primes(max, max);

            long numprimes = primes[0];

            for (long i = numprimes; i >= 1; i--)
            {
                if (primes[i].ToString().ToCharArray().Distinct().Count() == primes[i].ToString().Length && primes[i].ToString().ToCharArray().Max().Equals(primes[i].ToString().Length.ToString().ToCharArray()[0]))
                {
                    answer = primes[i];
                    break;
                }
            }

            return answer;
        }

        /// <summary>
        /// Problem42
        /// Completed 31/08/2009
        /// </summary>
        public long Problem42()
        {
            long answer = 0;

            // get words
            StreamReader sr = new StreamReader("Data\\words.txt");
            string all = sr.ReadLine();
            string[] words = all.Split(',').Select(s => s.Substring(1, s.Length - 2)).ToArray();

            // get triangle numbers
            List<long> triangles = new List<long>();
            for (long i = 1; i < 50; i++)
            {
                triangles.Add(i * (i + 1) / 2);
            }

            foreach (string s in words)
            {
                if (triangles.Contains(util.Value(s)))
                    answer++;
            }

            return answer;
        }

        /// <summary>
        /// Problem43
        /// Completed 04/03/2009
        /// </summary>
        public long Problem43()
        {
            long answer = 0;
            string target = "1234567890";

            List<string> nums = util.AllDigitPermutations(target);

            foreach (string s in nums)
            {
                long a1 = long.Parse(s.Substring(1, 3));
                long a2 = long.Parse(s.Substring(2, 3));
                long a3 = long.Parse(s.Substring(3, 3));
                long a4 = long.Parse(s.Substring(4, 3));
                long a5 = long.Parse(s.Substring(5, 3));
                long a6 = long.Parse(s.Substring(6, 3));
                long a7 = long.Parse(s.Substring(7, 3));

                if (a1 % 2 == 0 &&
                    a2 % 3 == 0 &&
                    a3 % 5 == 0 &&
                    a4 % 7 == 0 &&
                    a5 % 11 == 0 &&
                    a6 % 13 == 0 &&
                    a7 % 17 == 0)
                {
                    answer += long.Parse(s);
                }
            }

            return answer;
        }

        /// <summary>
        /// Problem44
        /// Completed 04/03/2009
        /// </summary>
        public long Problem44()
        {
            long answer = 0;
            long max = 3000;

            long[] pent = new long[max + 1];

            for (long i = 1; i <= max; i++)
            {
                pent[i] = util.Pentagonal(i);
            }

            long maxpent = pent[max];

            for (long j = 2; j <= max; j++)
            {
                for (long k = j - 1; k > 0; k--)
                {
                    if (pent.Contains(pent[j] + pent[k]) && pent.Contains(pent[j] - pent[k]))
                    {
                        answer = util.Pentagonal(j) - util.Pentagonal(k);
                        break;
                    }
                }
                if (answer > 0)
                    break;
            }

            return answer;
        }

        /// <summary>
        /// Problem45
        /// Completed 04/03/2009
        /// </summary>
        public long Problem45()
        {
            long answer = 0;

            long next = 286;
            bool found = false;

            do
            {
                long n = util.TriangularNumber(next);
                if (util.IsPentagonal(n) && util.IsHexagonal(n))
                {
                    found = true;
                    answer = n;
                }
                next++;
            } while (!found);

            return answer;
        }

        /// <summary>
        /// Problem46
        /// Completed 15/09/2009
        /// </summary>
        public long Problem46()
        {
            long answer = 0;

            long[] primes = util.Primes(10000, 200000);
            primes[0] = -1;

            for (long a = 9; a <= 100000; a += 2)
            {
                if (!primes.Contains(a))
                {
                    bool found = false;
                    //try all primes up to a (not including 2)
                    int pr = 2;
                    long test = 0;
                    while (primes[pr] < a)
                    {
                        test = (a - primes[pr]) / 2;
                        if ((long)Math.Sqrt(test) * (long)Math.Sqrt(test) == test)
                        {
                            found = true;
                            break;
                        }
                        pr++;
                    }
                    if (!found)
                    {
                        answer = a;
                        break;
                    }
                }
            }

            return answer;
        }

        /// <summary>
        /// Problem47
        /// Completed 26/09/2009 
        /// </summary>
        public long Problem47()
        {
            long answer = 0;
            long target = 4;
            bool found = false;
            long foundInARow = 0;
            long n = 0;

            long[] primes = util.Primes(1000000, 1000000);

            while (!found)
            {
                n++;
                if (util.DistinctPrimeFactors(n, primes) >= target)
                {
                    foundInARow++;
                }
                else
                {
                    foundInARow = 0;
                }

                if (foundInARow >= target)
                {
                    found = true;
                    answer = n + 1 - target;
                }
            }

            return answer;
        }

        /// <summary>
        /// Problem48
        /// Completed 15/01/2009
        /// </summary>
        public string Problem48()
        {
            BigNum sum = new BigNum(0);

            for (long i = 1; i <= 1000; i++)
            {
                BigNum power = new BigNum(1);
                for (long j = 1; j <= i; j++)
                    power = power.MultiplyBy(i);

                sum = sum.AddTo(power);
            }

            // number has 3001 digits!
            return sum.ToString();
        }

        /// <summary>
        /// Problem67
        /// Completed 31/08/2009
        /// </summary>
        public long Problem67()
        {
            long answer = 0;

            // get numbers into triangle

            long[,] triangle = new long[100, 100];

            StreamReader sr = new StreamReader("Data\\triangle.txt");

            for (int row = 1; row <= 100; row++)
            {
                string s1 = sr.ReadLine();
                string[] s2 = s1.Split(' ');
                for (int col = 1; col <= row; col++)
                {
                    triangle[row - 1, col - 1] = int.Parse(s2[col - 1]);
                }
            }

            // this code copied from Problem 18

            long size = triangle.GetLength(0);

            long[,] max = new long[size, size];

            for (long row = size - 1; row >= 0; row--)
            {
                for (long column = row; column >= 0; column--)
                {
                    if (row == size - 1)
                        max[row, column] = triangle[row, column];
                    else
                        max[row, column] = triangle[row, column] + Math.Max(max[row + 1, column], max[row + 1, column + 1]);
                }
            }

            answer = max[0, 0];

            return answer;
        }

        /// <summary>
        /// Problem69
        /// Completed 26/09/2009
        /// </summary>
        public long Problem69()
        {
            // NB I should have worked out that the answer is just a multpiple of the smallest primes
            // i.e. 2*3*5*7*11*13*17 = 510510

            long answer = 0;

            long[] primes = util.Primes(1000000, 1000000);

            long maxn = 0;
            double max = 0;
            long phi;
            double ratio;

            for (long n = 6; n <= 1000000; n += 6)
            {
                phi = util.EulerTotient(n, primes);
                ratio = (double)n / (double)phi;
                if (ratio > max)
                {
                    max = ratio;
                    maxn = n;
                }
            }

            answer = maxn;

            return answer;
        }


        /// <summary>
        /// Problem235
        /// Completed 12/03/2009
        /// </summary>
        public double Problem235()
        {
            double answer = 0;

            Func<double, Func<int, double>> u = r => k => (900.0 - 3.0 * k) * Math.Pow(r, k - 1);
            Func<double, Func<int, double>> du = r => k => (900.0 - 3.0 * k) * (k - 1.0) * Math.Pow(r, k - 2);

            Func<int, double, double> s = (k, r) => Enumerable.Range(1, k).Sum(u(r));
            Func<int, double, double> ds = (k, r) => Enumerable.Range(1, k).Sum(du(r));

            double a = s(5000, 0.0);     //                 897.000000
            double b = s(5000, 1.0);     //         -33,007,500.000000
            double c = s(5000, 1.001);   //      -1,647,175,481.404537
            double d = s(5000, 1.002);   //    -137,389,011,510.7948
            double e = s(5000, 1.003);   // -13,957,741,881,931.996

            // hence answer lies between 1.002 and 1.003

            // use Newton-Raphson: x1 = x0 - f(x0)/f'(x0)
            // where f(x)  = s(5000, x) + 600,000,000,000
            // hence f'(x) = s'(5000,x)

            Func<double, double> f = (r) => s(5000, r) + 600000000000.0;
            Func<double, double> df = (r) => ds(5000, r);

            double x = 1.0025;

            for (int i = 0; i < 10; i++)
            {
                x = x - f(x) / df(x);
            }

            answer = x;

            return answer;
        }

        /// <summary>
        /// ProblemTemplate
        /// Completed 
        /// </summary>
        public long Prob()
        {
            long answer = 0;

            return answer;
        }
    }
}
